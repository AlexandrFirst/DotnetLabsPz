using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostAndFound_LIB
{
    public class Obtaining : Act
    {
        private Finder finder;
        public Finder Finder
        {
            get => finder;
            set => finder = value;
        }
        public Obtaining(DateTime actTime, Worker worker, Finding finding, Finder finder) : base(actTime, worker, finding)
        {
            this.Finder = finder;
        }
    }
}
