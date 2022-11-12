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
    /// CommandDemoB.xaml 的交互逻辑
    /// </summary>
    public partial class CommandDemoB : UserControl
    {
        private Dictionary<object,bool> isDirty=new Dictionary<object,bool>();
        public CommandDemoB()
        {
            InitializeComponent();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string text=((TextBox)sender).Text;
            MessageBox.Show("准备保存："+text);
            isDirty[sender] = false;
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

            if(isDirty.ContainsKey(sender) && isDirty[sender])
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            isDirty[sender] = true;


            //((TextBox)sender).CommandBindings[0].Command.Execute(null);
        }
    }
}
