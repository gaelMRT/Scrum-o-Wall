﻿/*
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
        string description;
        DateTime dateTime;
        int userStoryId;
        int userId;

        public Comment(int id, string description, DateTime dateTime, int userStoryId, int userId)
        {
            this.Id = id;
            this.Description = description;
            this.DateTime = dateTime;
            this.UserStoryId = userStoryId;
            this.UserId = userId;
        }

        public int Id { get => id; set => id = value; }
        public string Description { get => description; set => description = value; }
        public DateTime DateTime { get => dateTime; set => dateTime = value; }
        public int UserStoryId { get => userStoryId; set => userStoryId = value; }
        public int UserId { get => userId; set => userId = value; }
    }
}
