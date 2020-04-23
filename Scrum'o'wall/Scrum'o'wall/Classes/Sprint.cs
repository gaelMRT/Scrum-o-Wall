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
        private List<UserStory> userStories = new List<UserStory>();
        private int id;
        private DateTime begin;
        private DateTime end;

        public int Id { get => id; set => id = value; }
        public DateTime Begin { get => begin; set => begin = value; }
        public DateTime End { get => end; set => end = value; }

        public Sprint(int anId, DateTime aBegin, DateTime anEnd)
        {
            Id = anId;
            Begin = aBegin;
            End = anEnd;
        }

        #region Add/Remove userStories
        public void addUserStory(UserStory toAdd)
        {
            userStories.Add(toAdd);
        }
        public void addListUserStories(List<UserStory> ListToAdd)
        {
            userStories.AddRange(ListToAdd);
        }
        public void removeUserStory(UserStory toRemove)
        {
            userStories.Remove(toRemove);
        }
        public void removeListUserStories(List<UserStory> ListToRemove)
        {
            foreach (UserStory toRemove in ListToRemove)
            {
                userStories.Remove(toRemove);
            }
        }
        #endregion
    }
}
