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
    /// RichTextBoxDemo2.xaml 的交互逻辑
    /// </summary>
    public partial class RichTextBoxDemo2 : UserControl
    {
        public RichTextBoxDemo2()
        {
            InitializeComponent();
            Init();
        }
        /// <summary>
        /// 动态创建流文档
        /// </summary>
        public void Init()
        {
            Run runFirst = new Run();
            runFirst.Text = "Hello world of";
            Bold bold = new Bold();
            Run runBold = new Run() { Text = " dynamically generated" };
            bold.Inlines.Add(runBold);

            Run runLast = new Run();
            runLast.Text = " Document";

            Paragraph paragraph = new Paragraph();
            paragraph.Inlines.Add(runFirst);
            paragraph.Inlines.Add(bold);
            paragraph.Inlines.Add(runLast);

            flowDoc.Blocks.Add(paragraph);
        }
    }
}
