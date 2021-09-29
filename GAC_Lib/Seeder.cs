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
                new Owner("Oleksii", "Selevych", new DateTime(2002, 4, 19), 1),
                new Owner("Oleksii1", "Selevych1", new DateTime(2002, 4, 19), 2),
                new Owner("Oleksii2", "Selevych2", new DateTime(2002, 4, 19), 3),
                new Owner("Oleksii3", "Selevych3", new DateTime(2002, 4, 19), 4)

            };
            var finders = new List<Finder>()
            {
                new Finder("Oleksandr", "Logvinov", new DateTime(2002, 7, 31), 1),
                new Finder("Oleksandr1", "Logvinov1", new DateTime(2002, 7, 31), 2),
                new Finder("Oleksandr2", "Logvinov2", new DateTime(2002, 7, 31), 3),
                new Finder("Oleksandr3", "Logvinov3", new DateTime(2002, 7, 31), 4)
            };
            var workers = new List<Worker>() {
                new Worker("Anton",
                            "Mazuritskiy",
                            new DateTime(2000, 4, 25),
                            new List<WorkDay>() {WorkDay.Monday, WorkDay.Wednesday, WorkDay.Friday },
                            office,
                            1),
                new Worker("Anton1",
                            "Mazuritskiy1",
                            new DateTime(2000, 4, 25),
                            new List<WorkDay>() {WorkDay.Monday, WorkDay.Wednesday, WorkDay.Friday },
                            office,
                            2),
                new Worker("Artem",
                            "Vredniy",
                            new DateTime(1998, 4, 20),
                            new List<WorkDay>() {WorkDay.Monday, WorkDay.Wednesday, WorkDay.Friday },
                            office,
                            3),
            };
            var findings = new List<Finding>()
            {
                new Finding(new List<string>() { "Valuable1", "Valuable2", "Valuable3"}, "So valuable", "IPhone 22", 1),
                new Finding(new List<string>() { "Valuable1", "Valuable2", "Valuable3"}, "So valuable", "IPhone 23", 2),
                new Finding(new List<string>() { "Valuable1", "Valuable2", "Valuable3"}, "So valuable", "IPhone 24", 3),
                new Finding(new List<string>() { "Valuable1", "Valuable2", "Valuable3"}, "So valuable", "IPhone 25", 4),
                new Finding(new List<string>() { "Valuable1", "Valuable2", "Valuable3"}, "So valuable", "IPhone 26", 5),
                new Finding(new List<string>() { "Valuable1", "Valuable2", "Valuable3"}, "So valuable", "IPhone 27", 6),
                new Finding(new List<string>() { "Valuable1", "Valuable2", "Valuable3"}, "So valuable", "IPhone 28", 7),
                new Finding(new List<string>() { "Valuable1", "Valuable2", "Valuable3"}, "So valuable", "IPhone 29", 8),
            };
            for(int i = 0; i< findings.Count; i++)
            {
                office.Obtainings.Add(new Obtaining(DateTime.Now, workers.GetRandom(), findings[i], finders.GetRandom(), i + 1));
                if(i % 2 == 0)
                    office.Extradictions.Add(new Extradiction(DateTime.Now, workers.GetRandom(), findings[i], owners.GetRandom(), i + 1));
            }
            return office;
        }
    }
}
