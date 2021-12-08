using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lab_4_Dot_Net.Core.DTO
{
    public class LoginDTO
    {
        [Required]
        [MaxLength(30)]
        [MinLength(8)]
        public string Login { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(8)]
        public string Passsword { get; set; }
    }
}