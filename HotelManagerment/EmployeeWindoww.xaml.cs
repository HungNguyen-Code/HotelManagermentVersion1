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
    /// Interaction logic for EmployeeWindoww.xaml
    /// </summary>
    public partial class EmployeeWindoww : Window
    {
        public EmployeeWindoww()
        {
            InitializeComponent();
            LoadEmployees();
        }
        private readonly EmployeeService _service = new();

        

        private void LoadEmployees()
        {
            dgEmployeeList.ItemsSource = null;
            dgEmployeeList.ItemsSource = _service.GetAllEmployees();
        }

        private void ClearForm()
        {
            txtName.Text = "";
            txtMobile.Text = "";
            cbGender.SelectedIndex = -1;
            txtEmail.Text = "";
            txtUsername.Text = "";
            txtPassword.Password = "";
            cbRole.SelectedIndex = -1;

        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validate Mobile
                if (!long.TryParse(txtMobile.Text.Trim(), out long mobile))
                {
                    MessageBox.Show("Invalid mobile number", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Validate Gender
                if (cbGender.SelectedItem is not ComboBoxItem genderItem)
                {
                    MessageBox.Show("Please select gender", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Validate other fields
                if (string.IsNullOrWhiteSpace(txtName.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtUsername.Text) ||
                    string.IsNullOrWhiteSpace(txtPassword.Password))
                {
                    MessageBox.Show("Please fill in all required fields", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (cbRole.SelectedItem is not ComboBoxItem roleItem)
                {
                    MessageBox.Show("Please select a role", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }


                var emp = new Employee
                {
                    Ename = txtName.Text.Trim(),
                    Mobile = mobile,
                    Gender = genderItem.Content.ToString(),
                    Emailid = txtEmail.Text.Trim(),
                    Username = txtUsername.Text.Trim(),
                    Pass = txtPassword.Password.Trim(),
                    Role = roleItem.Content.ToString()
                };


                _service.Register(emp);

                MessageBox.Show("Employee registered successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                LoadEmployees();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
             if (dgEmployeeList.SelectedItem is Employee selected)
            {
                _service.Delete(selected.Eid);
                LoadEmployees();
                MessageBox.Show("Employee deleted.");
            }
        }
    }
    }


