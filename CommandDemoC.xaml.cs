using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpfTestStudio
{

    public  class CommandHistoryItem
    {
        public string CommandName { get; set; }
        public UIElement ElementActedOn { get; set; }
        public string PropertyActedOn { get; set; }
        public object PreviousState { get; set; }
        public CommandHistoryItem(string commandName, UIElement elementActedOn, string propertyActedOn, object previousState)
        {
            CommandName = commandName;
            ElementActedOn = elementActedOn;
            PropertyActedOn = propertyActedOn;
            PreviousState = previousState;
        }
        public CommandHistoryItem(string commandName) : this(commandName, null, "", null) { }

        public bool CanUndo
        {
            get
            {
                return (ElementActedOn != null && PropertyActedOn != "");
            }
        }

        public void Undo()
        {
            Type elementType=ElementActedOn.GetType();
            PropertyInfo property = elementType.GetProperty(PropertyActedOn);
            property.SetValue(ElementActedOn,PreviousState,null);
        }

    }

    /// <summary>
    /// CommandDemoC.xaml 的交互逻辑
    /// </summary>
    public partial class CommandDemoC : UserControl
    {
        private ObservableCollection<CommandHistoryItem> histItems = new ObservableCollection<CommandHistoryItem>();
        private static RoutedUICommand applicationUndo;
        public static RoutedUICommand ApplicationUndo
        {
            get
            {
                return applicationUndo;
            }
        }
        //静态构造器
        static CommandDemoC()
        {
            InputGestureCollection inputs = new InputGestureCollection();
            inputs.Add(new KeyGesture(Key.Z,ModifierKeys.Control,"Ctrl+Z"));
            applicationUndo=new RoutedUICommand("ApplicationUndo","Application Undo",
                typeof(CommandDemoC),inputs);
        }

        public CommandDemoC()
        {
            InitializeComponent();
            lstHistory.ItemsSource = histItems;
            //this.lstHistory.AddHandler(PreviewMouseWheelEvent, new MouseWheelEventHandler(lstHistory_MouseWheel));
            this.AddHandler(CommandManager.PreviewExecutedEvent,new ExecutedRoutedEventHandler(CommandExecuted));
            initBindMouseWheel();
        }

        //private void lstHistory_MouseWheel(object sender, MouseWheelEventArgs e)
        //{
        //    if (e.Delta > 0)
        //    {
        //        scrollViewer.LineUp();
        //    }
        //    else
        //    {
        //        scrollViewer.LineDown();
        //    }
        //}

        private void CommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Source is ICommandSource) return;
            if (e.Command == CommandDemoC.applicationUndo) return;
            TextBox txt = e.OriginalSource as TextBox;
            if(txt != null)
            {
                RoutedCommand cmd = (RoutedCommand)e.Command;
                CommandHistoryItem histItem = new CommandHistoryItem(cmd.Name,txt,"Text",txt.Text);
                histItems.Add(histItem);
            }
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            this.RemoveHandler(CommandManager.PreviewExecutedEvent,new ExecutedRoutedEventHandler(CommandExecuted));
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CommandHistoryItem histItem = (CommandHistoryItem)lstHistory.Items[lstHistory.Items.Count - 1];
            if (histItem.CanUndo) histItem.Undo();
            lstHistory.Items.Remove(histItem);
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (lstHistory == null || lstHistory.Items.Count == 0)
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
        }

        private void initBindMouseWheel()
        {
            PreviewMouseWheel += (sender, e) =>
            {
                var eventArg = new MouseWheelEventArgs(e.MouseDevice, 1, e.Delta);
                eventArg.RoutedEvent = UIElement.MouseWheelEvent;
                eventArg.Source = sender;
                this.lstHistory.RaiseEvent(eventArg);
            };
            MouseDoubleClick += (sender, e) =>
            {
                MessageBox.Show($"sender is {e.OriginalSource}");
            };
        }
    }
}
