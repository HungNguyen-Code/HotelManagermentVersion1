using HotelManagermentDAL.Models;
using HotelManagermentDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HotelManagermentBLL.Service
{
    public class RoomService
    {
        private  RoomRepositories _repo = new RoomRepositories();

        public List<Room> GetAllRooms() => _repo.GetAll();
        public void AddRoom(Room room) => _repo.Add(room);
        public bool IsRoomNumberExists(string roomNo) => _repo.Exists(roomNo);
    }

}
