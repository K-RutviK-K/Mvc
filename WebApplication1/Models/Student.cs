using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Display(Name="Name"),Required(ErrorMessage = "Required Field")]
        public string StudentName { get; set; }
        public int Age { get; set; }
    }
}