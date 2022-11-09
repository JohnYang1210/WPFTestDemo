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
    /// RoutEventDemoA.xaml 的交互逻辑
    /// </summary>
    public partial class RoutEventDemoA : UserControl
    {
        private int eventCounter = 0;
        public RoutEventDemoA()
        {
            InitializeComponent();
        }

        private void SomethingClicked(object sender, MouseButtonEventArgs e)
        {
            eventCounter++;
            string message = "#" + eventCounter.ToString() + ":\n" +
                "Sender:" + sender.ToString() + "\n" +
                "Source:" + e.Source + "\n" +
                "Original Source:" + e.OriginalSource;
            lstMessages.Items.Add(message);
            e.Handled = (bool)chkHandle.IsChecked;
        }

        private void cmdClear_Click(object sender, RoutedEventArgs e)
        {
            lstMessages.Items.Clear();
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftShift))
            {
                MessageBox.Show("按了LeftShift键");
            }
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            Point pt=e.GetPosition(this);
            coordTextBlk.Text = $"You are at ({pt.X},{pt.Y}) in window Coordination";
        }
    }
}
