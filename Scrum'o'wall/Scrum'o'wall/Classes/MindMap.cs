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
        private int id;
        private int projectId;
        public MindMap(int anId,string aName,int aProjectId)
        {
            id = anId;
            Name = aName;
            projectId = aProjectId;
        }

        public Node Root { get; set; }
        public string Name { get; set; }
        public int Id { get => id;  }
        public int ProjectId { get => projectId; }
    }
}
