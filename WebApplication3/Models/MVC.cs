using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class MVC
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
