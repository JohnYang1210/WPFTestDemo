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
    /// RichTextBoxDemo.xaml 的交互逻辑
    /// </summary>
    public partial class RichTextBoxDemo : UserControl
    {
        public RichTextBoxDemo()
        {
            InitializeComponent();
        }
        // Change the current selection.
        void ChangeSelection(Object sender, RoutedEventArgs args)
        {
            // Create two arbitrary TextPointers to specify the range of content to select.
            TextPointer myTextPointer1 = myParagraph.ContentStart.GetPositionAtOffset(20);
            TextPointer myTextPointer2 = myParagraph.ContentEnd.GetPositionAtOffset(-10);

            // Programmatically change the selection in the RichTextBox.
            richTB.Selection.Select(myTextPointer1, myTextPointer2);
        }
    }
}
