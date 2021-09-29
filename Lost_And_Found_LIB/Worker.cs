using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lost_And_Found_LIB
{
    public class Worker : Person
    {
        public Worker(string Name, string Surname, DateTime Birthday, int Id)
           : base(Name, Surname, Birthday, Id) { }
    }
}
