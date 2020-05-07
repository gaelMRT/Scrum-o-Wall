/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   Comment.cs
 * Desc.    :   This file contains the structure of the Comment class   
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum_o_wall.Classes
{
    public class Comment
    {
        int id;
        int userStoryId;
        int userId;

        public Comment(int id, string description, DateTime dateTime, int userStoryId, int userId)
        {
            this.id = id;
            this.Description = description;
            this.DateTime = dateTime;
            this.userStoryId = userStoryId;
            this.userId = userId;
        }

        public int Id { get => id;  }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public int UserStoryId { get => userStoryId; }
        public int UserId { get => userId; }
        public override string ToString()
        {
            return Description;
        }
    }
}
