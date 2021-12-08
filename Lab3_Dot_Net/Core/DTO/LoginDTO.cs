using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab3_Dot_Net.Core.DTO
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
        public string Password { get; set; }
    }
}