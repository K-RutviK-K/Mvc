using System;
using System.Collections.Generic;

namespace mvcSix.Models;

public  class User
{
    public int UserId { get; set; }
    
    public string Email { get; set; } = null!;

    public string? Password { get; set; }

    public string Name { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string? Gender { get; set; }

    public int? Contact { get; set; }

    public string? Address { get; set; }
}
