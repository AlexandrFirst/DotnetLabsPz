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
        
        public void PrintThingsWithoutOwners()
        {
            var issuedGoodsIdentifiers = Extradictions.Select(e => e.Finding.Id).ToList();
            var thingsWithoutOwners = Obtainings.Where(o => !Extradictions.Select(e => e.Finding.Id).ToList().Contains(o.Finding.Id)).ToList();
            Console.WriteLine("Things in LostAndFound without owners");
            Console.WriteLine("-------------------------------------------------");
            foreach (var thing in thingsWithoutOwners)
                Console.WriteLine(thing.Finding.Id  + " " + thing.Finding.Name);
        }
        public void PrintWorkersObtainingsExtradictionsCount()
        {
            var workerObtainings = Obtainings.GroupBy(o => o.Worker.Id)
                                             .Select(g => new { WorkerId = g.Key, ObtaininsCount = g.Count() });
            var workerExtradictions = Extradictions.GroupBy(e => e.Worker.Id)
                                                   .Select(g => new {WorkerId = g.Key, ExtradictionsCount = g.Count() });
            var workerExtradictionsAndObtainingsInfo = workerObtainings.Join(
                                                            workerExtradictions,
                                                            wo => wo.WorkerId,
                                                            we => we.WorkerId,
                                                            (wo, we) => new
                                                            {
                                                                WorkerId = wo.WorkerId,
                                                                Extradictions = we.ExtradictionsCount,
                                                                Obtainings = wo.ObtaininsCount
                                                            });
            Console.WriteLine("Volume of work performed by each employee:");
            Console.WriteLine("   Employee name     |     Obtainings      |     Extradictions   ");
            Console.WriteLine("-------------------------------------------------------------------");
            foreach (var info in workerExtradictionsAndObtainingsInfo)
            {
                var workerInitials = Obtainings.FirstOrDefault(o => o.Worker.Id == info.WorkerId).Worker.Name + " " + Obtainings.FirstOrDefault(o => o.Worker.Id == info.WorkerId).Worker.Surname;
                Console.WriteLine("{0}|{1}|{2}", workerInitials.FitWithLength(), info.Obtainings.ToString().FitWithLength(), info.Extradictions.ToString().FitWithLength());
            }
        }
        public void printCountOfThingsByKeyWords()
        {
            List<string> keywords = Obtainings.SelectMany(o => o.Finding.KeyWords).Distinct().ToList();
            //var thingsByKeywordsCount = Obtainings.GroupJoin();
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
