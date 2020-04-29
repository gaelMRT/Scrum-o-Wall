/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   Project.cs
 * Desc.    :   This file contains the structure of the Project class   
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents.Serialization;

namespace Scrum_o_wall.Classes
{
    public class Project
    {
        //vars declaration
        private List<UserStory> allUserStories = new List<UserStory>();
        private List<Sprint> sprints = new List<Sprint>();
        private List<MindMap> roots = new List<MindMap>();
        private List<State> states = new List<State>();
        private List<User> assignedUsers = new List<User>();
        private int id;
        private DateTime begin;
        private string name;
        private string description;


        /// <summary>
        /// Create a project with name,description and date
        /// </summary>
        /// <param name="aName">the name of the project</param>
        /// <param name="aDesc">the description of the project</param>
        /// <param name="aBegin">the date of beginning of project</param>
        public Project(int anId, string aName,string aDesc, DateTime aBegin)
        {
            Id = anId;
            Name = aName;
            Description = aDesc;
            Begin = aBegin;
        }

        //properties declaration
        public int Id { get => id; set => id = value; }
        public DateTime Begin { get => begin; set => begin = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public List<UserStory> AllUserStories { get => allUserStories; set => allUserStories = value; }
        public List<Sprint> Sprints { get => sprints; set => sprints = value; }
        public List<MindMap> Roots { get => roots; set => roots = value; }
        public List<State> States { get => states; set => states = value; }
        public List<User> AssignedUsers { get => assignedUsers; set => assignedUsers = value; }

        public override string ToString()
        {
            return String.Format("Project N°{00:0} - {1} - {2} - {3}", Id, Name, Begin, Description);
        }

    }
}
