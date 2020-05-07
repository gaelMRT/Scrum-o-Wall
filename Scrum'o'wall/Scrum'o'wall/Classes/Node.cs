/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   Node.cs
 * Desc.    :   This file contains the structure of the Node class   
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum_o_wall.Classes
{
    public class Node
    {
        
        int id;
        int? previousId;
        int mindmapId;

        public Node(int anId, string aName, int? aPreviousId, int aMindmapId)
        {
            this.id = anId;
            this.Name = aName;
            this.previousId = aPreviousId;
            this.mindmapId = aMindmapId;
        }

        public int Id { get => id;  }
        public string Name { get; set; }
        public int PreviousId { get => (previousId == null ? 0 : (int)previousId);  }
        public int MindmapId { get => mindmapId;  }
        public List<Node> Childrens { get; set; } = new List<Node>();
        public override string ToString()
        {
            return Name;
        }

    }
}
