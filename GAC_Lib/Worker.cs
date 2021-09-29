using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostAndFound_LIB
{
    public class Worker : Person
    {
        private DateTime firstDay;
        private DateTime lastDay;
        private Office office;

        public DateTime FirstDay{
            get => firstDay;
            set => firstDay = value;
        }
        public DateTime LastDay {
            get => lastDay;
            set => lastDay = value;
        }
        public Office Office {
            get => office;
            set => office = value;
        }
        public IList<WorkDay> WorkDays { get; set; }

        public Worker(string Name, string Surname, DateTime Birthday, List<WorkDay> workDays, Office office, int Id) 
            : base(Name, Surname, Birthday, Id)
        {
            this.WorkDays = workDays;
            this.Office = office;
        }
    }
}
