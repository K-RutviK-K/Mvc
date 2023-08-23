using System;
using System.Collections.Generic;

namespace mvcTwo.Models;

public partial class Department
{
    public int DptId { get; set; }

    public string DptName { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
