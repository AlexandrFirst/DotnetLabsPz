using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lost_And_Found_LIB
{
    public class MyStorage
    {
        private List<Worker> workers;
        private List<Owner> owners;
        private List<Finder> finders;
        private List<Finding> findings;

        public List<Worker> Workers { get => workers; }
        public List<Owner> Owners { get => owners; }

        public List<Finder> Finders { get => finders; }
        public List<Finding> Findings { get => findings; }
        public MyStorage()
        {
            InitializeWokrers();
            InitializeOwners();
            InitializeFinders();
            InitializeFindings();
        }

        private void InitializeFindings()
        {
            findings = new List<Finding>()
            {
                new Finding("So valuable", "IPhone 22"),
                new Finding( "So valuable", "IPhone 23"),
                new Finding("So valuable", "IPhone 24" ),
                new Finding("So valuable", "IPhone 25"),
                new Finding("So valuable", "IPhone 26"),
                new Finding("So valuable", "IPhone 27"),
                new Finding("So valuable", "IPhone 28"),
                new Finding("So valuable", "IPhone 29")
            };
        }

        private void InitializeOwners()
        {
            owners = new List<Owner>()
            {
                new Owner("Oleksii", "Selevych", new DateTime(2002, 4, 19), 1),
                new Owner("Oleksii1", "Selevych1", new DateTime(2002, 4, 19), 2),
                new Owner("Oleksii2", "Selevych2", new DateTime(2002, 4, 19), 3),
                new Owner("Oleksii3", "Selevych3", new DateTime(2002, 4, 19), 4)
            };
        }
        private void InitializeFinders()
        {
            finders = new List<Finder>()
            {
                new Finder("Oleksandr", "Logvinov", new DateTime(2002, 7, 31), 1),
                new Finder("Oleksandr1", "Logvinov1", new DateTime(2002, 7, 31), 2),
                new Finder("Oleksandr2", "Logvinov2", new DateTime(2002, 7, 31), 3),
                new Finder("Oleksandr3", "Logvinov3", new DateTime(2002, 7, 31), 4)
            };
        }
        private void InitializeWokrers()
        {
            workers = new List<Worker>()
            {
                new Worker("Anton",
                            "Mazuritskiy",
                            new DateTime(2000, 4, 25),
                            1),
                new Worker("Anton1",
                            "Mazuritskiy1",
                            new DateTime(2000, 4, 25),
                            2),
                new Worker("Artem",
                            "Vredniy",
                            new DateTime(1998, 4, 20),
                            3),
                new Worker("Artem1",
                            "Vredniy1",
                            new DateTime(1998, 4, 20),
                            4),
            };
        }
    }
}
