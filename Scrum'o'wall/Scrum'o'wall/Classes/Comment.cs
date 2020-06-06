/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   Comment.cs
 * Desc.    :   This file contains the structure of the Comment class   
 */
using System;

namespace Scrum_o_wall.Classes
{
    public class Comment
    {
        private readonly int id;
        private int userStoryId;
        private int userId;
        private UserStory userStory;
        private User user;

        public Comment(int id, string description, DateTime dateTime, int userStoryId, int userId)
        {
            this.id = id;
            Description = description;
            DateTime = dateTime;
            this.userStoryId = userStoryId;
            this.userId = userId;
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
        public int UserId => userId;
        public User User
        {
            get => user;
            set
            {
                user = value;
                userId = value.Id;
            }
        }
        public override string ToString()
        {
            return User.Name + " - " + Description;
        }
    }
}
