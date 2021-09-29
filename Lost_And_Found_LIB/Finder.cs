using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lost_And_Found_LIB
{
    public class Finder : Person
    {
        public Finder(string Name, string Surname, DateTime Birthday, int Id) : base(Name, Surname, Birthday, Id)
        {
        }
    }
}
