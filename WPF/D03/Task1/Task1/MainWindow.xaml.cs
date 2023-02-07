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

namespace Task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Student> Students { get; set; }
        public MainWindow()
        {

            InitializeComponent();

            Students = new List<Student>()
            {
                new Student(){Name="Ali",Id=10,Image="img12.jpg",Age=15,Grade=100},
                new Student(){Name="Omnay",Id=20,Image="img12.jpg",Age=20,Grade=90},
                new Student(){Name="Amany",Id=30,Image="img12.jpg", Age=25,Grade=100},
                new Student(){Name="Mai",Id=40,Image="img12.jpg", Age=26,Grade=100},
                new Student(){Name="Maha",Id=50,Image="img12.jpg",Age=25,Grade=90},



            };
            lst.ItemsSource = Students;
        }
    }
}
