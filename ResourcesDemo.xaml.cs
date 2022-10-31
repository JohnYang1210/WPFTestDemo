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
    /// ResourcesDemo.xaml 的交互逻辑
    /// </summary>
    public partial class ResourcesDemo : UserControl
    {
        public ResourcesDemo()
        {
            InitializeComponent();
            VisualTreeDisplayWin treeDisplay = new VisualTreeDisplayWin();
            treeDisplay.ShowVisualTree(this);
            treeDisplay.Show();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //ImageBrush brush = (ImageBrush)this.Resources["TileBrush"];
            //brush.Viewport = new Rect(0, 0, 5, 5);
        }

        private void dynaBtn_Click(object sender, RoutedEventArgs e)
        {
            ImageBrush brush = (ImageBrush)dynaBtn.Resources["TileBrush"];
            brush.Viewport = new Rect(0, 0, 5, 5);

            //dynaBtn.Resources["TieBrush"] = new SolidColorBrush(Colors.LightBlue);

        }

        private void staticBtn_Click(object sender, RoutedEventArgs e)
        {
            ImageBrush brush = (ImageBrush)this.Resources["TileBrush"];
            brush.Viewport = new Rect(0, 0, 5, 5);

            //this.Resources["TieBrush"] = new SolidColorBrush(Colors.LightBlue);
        }
    }
}
