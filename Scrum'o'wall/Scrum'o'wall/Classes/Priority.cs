using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum_o_wall.Classes
{
    public class Priority
    {
        int id;

        public Priority(int id, string name)
        {
            this.id = id;
            this.Name = name;
        }

        public int Id { get => id;}
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
