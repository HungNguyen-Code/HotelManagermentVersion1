using HotelManagermentBLL.Service;
using HotelManagermentDAL.Models;
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
using System.Windows.Shapes;

namespace HotelManagerment
{
    public partial class CustormerDetail : Window
    {
        private readonly CustomerService _service = new CustomerService();

        public CustormerDetail()
        {
            InitializeComponent();
            dgCustomerDetails.ItemsSource = _service.GetCustomerWithRoomInfo();




        }


        private void cbFilter_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = cbFilter.SelectedItem as ComboBoxItem;
            if (selectedItem == null) return;

            string selected = selectedItem.Content.ToString();

            if (selected == "All Customer Details")
            {
                dgCustomerDetails.ItemsSource = null;
                dgCustomerDetails.ItemsSource = _service.GetCustomerWithRoomInfo();
            }
            else if (selected == "In Hotel Customer")
            {
                dgCustomerDetails.ItemsSource = null;
                dgCustomerDetails.ItemsSource = _service.GetInHotelDisplays();
            }
            else if (selected == "CheckOut Customer")
            {
                dgCustomerDetails.ItemsSource = null;
                dgCustomerDetails.ItemsSource = _service.GetCheckedOutDisplays();
            }
        }

    }
}
