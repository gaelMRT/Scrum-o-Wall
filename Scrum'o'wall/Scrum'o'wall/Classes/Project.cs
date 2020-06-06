/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   Project.cs
 * Desc.    :   This file contains the structure of the Project class   
 */
using System;
using System.Collections.Generic;

namespace Scrum_o_wall.Classes
{
    public class Project : IUsersAssigned
    {
        private readonly int id;
        private readonly List<User> assignedUsers = new List<User>();

        /// <summary>
        /// Create a project with name,description and date
        /// </summary>
        /// <param name="aName">the name of the project</param>
        /// <param name="aDesc">the description of the project</param>
        /// <param name="aBegin">the date of beginning of project</param>
        public Project(int anId, string aName, string aDesc, DateTime aBegin)
        {
            id = anId;
            Name = aName;
            Description = aDesc;
            Begin = aBegin;
        }

        //properties declaration
        public int Id => id;
        public DateTime Begin { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<UserStory> AllUserStories { get; set; } = new List<UserStory>();
        public List<Sprint> Sprints { get; set; } = new List<Sprint>();
        public List<MindMap> MindMaps { get; set; } = new List<MindMap>();
        public Dictionary<int, State> States { get; set; } = new Dictionary<int, State>();


        public void AddUser(User user)
        {
            assignedUsers.Add(user);
        }

        public List<User> GetUsers()
        {
            return assignedUsers;
        }

        public void RemoveUser(User user)
        {
            assignedUsers.Remove(user);
        }

        public override string ToString()
        {
            return string.Format("Project N°{00:0} - {1} - {2} - {3}", Id, Name, Begin, Description);
        }

    }
}
