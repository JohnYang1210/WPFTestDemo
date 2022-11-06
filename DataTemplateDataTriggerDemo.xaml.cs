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

    public class Pic
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public Pic(string name, string description, string imagePath)
        {
            Name = name;
            Description = description;
            ImagePath = imagePath;
        }
    }

    /// <summary>
    /// DataTemplateDataTriggerDemo.xaml 的交互逻辑
    /// </summary>
    public partial class DataTemplateDataTriggerDemo : UserControl
    {
        public DataTemplateDataTriggerDemo()
        {
            InitializeComponent();
            picListBox.ItemsSource = new List<Pic>
            {
                new Pic("DangerPic","this is a picture named Danger","/Resources/Danger.png"),
                new Pic("EyePic","this is a picture named Eype","/Resources/Eye.png"),
                new Pic("PeopleHolloPic","this is a picture named PeopleHollo","/Resources/PeopleHollo.png"),
            };
        }
    }
}
