using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace wpfTestStudio
{
    /// <summary>
    /// ControlDetailTemplateShow.xaml 的交互逻辑
    /// </summary>
    public partial class ControlDetailTemplateShow : UserControl
    {
        public ControlDetailTemplateShow()
        {
            InitializeComponent();
            Initiald();

        }
        private void Initiald()
        {
            Type controlType = typeof(Control);
            List<Type> derivedTypes = new List<Type>();
            Assembly assembly = Assembly.GetAssembly(typeof(Control));
            foreach(Type type in assembly.GetTypes())
            {
                if(type.IsSubclassOf(controlType) && !type.IsAbstract && type.IsPublic)
                {
                    derivedTypes.Add(type);
                }
            }
            controlsListBox.ItemsSource = derivedTypes;
        }

        private void controlsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Type type = (Type)controlsListBox.SelectedItem;
                ConstructorInfo info=type.GetConstructor(System.Type.EmptyTypes);
                if(info != null)
                {
                    Control control = (Control)info.Invoke(null);
                    control.Visibility = Visibility.Collapsed;
                    //必须将control添加到grid的children中，才能使得其Template不为null
                    grid.Children.Add(control);
                    ControlTemplate template = control.Template;
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;
                    StringBuilder sb = new StringBuilder();
                    XmlWriter writer = XmlWriter.Create(sb, settings);
                    XamlWriter.Save(template, writer);
                    textTemplate.Text = sb.ToString();
                    grid.Children.Remove(control);
                }
                
            }
            catch(Exception err)
            {
                textTemplate.Text = "<< Error generating template:" + err.Message;
            }
        }
    }
}
