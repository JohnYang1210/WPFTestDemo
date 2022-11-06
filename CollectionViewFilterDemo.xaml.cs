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

    public class PersonA
    {
        public string FirstName { get; set; }
        public int Age { get; set; }
        public string FavoriteColor { get; set; }
        public string Sex { get; set; }
        public PersonA(string fName,int age,string color,string sex)
        {
            FirstName = fName;
            Age = age;
            FavoriteColor = color;
            Sex = sex;
        }
    }

    /// <summary>
    /// CollectionViewFilterDemo.xaml 的交互逻辑
    /// </summary>
    public partial class CollectionViewFilterDemo : UserControl
    {
        CollectionView cv;
        public CollectionViewFilterDemo()
        {
            InitializeComponent();
            PersonA[] people =
            {
                new PersonA("Shirley",34,"Beige","F"),
                 new PersonA("Roy",36,"GoldenRod","M"),
                  new PersonA("Isable",25,"DarkGray","F"),
                   new PersonA("Manuel",27,"Red","M"),
                   new PersonA("John",29,"Blue","M"),
            };
            listPeople.ItemsSource = people;
            cv = (CollectionView)CollectionViewSource.GetDefaultView(people);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cv.Filter = null;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Button_Click(null,null);
            cv.Filter = (object obj) =>
            {
                return (obj as PersonA).Age < 30;
            };
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Button_Click(null, null);
            cv.Filter = (object obj) =>
            {
                return (obj as PersonA).Age >= 30;
            };
        }
    }
}
