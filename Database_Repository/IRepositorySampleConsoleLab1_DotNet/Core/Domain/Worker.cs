using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositorySampleConsoleLab1_DotNet.Core.Domain
{
    public class Worker
    {
        [Key]
        public int WorkerId { get; set; }
        public string Birthday { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        //private Worker(string Name, string Surname, string Birthday)
        //{
        //    this.Name = Name;
        //    this.Surname = Surname;
        //    this.Birthday = Birthday;
        //}
        //public Worker(string Name, string Surname, string Birthday, int WorkerId) : this(Name, Surname, Birthday)
        //{
        //    this.WorkerId = WorkerId;
        //}
    }
}
