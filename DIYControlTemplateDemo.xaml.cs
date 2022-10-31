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
    /// DIYControlTemplateDemo.xaml 的交互逻辑
    /// </summary>
    public partial class DIYControlTemplateDemo : UserControl
    {
        public DIYControlTemplateDemo()
        {
            InitializeComponent();
            messagesListBox.ItemsSource = new List<string>
            {
                "fjsdlfjdlsjfldsjfljsl",
                "fjdksjfldsjlfdslflfjlsdjfsdjlfjsdl",
                "fdksfjdksjd",
                "fd副记代理腹肌拉伤的房间里大将风度了都是垃圾分类激发了圣诞节",
                "dfjksfjksjdfklsfllksjfklsjfljwljfkwjeiojroqrejipqropwjvnwwjvrpownjrpoeipvoerwq" +
                "ewojrocwvjrcveoqjrcvpoqjhvrpoiewqhjporewpoqrvhjiqprhpqhprch3trpqtery8vt3409uvtguiohjsavrti" +
                "ju hvgfiopsamtuipoew"
            };
           
        }
    }
}
