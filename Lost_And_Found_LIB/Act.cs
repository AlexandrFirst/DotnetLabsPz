using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lost_And_Found_LIB
{
    public abstract class Act
    {
        private DateTime actTime;
        private Finding finding;
        private Worker worker;
        public Worker Worker
        {
            set => worker = value;
            get => worker;
        }
        public Finding Finding
        {
            get => finding;
            set => finding = value;
        }
        public DateTime ActTime
        {
            get => actTime;
            set => actTime = value;
        }
        public Act(DateTime actTime, Worker worker, Finding finding)
        {
            this.ActTime = actTime;
            this.Finding = finding;
            this.Worker = worker;
        }
    }
}
