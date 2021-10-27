using IRepositorySampleConsoleLab1_DotNet.Core.Domain;
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
            //Worker worker = new Worker()
            //{
            //    Name = "Sasha",
            //    Surname = "Krivoshapko",
            //    Birthday = "2000-04-13"
            //};
            RepositoryContext context = new RepositoryContext();
            WorkersRepository workersRepository = new WorkersRepository(context, "Workers");
            IEnumerable<Worker> findResult = workersRepository.Find(w => w.Name.Contains("1"));
            foreach(Worker w in findResult)
            Console.WriteLine(w.Name + " " + w.Surname);
            //workersRepository.Add(worker);
        }
    }
}
