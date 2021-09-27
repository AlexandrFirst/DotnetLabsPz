using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostAndFound_LIB
{
    public class Office
    {
        public IList<Obtaining> Obtainings { get; set; }

        public IList<Extradiction> Extradictions { get; set; }

        public Office(List<Obtaining> obtainings, List<Extradiction> extradictions)
        {
            this.Obtainings = obtainings;
            this.Extradictions = extradictions;
        }
        public void PrintObtainigsInfo()
        {
            Console.WriteLine("All obtainings in LostAndFound:");
            Console.WriteLine("---------------------------------------");
            for(int i = 0; i < Obtainings.Count; i++)
            {
                Console.WriteLine("{0}) found by : {1}, finding name : {2}, worker name : {3}", 
                                    i + 1,
                                    Obtainings[i].Finder.Name + " " + Obtainings[i].Finder.Surname,
                                    Obtainings[i].Finding.Name,
                                    Obtainings[i].Worker.Name + " " + Obtainings[i].Worker.Surname);
            }
        }
    }
}
