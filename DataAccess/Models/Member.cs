﻿using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Member
{
    public int MemberId { get; set; }

    public string Email { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Order> Orderrs { get; set; } = new List<Order>();

    public override string? ToString()
    => $"{MemberId} {Email} {CompanyName} {City} {Country} {Password}";
}
