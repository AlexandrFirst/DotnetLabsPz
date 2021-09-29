using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostAndFound_LIB
{
    public class Owner : Person
    {
        public Owner(string Name, string Surname, DateTime Birthday, int Id) : base(Name, Surname, Birthday, Id)
        {

        }
    }
}
