using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class CollectionViewDemo : UserControl
    {
        CollectionView cv;
        public CollectionViewDemo()
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
            //按Sex和FavoriteColor进行分组
            PropertyGroupDescription pgd = new PropertyGroupDescription("Sex");
            cv.GroupDescriptions.Add(pgd);
            pgd = new PropertyGroupDescription("FavoriteColor");
            cv.GroupDescriptions.Add(pgd);
        }
        /// <summary>
        /// 默认没有过滤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cv.Filter = null;
        }
        /// <summary>
        /// 过滤小于30岁的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
 
            cv.Filter = (object obj) =>
            {
                return (obj as PersonA).Age < 30;
            };
        }
        /// <summary>
        /// 过滤大于等于30岁的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
 
            cv.Filter = (object obj) =>
            {
                return (obj as PersonA).Age >= 30;
            };
        }
        /// <summary>
        /// 默认排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sortDefaultBtn_Click(object sender, RoutedEventArgs e)
        {
            cv.SortDescriptions.Clear();
        }
        /// <summary>
        /// 根据名字排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sortByName_Click(object sender, RoutedEventArgs e)
        {
            cv.SortDescriptions.Clear();
            SortDescription sd = new SortDescription("FirstName",ListSortDirection.Ascending);
            cv.SortDescriptions.Add(sd);
        }
        /// <summary>
        /// 根据年龄排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sortByAge_Click(object sender, RoutedEventArgs e)
        {
            cv.SortDescriptions.Clear();
            SortDescription sd = new SortDescription("Age", ListSortDirection.Ascending);
            cv.SortDescriptions.Add(sd);
        }
        /// <summary>
        /// 根据性别和年龄排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sortBySexAndAge_Click(object sender, RoutedEventArgs e)
        {
            cv.SortDescriptions.Clear();
            SortDescription sd = new SortDescription("Sex", ListSortDirection.Ascending);
            cv.SortDescriptions.Add(sd);
            SortDescription sd2 = new SortDescription("Age",ListSortDirection.Ascending);
            cv.SortDescriptions.Add(sd2);
        }
    }
}
