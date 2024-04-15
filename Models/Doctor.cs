using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class Doctor : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
        public string Specialaztion{ get; set; } = string.Empty;
    }
}