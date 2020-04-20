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

namespace Scrum_o_wall.Classes
{
    class Project
    {
        //vars declaration
        private List<UserStory> allUserStories = new List<UserStory>();
        private List<Sprint> sprints = new List<Sprint>();
        private List<MindMap> roots = new List<MindMap>();
        private List<string> states = new List<string>();
        private DateTime begin;
        private string name;
        private string description;


        //properties declaration
        public DateTime Begin { get => begin; set => begin = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }

        /// <summary>
        /// Create a project with name,description and date
        /// </summary>
        /// <param name="aName">the name of the project</param>
        /// <param name="aDesc">the description of the project</param>
        /// <param name="aBegin">the date of beginning of project</param>
        public Project(string aName,string aDesc, DateTime aBegin)
        {
            Name = aName;
            Description = aDesc;
            Begin = aBegin;
        }

        #region Add/Remove userStories
        public void addUserStory(UserStory toAdd)
        {
            allUserStories.Add(toAdd);
        }
        public void addListUserStories(List<UserStory> ListToAdd)
        {
            allUserStories.AddRange(ListToAdd);
        }
        public void removeUserStory(UserStory toRemove)
        {
            allUserStories.Remove(toRemove);
        }
        public void removeListUserStories(List<UserStory> ListToRemove)
        {
            foreach (UserStory toRemove in ListToRemove)
            {
                allUserStories.Remove(toRemove);
            }
        }
        #endregion

        #region Add/Remove sprints
        public void addSprint(Sprint toAdd)
        {
            sprints.Add(toAdd);
        }
        public void addListSprints(List<Sprint> ListToAdd)
        {
            sprints.AddRange(ListToAdd);
        }
        public void removeSprint(Sprint toRemove)
        {
            sprints.Remove(toRemove);
        }
        public void removeListSprints(List<Sprint> ListToRemove)
        {
            foreach (Sprint toRemove in ListToRemove)
            {
                sprints.Remove(toRemove);
            }
        }
        #endregion

        #region Add/Remove MindMap
        public void addMindMap(MindMap toAdd)
        {
            roots.Add(toAdd);
        }
        public void addListMindMaps(List<MindMap> ListToAdd)
        {
            roots.AddRange(ListToAdd);
        }
        public void removeMindMap(MindMap toRemove)
        {
            roots.Remove(toRemove);
        }
        public void removeListMindMaps(List<MindMap> ListToRemove)
        {
            foreach (MindMap toRemove in ListToRemove)
            {
                roots.Remove(toRemove);
            }
        }
        #endregion

        #region Add/Remove states
        public void addState(string toAdd)
        {
            states.Add(toAdd);
        }
        public void addListStates(List<string> ListToAdd)
        {
            states.AddRange(ListToAdd);
        }
        public void removeState(string toRemove)
        {
            states.Remove(toRemove);
        }
        public void removeListStates(List<string> ListToRemove)
        {
            foreach (string toRemove in ListToRemove)
            {
                states.Remove(toRemove);
            }
        }
        #endregion

    }
}
