using System;
using System.Collections.Generic;
using System.Reflection;
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
    public class Person
    {
        public string Hobby { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        private bool _ifMale;
        public bool IfMale
        {
            get
            {
                return _ifMale;
            }
            set
            {
                _ifMale = value;
                _ifFemale = !value;
            }
        }

        private bool _ifFemale;

        public bool IfFemale
        {
            get
            {
                return _ifFemale;
            }
            set
            {
                _ifFemale = value;
                _ifMale = !value;
            }
        }

        public Person(string name,int age,bool ifMale)
        {
            Name = name;
            Age = age;
            _ifMale = ifMale;
            _ifFemale = !ifMale;
        }
    }
    /// <summary>
    /// StyleSelectorDemo.xaml 的交互逻辑
    /// </summary>
    public partial class StyleSelectorDemo : UserControl
    {

        public StyleSelectorDemo()
        {
            InitializeComponent();
            peopleListBox.ItemsSource = new List<Person>()
            {
                new Person("JohnYang",31,true){Hobby="Swimming"},
                new Person("Tommy",28,false){Hobby="Running"},
                new Person("Kennsy",19,true){Hobby="Cooking"},
                new Person("Dorodial",24,false){Hobby="Learning"}
            };
            //需要注意的是，RadioButton的mode需是OneWay，否则会乱

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Unchecked_1(object sender, RoutedEventArgs e)
        {

        }

        private void peopleListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Person p = (Person)peopleListBox.SelectedItem;
            p.IfMale = !p.IfMale;
            //样式选择过程只执行一次，如果正则显式可编辑的数据，并且当
            //进行编辑时可能将数据项从一个样式移到另一个样式类别中，这就会称为问题
            //没什么优雅的办法解决，只能设置null，移除后，再只指定样式选择器
            var selector=peopleListBox.ItemContainerStyleSelector;
            peopleListBox.ItemContainerStyleSelector = null;
            peopleListBox.ItemContainerStyleSelector = selector;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button btn=(Button)sender;
            MessageBox.Show((string)btn.Tag);
        }
    }

    public class GenderStyleSelectorDemo : StyleSelector
    {
        
        public Style manStyle { get; set; }

        public Style womanStyle { get; set; }

        public string PropertyName { get; set; }


        public override Style SelectStyle(object item, DependencyObject container)
        {
            Person p=(Person)item;
            Type type = p.GetType();
            PropertyInfo property=type.GetProperty(PropertyName);
            if ((bool)property.GetValue(p))
            {
                return manStyle;
            }
            else
            {
                return womanStyle;
            }
        }

    }

}
