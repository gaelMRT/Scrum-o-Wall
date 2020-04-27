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
        private Dictionary<int, UserStory> orderedUserStories = new Dictionary<int, UserStory>();
        Project project;
        private int id;
        private DateTime begin;
        private DateTime end;
        private int projectId;


        public int Id { get => id; set => id = value; }
        public DateTime Begin { get => begin; set => begin = value; }
        public DateTime End { get => end; set => end = value; }
        public int ProjectId { get => projectId; set => projectId = value; }
        public Project Project { get => project; set => project = value; }
        public Dictionary<int, UserStory> OrderedUserStories { get => orderedUserStories;}

        public Sprint(int anId, DateTime aBegin, DateTime anEnd,int aProjectId)
        {
            Id = anId;
            Begin = aBegin;
            End = anEnd;
            ProjectId = aProjectId;
        }

        #region Add/Remove userStories
        public void addUserStory(int order,UserStory toAdd)
        {
            orderedUserStories.Add(order,toAdd);
        }
        public void addListUserStories(Dictionary<int, UserStory> ListToAdd)
        {
            foreach (KeyValuePair<int,UserStory> item in ListToAdd)
            {
                orderedUserStories.Add(item.Key,item.Value);
            }
        }
        public void removeUserStoryByOrder(int order)
        {
            orderedUserStories.Remove(order);
        }
        #endregion

        public override string ToString()
        {
            return String.Format("Sprint du {0} au {1}", Begin.ToShortDateString(), End.ToShortDateString());
        }
    }
}
