using HotelManagermentDAL.Entities.Models;
using HotelManagermentDAL.Models;
using HotelManagermentDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagermentBLL.Service
{
    public class CustomerService
    {
        private readonly CustomerRepository _repo;

        public CustomerService()
        {
            _repo = new CustomerRepository();
        }

        public void RegisterCustomer(Customer customer)
        {
            _repo.Add(customer);
            _repo.UpdateRoomStatus(customer.Roomid, "YES");
        }

        public List<string> GetAvailableRoomNumbers(string roomType, string bed)
        {
            return _repo.GetAvailableRoomNumbers(roomType, bed);
        }

        public Room? GetRoomByRoomNo(string roomNo)
        {
            return _repo.GetRoomByRoomNo(roomNo);
        }
        public List<Customer> GetAll() => _repo.GetAllCustomers();

        //public List<Customer> GetInHotel() => _repo.GetInHotelCustomers();

        //public List<Customer> GetCheckedOut() => _repo.GetCheckoutCustomers();
        public void CheckOutCustomer(int customerId, string roomNo, string checkoutDate)
        {
            _repo.UpdateCheckout(customerId, checkoutDate);
            _repo.UpdateRoomBookedStatus(roomNo, "NO");
        }
        public List<CustomerDisplay> GetCustomerWithRoomInfo()
        {
            var customers = _repo.GetAllCustomers();
            var rooms = _repo.GetAllRooms();

            var result = from c in customers
                         join r in rooms on c.Roomid equals r.Roomid
                         select new CustomerDisplay
                         {
                             Cid = c.Cid,
                             Cname = c.Cname,
                             Mobile = c.Mobile,
                             Nationality = c.Nationality,
                             Gender = c.Gender,
                             Checkin = c.Checkin,
                             Checkout = c.Checkout,
                             Idproof = c.Idproof,
                             Address = c.Address,
                             RoomNo = r.RoomNo,
                             RoomType = r.RoomType,
                             Bed = r.Bed,
                             Price = r.Price 
                         };

            return result.ToList();
        }
        public List<CustomerDisplay> GetInHotelDisplays() => _repo.GetInHotelDisplays();

        public List<CustomerDisplay> GetCheckedOutDisplays() => _repo.GetCheckedOutDisplays();





    }


}
