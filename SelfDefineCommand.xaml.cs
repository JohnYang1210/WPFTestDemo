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
    /// 自定义命令
    /// </summary>
    public class DataCommands
    {
        private static RoutedUICommand requery;
        public static RoutedUICommand Requery
        {
            get
            {
                return requery;
            }
        }
        /// <summary>
        /// 静态构造器
        /// </summary>
        static DataCommands()
        {
            InputGestureCollection inputs = new InputGestureCollection();
            inputs.Add(new KeyGesture(Key.R,ModifierKeys.Control,"Ctrl+R"));
            requery = new RoutedUICommand("Requery","Requery",typeof(DataCommands),inputs);
        }
    }


    /// <summary>
    /// SelfDefineCommand.xaml 的交互逻辑
    /// </summary>
    public partial class SelfDefineCommand : UserControl
    {
        public SelfDefineCommand()
        {
            InitializeComponent();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Requery 事件");
        }
    }
}
