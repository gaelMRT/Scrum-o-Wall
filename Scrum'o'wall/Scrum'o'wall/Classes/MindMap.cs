/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   MindMap.cs
 * Desc.    :   This file contains the structure of the MindMap class   
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum_o_wall.Classes
{
    public class MindMap
    {
        private List<MindMap> childrens = new List<MindMap>();
        private string name;
        public MindMap(string aName)
        {
            name = aName;
        }

        #region Add/Remove childrens
        public void addChildren(MindMap toAdd)
        {
            childrens.Add(toAdd);
        }
        public void addListChildrens(List<MindMap> ListToAdd)
        {
            childrens.AddRange(ListToAdd);
        }
        public void removeChildren(MindMap toRemove)
        {
            childrens.Remove(toRemove);
        }
        public void removeListChildrens(List<MindMap> ListToRemove)
        {
            foreach (MindMap toRemove in ListToRemove)
            {
                childrens.Remove(toRemove);
            }
        }
        #endregion
    }
}
