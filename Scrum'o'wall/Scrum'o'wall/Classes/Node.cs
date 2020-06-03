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
using System.Windows.Navigation;

namespace Scrum_o_wall.Classes
{
    public class Node
    {
        
        int id;
        Node previous;
        int? previousId;
        int mindmapId;
        MindMap mindMap;

        public Node(int anId, string aName, int? aPreviousId, int aMindmapId)
        {
            this.id = anId;
            this.Name = aName;
            this.previousId = aPreviousId;
            this.mindmapId = aMindmapId;
        }

        public int Id { get => id;  }
        public string Name { get; set; }
        public int? PreviousId { get => previousId; }
        public int Level { 
            get
            {
                int lvl = 0;
                Node n = this;
                while (n.Previous != null)
                {
                    n = n.Previous;
                    lvl++;
                }
                return lvl;
            } }
        public Node Previous { get => previous;
            set
            {
                previous = value;
                if(value == null)
                {
                    previousId = null;
                }
                else
                {
                    previousId = value.Id;
                }
            }
        }
        public int MindmapId { get => mindmapId;  }
        public MindMap MindMap
        {
            get => mindMap;
            set
            {
                mindMap = value;
                mindmapId = value.Id;
            }
        }
        public List<Node> Childrens { get; set; } = new List<Node>();
        public List<Node> AllChildrens(List<Node> aList = null)
        {
            if(aList == null)
            {
                aList = new List<Node>();
                aList.Add(this);
            }
            aList.AddRange(Childrens);
            foreach (Node n in Childrens)
            {
                n.AllChildrens(aList);
            }
            return aList;
        }
        public override string ToString()
        {
            if(previous == null)
            {
                return Name;
            }
            else
            {
                return Name + " enfant de " + previous.Name;
            }
        }

    }
}
