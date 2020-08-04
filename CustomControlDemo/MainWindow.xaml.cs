using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomControlDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public class Product
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public static IEnumerable<Product> Products
        {
            get
            {
                return new List<Product>
                {
                    new Product{Key="Product ID",Value="1234999" },
                    new Product{Key="IGNORE",Value="Power Projector 4713" },
                    new Product{Key="Category",Value="Projector (PR)" },
                    new Product{Key="Description",Value="A very powerful projector with special features for Internet usability, USB" },
                    new Product{Key="Price",Value="856.49 EUR" },
                };

            }
        }
    }
}
