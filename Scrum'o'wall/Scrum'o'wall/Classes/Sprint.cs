/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   Sprint.cs
 * Desc.    :   This file contains the structure of the Sprint class   
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum_o_wall.Classes
{
    public class Sprint
    {
        private int id;
        private int projectId;
        private Project project;

        public Sprint(int anId, DateTime aBegin, DateTime anEnd, int aProjectId)
        {
            id = anId;
            Begin = aBegin;
            End = anEnd;
            projectId = aProjectId;
        }
        public int Id { get => id; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public int ProjectId { get => projectId; }
        public Project Project
        {
            get => project;
            set
            {
                project = value;
                projectId = value.Id;
            }
        }
        public Dictionary<int, UserStory> OrderedUserStories { get; } = new Dictionary<int, UserStory>();

        #region Add/Remove userStories
        public void addUserStory(int order, UserStory toAdd)
        {
            OrderedUserStories.Add(order, toAdd);
        }
        public void addListUserStories(Dictionary<int, UserStory> ListToAdd)
        {
            foreach (KeyValuePair<int, UserStory> item in ListToAdd)
            {
                OrderedUserStories.Add(item.Key, item.Value);
            }
        }
        public void removeUserStoryByOrder(int order)
        {
            OrderedUserStories.Remove(order);
        }
        #endregion

        public override string ToString()
        {
            return String.Format("Sprint du {0} au {1}", Begin.ToShortDateString(), End.ToShortDateString());
        }
    }
}
