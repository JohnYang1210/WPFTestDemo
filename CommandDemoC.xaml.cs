using System;
using System.Collections.Generic;
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
            this.AddHandler(CommandManager.PreviewExecutedEvent,new ExecutedRoutedEventHandler(CommandExecuted));
        }

        

        private void CommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Source is ICommandSource) return;
            if (e.Command == CommandDemoC.applicationUndo) return;
            TextBox txt = e.Source as TextBox;
            if(txt != null)
            {
                RoutedCommand cmd = (RoutedCommand)e.Command;
                CommandHistoryItem histItem = new CommandHistoryItem(cmd.Name,txt,"Text",txt.Text);

                ListBoxItem item = new ListBoxItem();
                item.Content = histItem;
                lstHistory.Items.Add(item); 
            }
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            this.RemoveHandler(CommandManager.PreviewExecutedEvent,new ExecutedRoutedEventHandler(CommandExecuted));
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

        }
    }
}
