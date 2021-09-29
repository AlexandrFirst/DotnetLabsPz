using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lost_And_Found_LIB
{
    public class Finding
    {
        private string name;
        private string description;
        public string Name
        {
            get => name;
            set => name = value;
        }
        public IList<string> KeyWords { get; set; }
        public string Description
        {
            get => description;
            set => description = value;
        } 
        public Finding(string Description, string Name)
        {
            KeyWords = new List<string>();
            this.Description = Description;
            this.Name = Name;
        }
    }
}
