using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lost_And_Found_LIB
{
    public class Office
    {
        private MyStorage myStorage;
        private Storage storage;
        private Notifications notifications;
        private MenuSupporter menuSupporter;
        public MenuSupporter MenuSupporter
        {
            get => menuSupporter;
            set => menuSupporter = value;
        }
        public Notifications Notifications
        {
            get => notifications;
            set => notifications = value;
        }
        public Storage Storage
        {
            get => storage;
            set => storage = value;
        }
        public MyStorage MyStorage
        {
            get => myStorage;
            set => myStorage = value;
        }
        public Office()
        {
            storage = new Storage();
            notifications = new Notifications();
            menuSupporter = new MenuSupporter(this);
            //Worker worker = new Worker("Oleksii", "Selevych1", new DateTime(2002, 04, 19), 1);
            //Finding finding = new Finding("Some desctiption", "IPhone22", 1);
            //Finder finder = new Finder("Oleksandr", "Logvinov", new DateTime(2002, 6, 12), 1);
            storage.NotifyEvent += notifications.TextMessage;
            storage.GetFullName = MyActions.GetPersonFullName;
            //storage.Obtain(DateTime.Now, worker, finding, finder);
            myStorage = new MyStorage();
            menuSupporter.DrawMenu();
        }
    }
}
