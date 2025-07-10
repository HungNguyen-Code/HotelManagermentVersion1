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

namespace HotelManagerment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Room_Click(object sender, RoutedEventArgs e)
        {
            addRoom a = new addRoom();
            a.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CustormerResigter a = new CustormerResigter();
            a.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CustormerDetail a = new CustormerDetail();
            a.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CheckOut a = new CheckOut();
            a.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            EmployeeWindoww a = new EmployeeWindoww();
            a.Show();
        }
    }
}