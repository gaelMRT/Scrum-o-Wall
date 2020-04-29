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
        private Node root;
        private string name;
        private int id;
        private int projectId;
        public MindMap(int anId,string aName,int aProjectId)
        {
            Id = anId;
            Name = aName;
            ProjectId = aProjectId;
        }

        public Node Root { get => root; set => root = value; }
        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
        public int ProjectId { get => projectId; set => projectId = value; }
    }
}
