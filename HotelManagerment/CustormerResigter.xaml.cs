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
    /// Interaction logic for CustormerResigter.xaml
    /// </summary>
    public partial class CustormerResigter : Window
    {
       
        private readonly CustomerService _service = new CustomerService();

        public CustormerResigter()
        {
            InitializeComponent();
            cbRoomType.SelectionChanged += RoomTypeOrBed_Changed;
            cbBed.SelectionChanged += RoomTypeOrBed_Changed;
            cbRoomNo.SelectionChanged += CbRoomNo_SelectionChanged;
        }

        private void RoomTypeOrBed_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (cbRoomType.SelectedItem is ComboBoxItem roomTypeItem &&
                cbBed.SelectedItem is ComboBoxItem bedItem)
            {
                string roomType = roomTypeItem.Content.ToString();
                string bed = bedItem.Content.ToString();

                var rooms = _service.GetAvailableRoomNumbers(roomType, bed);
                cbRoomNo.ItemsSource = rooms;
            }
        }

        private void CbRoomNo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbRoomNo.SelectedItem != null)
            {
                var room = _service.GetRoomByRoomNo(cbRoomNo.SelectedItem.ToString());
                if (room != null)
                {
                    txtPrice.Text = room.Price.ToString();
                }
            }
        }

        private void AllotRoom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validate mobile
                if (!long.TryParse(txtMobile.Text, out long mobile))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ!", "Lỗi nhập liệu", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Validate Gender
                var genderItem = cbGender.SelectedItem as ComboBoxItem;
                if (genderItem == null)
                {
                    MessageBox.Show("Vui lòng chọn giới tính!", "Lỗi nhập liệu", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Validate Room No
                if (cbRoomNo.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn số phòng!", "Lỗi nhập liệu", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Lấy thông tin phòng
                var selectedRoomNo = cbRoomNo.SelectedItem.ToString();
                var room = _service.GetRoomByRoomNo(selectedRoomNo);
                if (room == null)
                {
                    MessageBox.Show("Phòng được chọn không tồn tại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Tạo customer mới
                Customer c = new Customer
                {
                    Cname = txtName.Text,
                    Mobile = mobile,
                    Nationality = txtNationality.Text,
                    Gender = genderItem.Content.ToString(),
                    Dob = (dpDOB.SelectedDate ?? DateTime.Now).ToString("yyyy-MM-dd"),
                    Idproof = txtIDProof.Text,
                    Address = txtAddress.Text,
                    Checkin = (dpCheckIn.SelectedDate ?? DateTime.Now).ToString("yyyy-MM-dd"),
                    Roomid = room.Roomid,
                     Checkout = "NO"
                };

                _service.RegisterCustomer(c);
                MessageBox.Show("Đã cấp phòng thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        
    }
}
