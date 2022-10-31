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

    public class Data
    {
        public int data
        {
            get; set;
        }
        public Data(int data)
        {
            this.data = data;
        }
    }

    public class TestDataType
    {
        public string name
        {
            get; set;
        }
        public List<Data> datas
        {
            get; set;
        }

    }


    /// <summary>
    /// DataTemplateItemsSourceDataBindingTest.xaml 的交互逻辑
    /// </summary>
    public partial class DataTemplateItemsSourceDataBindingTest : UserControl
    {
        public DataTemplateItemsSourceDataBindingTest()
        {
            InitializeComponent();
            midMessageListBox.ItemsSource = new List<TestDataType>()
            {
                new TestDataType()
                {
                    name="test1",
                    datas=new List<Data>
                    {
                        new Data(0),new Data(1),
                        new Data(2),new Data(3)
                    }
                },
                new TestDataType()
                {
                    name="test2",
                    datas=new List<Data>
                    {
                        new Data(2),new Data(4),
                        new Data(6),new Data(8)
                    }
                }

            };
        }
    }
}
