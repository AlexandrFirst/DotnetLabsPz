using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostAndFound_LIB
{
    public class Finding
    {
        private string name;
        private string description;
        public string Name {
            get => name;
            set => name = value;
        }
        public ICollection<string> KeyWords { get; set; }
        public string Description {
            get => description;
            set => description = value;
        }
        public Finding(List<string> KeyWords, string Description, string Name)
        {
            this.KeyWords = KeyWords;
            this.Description = Description;
            this.Name = Name;
        }
    }
}
