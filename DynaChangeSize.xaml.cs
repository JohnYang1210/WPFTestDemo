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
    /// DynaChangeSize.xaml 的交互逻辑
    /// </summary>
    public partial class DynaChangeSize : UserControl
    {
        private int num = -1;
        public DynaChangeSize()
        {
            InitializeComponent();
            Application.Current.MainWindow.Width = 180;
        }

        private void changeBtn_Click(object sender, RoutedEventArgs e)
        {
            num = -num;
            if (num == 1)
            {
                Application.Current.MainWindow.Width = 300;
                grid2.Visibility = Visibility.Visible;
                changeBtn.Content = "隐藏";
            }
            else
            {
                Application.Current.MainWindow.Width = 180;
                grid2.Visibility = Visibility.Collapsed;
                changeBtn.Content = "展开";
            }
        }
    }
}
