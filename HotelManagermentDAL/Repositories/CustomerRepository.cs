using HotelManagermentDAL.Entities.Models;
using HotelManagermentDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagermentDAL.Repositories
{
    public class CustomerRepository
    {
        private  HotelManagementV5Context _context;

        public CustomerRepository()
        {
            _context = new HotelManagementV5Context();
        }

        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public List<string> GetAvailableRoomNumbers(string roomType, string bed)
        {
            return _context.Rooms
                .Where(r => r.RoomType == roomType && r.Bed == bed && r.Booked == "NO")
                .Select(r => r.RoomNo)
                .ToList();
        }

        public Room? GetRoomByRoomNo(string roomNo)
        {
            return _context.Rooms.FirstOrDefault(r => r.RoomNo == roomNo);
        }

        public void UpdateRoomStatus(int roomId, string status)
        {
            var room = _context.Rooms.Find(roomId);
            if (room != null)
            {
                room.Booked = status;
                _context.SaveChanges();
            }
        }
        public List<Customer> GetAllCustomers() =>
        _context.Customers.ToList();

        //   public List<Customer> GetInHotelCustomers() =>
        //_context.Customers.Where(c => c.Checkout == null).ToList();

        //   public List<Customer> GetCheckoutCustomers() =>
        //       _context.Customers.Where(c => c.Checkout != null).ToList();
        public List<CustomerDisplay> GetInHotelDisplays()
        {
            var result = from c in _context.Customers
                         join r in _context.Rooms on c.Roomid equals r.Roomid
                         where c.Checkout == null
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

        public List<CustomerDisplay> GetCheckedOutDisplays()
        {
            var result = from c in _context.Customers
                         join r in _context.Rooms on c.Roomid equals r.Roomid
                         where c.Checkout != null
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


        public void UpdateCheckout(int customerId, string checkoutDate)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Cid== customerId);
            if (customer != null)
            {
                customer.Checkout = checkoutDate;
                _context.SaveChanges();
            }
        }
        public void UpdateRoomBookedStatus(string roomNo, string status)
        {
            var room = _context.Rooms.FirstOrDefault(r => r.RoomNo == roomNo);
            if (room != null)
            {
                room.Booked = status;
                _context.SaveChanges();
            }
        }
        public List<Room> GetAllRooms()
        {
            return _context.Rooms.ToList();
        }



    }
}


