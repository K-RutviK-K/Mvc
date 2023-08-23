using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jwtApi.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;
    [Required(ErrorMessage ="asdada")]
    public string? Password { get; set; }

    public string Name { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string? Gender { get; set; }

    public int? Contact { get; set; }

    public string? Address { get; set; }
}
