using IRepositorySampleConsoleLab1_DotNet.Core.Domain;
using IRepositorySampleConsoleLab1_DotNet.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new RepositoryContext()))
            {
                Console.WriteLine("Adding Obtainings with the insertIntoObtainings stored procedure....");
                List<Obtaining> obtainings = new List<Obtaining>()
                {
                    new Obtaining{WorkerId = 1, FinderId = 1, ActTime = "2021-10-13", FindingId = 1},
                    new Obtaining{WorkerId = 2, FinderId = 1, ActTime = "2021-10-28", FindingId = 2},
                    new Obtaining{WorkerId = 1, FindingId = 3, FinderId = 2, ActTime = "2021-09-20"}
                };
                unitOfWork.Obtainings.AddRange(obtainings);
                Console.WriteLine("Obtainings are added...");
                Console.ReadKey();
                Console.WriteLine("Trying to add obtaining with the finding that was already obtained...");
                var obtaining = new Obtaining { FinderId = 2, FindingId = 2, WorkerId = 2, ActTime = "2021-09-08" };
                unitOfWork.Obtainings.Add(obtaining);
                Console.WriteLine("Tryied to add an obtaining, but this finding was already Obtained");
                Console.ReadKey();
                /////////////////////////////////////////////////
                Console.WriteLine("Adding Extradictions by using the insertIntoExtradictions stored procedure...");
                List<Extradiction> extradictions = new List<Extradiction>
                {
                    new Extradiction{FindingId = 1, OwnerId = 1, WorkerId = 1, ActTime = "2021-10-21" },
                    new Extradiction{FindingId = 2, OwnerId = 4, WorkerId = 1, ActTime = "2021-10-23" },
                    new Extradiction{FindingId = 3, OwnerId = 3, WorkerId = 2, ActTime = "2021-11-24" },
                };
                unitOfWork.Extradictions.AddRange(extradictions);
                Console.WriteLine("Extradictions have been already added");
                Console.ReadKey();
                ///////////////////////////////////////////////
                Console.WriteLine("Example of using the get stored procedure:");
                Console.WriteLine("Trying to get the worker with the specified identifier...");
                Worker worker = unitOfWork.Workers.Get(1);
                Console.WriteLine("Retrived worker data: " + worker.Name + " " + worker.Surname);
                Console.ReadKey();
                //////////////////////////////////////////////
                Console.WriteLine("Example of using the getALL stored procedure:");
                Console.WriteLine("Trying to get all Owners that are in our database...");
                IEnumerable<Owner> owners = unitOfWork.Owners.GetAll();
                foreach(var owner in owners)
                    Console.WriteLine(owner.Name + " " + owner.Surname);
                Console.ReadKey();
                /////////////////////////////////////////////
                Console.WriteLine("Example of using the getAllKeywordsByFinding stored procedure:");
                Console.WriteLine("Trying to get all keywords by the specified finding.....");
                IEnumerable<Keyword> keywords = unitOfWork.Findings.getAllKeywords(new Finding { FindingId = 1 });
                foreach(var keyword in keywords)
                    Console.WriteLine(keyword.Word);
                Console.ReadKey();
                ///////////////////////////////////////////////
                Console.WriteLine("Example of using the getActionByDate stored procedure:");
                Console.WriteLine("Trying to get all obtainings that were done in October 2021...");
                IEnumerable<Obtaining> obtainingsByDate = unitOfWork.Obtainings.getObtainingsByDate("2021", "10", null);
                foreach(var obt in obtainingsByDate)
                {
                    var Worker = unitOfWork.Workers.Get(obt.WorkerId);
                    var Finder = unitOfWork.Finders.Get(obt.FinderId);
                    var Finding = unitOfWork.Findings.Get(obt.FindingId);
                    Console.WriteLine(Finding.Name = "was found by " + Finder.Name + " " + Finder.Surname + 
                        " was taken into storage by " + Worker.Name + " " + Worker.Surname );
                }
                Console.ReadKey();
                //////////////////////////////////////////////////
                Console.WriteLine("Example of using the getPeopleWhoBroughtMoreThanOneItem function:");
                Console.WriteLine("Trying to get all people who brought more or equal to two items.....");
                IEnumerable<Finder> finders = unitOfWork.Finders.GetFindersByNumberOfObtainings(2);
                foreach(var finder in finders)
                    Console.WriteLine(finder.Name + " " + finder.Surname);
                Console.ReadKey();
                //////////////////////////////////////////////////
                Console.WriteLine("Example of using the getNumberOfWorkersAction function:");
                Console.WriteLine("Trying to get number of actions carried out by the worker with WorkerId = 1...");
                Console.WriteLine("Actions number ->" + unitOfWork.Workers.GetNumberOfPerformedActions(new Worker { WorkerId = 1}));
                Console.ReadKey();
            }
        }
    }
}
