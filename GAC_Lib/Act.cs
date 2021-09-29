﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostAndFound_LIB
{
    public abstract class Act
    {

        private int id;
        public int Id
        {
            get => id;
            set => id = value;
        }
        private DateTime actTime;
        private Finding finding;
        private Worker worker;
        public Worker Worker {
            get => worker;
            set => worker = value;
        }
        public Finding Finding {
            get => finding;
            set => finding = value;
        }
        public DateTime  ActTime
        {
            get => actTime;
            set => actTime = value;
        }
        public Act(DateTime actTime, Worker worker, Finding finding, int Id)
        {
            this.ActTime = actTime;
            this.Finding = finding;
            this.Worker = worker;
            this.Id = Id;
        }
    }
}
