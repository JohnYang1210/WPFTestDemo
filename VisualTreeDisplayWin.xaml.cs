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
using System.Windows.Shapes;

namespace wpfTestStudio
{
    /// <summary>
    /// VisualTreeDisplayWin.xaml 的交互逻辑
    /// </summary>
    public partial class VisualTreeDisplayWin : Window
    {
        public VisualTreeDisplayWin()
        {
            InitializeComponent();
        }
        public void ShowVisualTree(DependencyObject element)
        {
            treeElements.Items.Clear();
            ProcessElement(element, null);
        }
        private void ProcessElement(DependencyObject element,TreeViewItem previousItem)
        {
            TreeViewItem item = new TreeViewItem();
            item.Header = element.GetType().Name;
            item.IsExpanded = true;

            if (previousItem == null)
            {
                treeElements.Items.Add(item);
            }
            else
            {
                previousItem.Items.Add(item);
            }
            
            int num = VisualTreeHelper.GetChildrenCount(element);
            for (int i = 0; i < num; i++)
            {
                ProcessElement(VisualTreeHelper.GetChild(element, i), item);
            }

        }
    }
}
