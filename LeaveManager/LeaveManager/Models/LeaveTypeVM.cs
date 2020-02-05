using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManager.Models
{
    public class LeaveTypeVM
    {
       

            public int Id { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            [Display(Name="Default Of Day")]
            [Range(1,25,ErrorMessage ="Please Enter A is 1-25")]
            public int DefaultDays { get; set; }
            [Display(Name = "Date Created")]
            public DateTime? DateCreated { get; set; }

      
    }
}
