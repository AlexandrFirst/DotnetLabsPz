using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lost_And_Found_LIB
{
    public class MyActions
    {
       public static void ObtainAction(Office office) => 
            office.Storage.Obtain(DateTime.Now,
                                    office.MyStorage.Workers.GetRandom(),
                                    office.MyStorage.Findings.GetRandom(),
                                    office.MyStorage.Finders.GetRandom());
        public static void ExtradictAction(Office office)
        {
            office.Storage.Extradict(DateTime.Now,
                                     office.MyStorage.Workers.GetRandom(),
                                     office.MyStorage.Findings.GetRandom(),
                                     office.MyStorage.Owners.GetRandom());
        }
        public static string GetPersonFullName(Person person) =>
            person.Name + " " + person.Surname;
        public static void DisplayAllObtainings(Office office)
        {
            Console.WriteLine("Things obtained: ");
            Console.WriteLine("        Time        |         Finder      |       Finding      |        Worker       ");
            Console.WriteLine("--------------------------------------------------------------------------------------");
            foreach(var obtainedThing in office.Storage.Obtainings)
            {
                Console.WriteLine("{0}|{1}|{2}|{3}",obtainedThing.ActTime.TimeOfDay.ToString().FitWithLength(),
                                                    GetPersonFullName(obtainedThing.Finder).FitWithLength(),
                                                    obtainedThing.Finding.Name.FitWithLength(),
                                                    GetPersonFullName(obtainedThing.Worker).FitWithLength());
            }
        }
        public static void DisplayAllExtradictions(Office office)
        {
            Console.WriteLine("Things extradicted: ");
            Console.WriteLine("        Time        |         Owner      |       Finding      |        Worker       ");
            Console.WriteLine("--------------------------------------------------------------------------------------");
            foreach (var obtainedThing in office.Storage.Extradictions)
            {
                Console.WriteLine("{0}|{1}|{2}|{3}", obtainedThing.ActTime.TimeOfDay.ToString().FitWithLength(),
                                                    GetPersonFullName(obtainedThing.Owner).FitWithLength(),
                                                    obtainedThing.Finding.Name.FitWithLength(),
                                                    GetPersonFullName(obtainedThing.Worker).FitWithLength());
            }
        }
    }
}
