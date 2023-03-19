using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
    }
}