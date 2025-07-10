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
    /// <summary>
    /// Interaction logic for CheckOut.xaml
    /// </summary>
    public partial class CheckOut : Window
    {
        
        private readonly CustomerService _customerService = new CustomerService();
        private List<Customer> _inHotelCustomers = new();

        public CheckOut()
        {
            InitializeComponent();
            LoadCustomers();
            //txtSearchName.TextChanged += TxtSearchName_TextChanged;
            //dgCustomerList.SelectionChanged += DgCustomerList_SelectionChanged;
        }

        private void LoadCustomers()
        {
            var allCustomers = _customerService.GetCustomerWithRoomInfo(); // chỉ lấy Customer
    dgCustomerList.ItemsSource = allCustomers;
        }


       
        private void CheckOut_Click(object sender, RoutedEventArgs e)
        {
            if (dgCustomerList.SelectedItem is not Customer selected)
            {
                MessageBox.Show("Please select a customer.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (dpCheckOutDate.SelectedDate == null)
            {
                MessageBox.Show("Please select a check-out date.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                string checkoutDate = dpCheckOutDate.SelectedDate.Value.ToString("yyyy-MM-dd");

                _customerService.CheckOutCustomer(selected.Cid, selected.Roomid.ToString(), checkoutDate);

                MessageBox.Show("Check-out successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                LoadCustomers(); // refresh list
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearForm()
        {
            
            dpCheckOutDate.SelectedDate = null;
        }

      
    }
}

