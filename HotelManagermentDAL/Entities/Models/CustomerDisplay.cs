using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagermentDAL.Entities.Models
{
    public class CustomerDisplay
    {
        public int Cid { get; set; }
        public string Cname { get; set; }
        public long Mobile { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public string Checkin { get; set; }
        public string? Checkout { get; set; }
        public string Idproof { get; set; }
        public string Address { get; set; }

        public string RoomNo { get; set; }
        public string RoomType { get; set; }
        public string Bed { get; set; }
        public long Price { get; set; }
    }

}
