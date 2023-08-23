using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mvcTwo.Models;

public partial class User
{
    public int UserId { get; set; }

    [Required(ErrorMessage ="Email is Required"),EmailAddress(ErrorMessage ="Wrong Email")]
    public string Email { get; set; } = null!;
    [Required(ErrorMessage = "Password is Required")]
    [MinLength(5,ErrorMessage ="Too Short"),MaxLength(10,ErrorMessage ="Too Long")]
    public string? Password { get; set; }
    [Required(ErrorMessage = "Name is Required")]
    public string Name { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string? Gender { get; set; }

    public int? Contact { get; set; }

    public string? Address { get; set; }

    public int? DptId { get; set; }

    public virtual Department? Dpt { get; set; }
}
