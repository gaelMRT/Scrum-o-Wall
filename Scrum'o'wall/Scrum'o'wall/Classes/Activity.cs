/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   Activity.cs
 * Desc.    :   This file contains the structure of the Activity class   
 */
using System;

namespace Scrum_o_wall.Classes
{
    public class Activity
    {
        private readonly int id;
        private int userStoryId;
        private UserStory userStory;

        public Activity(int id, string description, DateTime dateTime, int userStoryId)
        {
            this.id = id;
            Description = description;
            DateTime = dateTime;
            this.userStoryId = userStoryId;
        }

        public int Id => id;
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public int UserStoryId => userStoryId;
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
            return DateTime.ToString("dd.MM.yyyy - HH:mm:ss") + " - " + Description;
        }
    }
}
