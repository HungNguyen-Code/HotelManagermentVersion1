using System;
using System.Collections.Generic;

namespace HotelManagermentDAL.Models;

public partial class Customer
{
    public int Cid { get; set; }

    public string Cname { get; set; } = null!;

    public long Mobile { get; set; }

    public string Nationality { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Dob { get; set; } = null!;

    public string Idproof { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Checkin { get; set; } = null!;

    public string? Checkout { get; set; }

    public int Roomid { get; set; }

    public string? Checkoutstatus { get; set; }

    public virtual Room Room { get; set; } = null!;
}
