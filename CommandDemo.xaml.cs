using System;
using System.Collections.Generic;
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
    /// <summary>
    /// CommandDemo.xaml 的交互逻辑
    /// </summary>
    public partial class CommandDemo : UserControl
    {
        //声明命令并定义命令
        private RoutedCommand clearCmd = new RoutedCommand("Clear",typeof(CommandDemo));
        public CommandDemo()
        {
            InitializeComponent();
            InitializeCommand();
        }

        /// <summary>
        /// 初始化配置命令，可配合《深入浅出WPF》P177的图来理解，
        /// 该图详细描述了命令，命令源，命令目标，命令关联之间的联系。
        /// </summary>
        private void InitializeCommand()
        {

            //把命令赋值给命令源（发送者），并指定快捷键
            this.button1.Command = clearCmd;
            this.clearCmd.InputGestures.Add(new KeyGesture(Key.C,ModifierKeys.Alt));//指定快捷键

            //指定命令目标，注意是**命令源**的属性
            this.button1.CommandTarget = this.textBoxA;

            //创建命令关联
            CommandBinding cb = new CommandBinding();
            cb.Command=this.clearCmd;
            cb.CanExecute += new CanExecuteRoutedEventHandler(cb_CanExecute);
            cb.Executed += new ExecutedRoutedEventHandler(cb_Executed);

            //把命令关联安装在外围控件上

            this.stackPanel.CommandBindings.Add(cb);

        }

        private void cb_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.textBoxA.Clear();
            e.Handled = true;
        }

        private void cb_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBoxA.Text))
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
            e.Handled = true;
        }
    }
}
