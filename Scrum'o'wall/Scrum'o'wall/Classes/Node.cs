/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   Node.cs
 * Desc.    :   This file contains the structure of the Node class   
 */
using System.Collections.Generic;

namespace Scrum_o_wall.Classes
{
    public class Node
    {

        private readonly int id;
        private Node previous;
        private int? previousId;
        private int mindmapId;
        private MindMap mindMap;

        public Node(int anId, string aName, int? aPreviousId, int aMindmapId)
        {
            id = anId;
            Name = aName;
            previousId = aPreviousId;
            mindmapId = aMindmapId;
        }

        public int Id => id;
        public string Name { get; set; }
        public int? PreviousId => previousId;
        public int Level
        {
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
            }
        }
        public Node Previous
        {
            get => previous;
            set
            {
                previous = value;
                if (value == null)
                {
                    previousId = null;
                }
                else
                {
                    previousId = value.Id;
                }
            }
        }
        public int MindmapId => mindmapId;
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
            if (aList == null)
            {
                aList = new List<Node>
                {
                    this
                };
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
            return Name;
        }

    }
}
