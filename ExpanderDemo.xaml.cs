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
    /// ExpanderDemo.xaml 的交互逻辑
    /// </summary>
    public partial class ExpanderDemo : UserControl
    {
        public ExpanderDemo()
        {
            InitializeComponent();
        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            column2.Visibility = Visibility.Collapsed;
            column2.Width = 0;
            Application.Current.MainWindow.Width = Application.Current.MainWindow.Width /2;
            
        }

        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
            column2.Visibility = Visibility.Visible;
            column2.Width = 200;
            Application.Current.MainWindow.Width = Application.Current.MainWindow.Width * 2;
        }
    }
}
