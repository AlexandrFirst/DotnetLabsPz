using IRepositorySampleConsoleLab1_DotNet.Core.Domain;
using IRepositorySampleConsoleLab1_DotNet.Persistence;
using IRepositorySampleConsoleLab1_DotNet.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositorySampleConsoleLab1_DotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new RepositoryContext()))
            {
                //List<Keyword> keywords = unitOfWork.Findings.getAllKeywords(new Finding { FindingId = 2 }).ToList();
                //foreach(var keyWord in keywords)
                //{
                //    Console.WriteLine(keyWord.Word);
                //}
                //int numberOfActions = unitOfWork.Workers.GetNumberOfPerformedActions(new Worker { WorkerId = 1 });
                //Console.WriteLine(numberOfActions);

                IEnumerable<Finder> finders = unitOfWork.Finders.GetFindersByNumberOfObtainings(1);
                foreach(var finder in finders)
                    Console.WriteLine(finder.Name + " " + finder.Surname);


            }
        }
    }
}
