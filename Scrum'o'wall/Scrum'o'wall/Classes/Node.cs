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
    class Node
    {
        
        int id;
        string name;
        int previousId;
        int mindmapId;
        List<Node> childrens = new List<Node>();

        public Node(int anId, string aName, int aPreviousId, int aMindmapId)
        {
            this.id = anId;
            this.name = aName;
            this.previousId = aPreviousId;
            this.mindmapId = aMindmapId;
        }

        #region Add/Remove childrens
        public void addChildren(Node toAdd)
        {
            childrens.Add(toAdd);
        }
        public void addListChildrens(List<Node> ListToAdd)
        {
            childrens.AddRange(ListToAdd);
        }
        public void removeChildren(Node toRemove)
        {
            childrens.Remove(toRemove);
        }
        public void removeListChildrens(List<Node> ListToRemove)
        {
            foreach (Node toRemove in ListToRemove)
            {
                childrens.Remove(toRemove);
            }
        }
        #endregion
    }
}
