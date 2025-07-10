using System;
using System.Collections.Generic;

namespace HotelManagermentDAL.Models;

public partial class Employee
{
    public int Eid { get; set; }

    public string Ename { get; set; } = null!;

    public long Mobile { get; set; }

    public string Gender { get; set; } = null!;

    public string Emailid { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Pass { get; set; } = null!;
    public string Role { get; set; }
= null!;
}
