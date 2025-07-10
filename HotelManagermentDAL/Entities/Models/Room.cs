using System;
using System.Collections.Generic;

namespace HotelManagermentDAL.Models;

public partial class Room
{
    public int Roomid { get; set; }

    public string RoomNo { get; set; } = null!;

    public string RoomType { get; set; } = null!;

    public string Bed { get; set; } = null!;

    public long Price { get; set; }

    public string? Booked { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
