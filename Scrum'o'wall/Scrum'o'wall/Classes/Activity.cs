/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   Activity.cs
 * Desc.    :   This file contains the structure of the Activity class   
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum_o_wall.Classes
{
    public class Activity
    {
        private int id;
        private int userStoryId;
        private UserStory userStory;

        public Activity(int id, string description, DateTime dateTime, int userStoryId)
        {
            this.id = id;
            this.Description = description;
            this.DateTime = dateTime;
            this.userStoryId = userStoryId;
        }

        public int Id { get => id; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public int UserStoryId { get => userStoryId; }
        public UserStory UserStory
        {
            get => userStory; set
            {
                userStory = value;
                userStoryId = value.Id;
            }
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
