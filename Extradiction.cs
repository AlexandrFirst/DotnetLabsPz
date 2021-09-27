using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostAndFound_LIB
{
    public class Extradiction : Act
    {
        private Owner owner;
        public Owner Owner {
            get => owner;
            set => owner = value;
        }
        public Extradiction(DateTime actTime, Worker worker, Finding finding, Owner owner) : base(actTime, worker, finding)
        {
            this.Owner = owner;
        }
    }
}
