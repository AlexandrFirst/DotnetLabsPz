using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostAndFound_LIB
{
    public static class Seeder
    {
        public static Office Seed()
        {
            Office office = new Office(new List<Obtaining>(), new List<Extradiction>());
            var owners = new List<Owner>()
            {
                new Owner("Oleksii", "Selevych", new DateTime(2002, 4, 19)),
                new Owner("Oleksii1", "Selevych1", new DateTime(2002, 4, 19)),
                new Owner("Oleksii2", "Selevych2", new DateTime(2002, 4, 19)),
                new Owner("Oleksii3", "Selevych3", new DateTime(2002, 4, 19))

            };
            var finders = new List<Finder>()
            {
                new Finder("Oleksandr", "Logvinov", new DateTime(2002, 7, 31)),
                new Finder("Oleksandr1", "Logvinov1", new DateTime(2002, 7, 31)),
                new Finder("Oleksandr2", "Logvinov2", new DateTime(2002, 7, 31)),
                new Finder("Oleksandr3", "Logvinov3", new DateTime(2002, 7, 31))
            };
            var workers = new List<Worker>() {
                new Worker("Anton",
                            "Mazuritskiy",
                            new DateTime(2000, 4, 25),
                            new List<WorkDay>() {WorkDay.Monday, WorkDay.Wednesday, WorkDay.Friday },
                            office),
                new Worker("Anton1",
                            "Mazuritskiy1",
                            new DateTime(2000, 4, 25),
                            new List<WorkDay>() {WorkDay.Monday, WorkDay.Wednesday, WorkDay.Friday },
                            office),
                new Worker("Artem",
                            "Vredniy",
                            new DateTime(1998, 4, 20),
                            new List<WorkDay>() {WorkDay.Monday, WorkDay.Wednesday, WorkDay.Friday },
                            office),
            };
            var findings = new List<Finding>()
            {
                new Finding(new List<string>() { "Valuable1", "Valuable2", "Valuable3"}, "So valuable", "IPhone 22"),
                new Finding(new List<string>() { "Valuable1", "Valuable2", "Valuable3"}, "So valuable", "IPhone 23"),
                new Finding(new List<string>() { "Valuable1", "Valuable2", "Valuable3"}, "So valuable", "IPhone 24"),
            };
            for(int i = 0; i< findings.Count; i++)
            {
                office.Obtainings.Add(new Obtaining(DateTime.Now, workers[i], findings[i], finders[i]));
                office.Extradictions.Add(new Extradiction(DateTime.Now, workers[i], findings[i], owners[i]));
            }
            return office;
        }
    }
}
