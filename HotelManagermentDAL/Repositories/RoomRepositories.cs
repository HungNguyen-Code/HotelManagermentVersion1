using HotelManagermentDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagermentDAL.Repositories
{
   public class RoomRepositories
    {
        private HotelManagementV5Context _context = new HotelManagementV5Context();

        public List<Room> GetAll() => _context.Rooms.OrderBy(r => r.RoomNo).ToList();
        public void Add(Room x)
        {
            _context.Rooms.Add(x);
            _context.SaveChanges();
        }
        public bool Exists(string roomNo) => _context.Rooms.Any(r => r.RoomNo == roomNo);
    }
}

