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
        string name;
        int previousId;
        int mindmapId;
        List<Node> childrens = new List<Node>();

        public Node(int anId, string aName, int aPreviousId, int aMindmapId)
        {
            this.Id = anId;
            this.Name = aName;
            this.PreviousId = aPreviousId;
            this.MindmapId = aMindmapId;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int PreviousId { get => previousId; set => previousId = value; }
        public int MindmapId { get => mindmapId; set => mindmapId = value; }
        public List<Node> Childrens { get => childrens; set => childrens = value; }

        #region Add/Remove childrens
        public void addChildren(Node toAdd)
        {
            Childrens.Add(toAdd);
        }
        public void addListChildrens(List<Node> ListToAdd)
        {
            Childrens.AddRange(ListToAdd);
        }
        public void removeChildren(Node toRemove)
        {
            Childrens.Remove(toRemove);
        }
        public void removeListChildrens(List<Node> ListToRemove)
        {
            foreach (Node toRemove in ListToRemove)
            {
                Childrens.Remove(toRemove);
            }
        }
        #endregion
    }
}
