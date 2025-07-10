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
    /// Interaction logic for addRoom.xaml
    /// </summary>
    public partial class addRoom : Window
    {
        private  RoomService _service = new RoomService();
       
        public addRoom()
        {
            InitializeComponent();
            LoadRooms();
        }

        private void LoadRooms()
        {
            dgRoomList.ItemsSource = null;
            dgRoomList.ItemsSource = _service.GetAllRooms();
        }

        private void ClearForm()
        {
            txtRoomNo.Text = "";
            cbRoomType.SelectedIndex = -1;
            cbBedType.SelectedIndex = -1;
            txtPrice.Text = "";
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string roomNo = txtRoomNo.Text.Trim();
                string roomType = (cbRoomType.SelectedItem as ComboBoxItem)?.Content?.ToString();
                string bed = (cbBedType.SelectedItem as ComboBoxItem)?.Content?.ToString();
                bool isValidPrice = long.TryParse(txtPrice.Text, out long price);

                if (string.IsNullOrEmpty(roomNo) || string.IsNullOrEmpty(roomType) ||
                    string.IsNullOrEmpty(bed) || !isValidPrice || price <= 0)
                {
                    MessageBox.Show("Please enter valid values for all fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (_service.IsRoomNumberExists(roomNo))
                {
                    MessageBox.Show("Room number already exists!", "Duplicate", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                Room room = new Room
                {   
                    RoomNo = roomNo,
                    RoomType = roomType,
                    Bed = bed,
                    Price = price,
                    Booked = "NO"
                };

                _service.AddRoom(room);
                MessageBox.Show("Room added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                LoadRooms();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

       
    }
}

