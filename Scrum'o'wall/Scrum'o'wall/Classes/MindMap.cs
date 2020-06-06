/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   MindMap.cs
 * Desc.    :   This file contains the structure of the MindMap class   
 */
using System.Collections.Generic;

namespace Scrum_o_wall.Classes
{
    public class MindMap
    {
        private readonly int id;
        private int projectId;
        private Project project;
        public MindMap(int anId, string aName, int aProjectId)
        {
            id = anId;
            Name = aName;
            projectId = aProjectId;
        }

        public Node Root { get; set; }
        public string Name { get; set; }
        public int Id => id;
        public int ProjectId => projectId;
        public Project Project
        {
            get => project;
            set
            {
                project = value;
                projectId = value.Id;
            }
        }
        public List<Node> GetAllNodes()
        {
            return Root.AllChildrens();
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
