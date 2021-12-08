using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lab3_Dot_Net.Core.Domain.RoleMasters
{
    [Table("RoleMasters")]
    public class RoleMaster
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}