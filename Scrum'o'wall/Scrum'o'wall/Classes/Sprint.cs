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
        private DateTime begin;
        private DateTime end;
        public Sprint(DateTime aBegin, DateTime anEnd)
        {
            begin = aBegin;
            end = anEnd;
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
