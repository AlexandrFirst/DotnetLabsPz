using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lost_And_Found_LIB
{
    public class Storage
    {
        // Могу использовать делегат для Obtaining и для 
        //Сделать делегат по типу GetPersonName для контрвариантности
        //Сделать делегат для презентации ковариантности с конструктором 
        public delegate void Notify(string message);
        public delegate string GetPersonFullName<T>(T param) where T : Person;
        public event Notify NotifyEvent;
        public GetPersonFullName<Person> GetFullName;

        private List<Obtaining> obtainings;
        private List<Extradiction> extradictions;
        public List<Obtaining> Obtainings {
            get => obtainings;
        }
        
        public List<Extradiction> Extradictions {
            get => extradictions;
        }
        public Storage()
        {
            obtainings = new List<Obtaining>();
            extradictions = new List<Extradiction>();
        }
        //public void StorageAction(Action<DateTime, Person, Finding, Person> del, DateTime actTime, Person p1, Finding finding, Person p2, string message)
        //{
        //    del?.Invoke(actTime, p1, finding, p2);
        //    NotifyEvent?.Invoke(message);
        //}
        public void Obtain(DateTime actTime, Worker worker, Finding finding, Finder finder)
        {
            if (worker != null && finding != null && finder != null)
            {
                Obtaining obtaining = new Obtaining(actTime, worker, finding, finder);
                obtainings.Add(obtaining);
                NotifyEvent?.Invoke($"New {finding.Name} was brought to the lost and found at {actTime.TimeOfDay} by {GetFullName?.Invoke(finder)}" +
                    $" and was taken to storage by {GetFullName?.Invoke(worker)} ");
                if (GetFullName.Target == null)
                    Console.WriteLine("The static method was invoked");
            }
            else
                NotifyEvent?.Invoke("Some error happened while obtaining the thing");
        }
        public void Extradict(DateTime actTime, Worker worker, Finding finding, Owner owner)
        {
            if (worker != null && finding != null && owner != null)
            {
                Extradiction extradiction = new Extradiction(actTime, worker, finding, owner);
                extradictions.Add(extradiction);
                NotifyEvent?.Invoke($"The {finding.Name} was given to owner : {GetFullName?.Invoke(owner)} at {actTime.TimeOfDay}" +
                    $"by {GetFullName(worker)}");
                if (GetFullName.Target == null)
                    Console.WriteLine("The static method was invoked");
            }
            else
                NotifyEvent?.Invoke("Some error happened while extadictiong the thing");
        }
    }
}
