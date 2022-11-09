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
    /// RouteEventDemoB.xaml 的交互逻辑,
    /// 将TextBlock拖到Label上
    /// </summary>
    public partial class RouteEventDemoB : UserControl
    {
        public RouteEventDemoB()
        {
            InitializeComponent();
        }

        private void source_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            DragDrop.DoDragDrop(tb,tb.Text, DragDropEffects.Copy);
        }

        private void Label_Drop(object sender, DragEventArgs e)
        {
            ((Label)sender).Content = e.Data.GetData(DataFormats.Text);
        }

        /// <summary>
        /// 检查正在拖动的内容数据类型，确定所允许的操作类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effects = DragDropEffects.Copy;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
        }
    }
}
