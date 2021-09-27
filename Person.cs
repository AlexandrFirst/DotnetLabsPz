using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostAndFound_LIB
{
    public abstract class Person
    {
        private string name;
        private string surname;
        private DateTime birthday;
        public DateTime Birthday {
            get => birthday;
            set => birthday = value;
        }
        public string Name {
            get => name;
            set => name = value;
        }
        public string Surname {
            get => surname;
            set => surname = value;
        }
        public Person(string Name, string Surname, DateTime Birthday)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Birthday = Birthday;
        }
    }
}
