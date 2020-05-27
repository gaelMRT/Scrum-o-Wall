/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   Checklist.cs
 * Desc.    :   This file contains the structure of the Checklist class   
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum_o_wall.Classes
{
    public class Checklist
    {
        int id;
        int userStoryId;
        private UserStory userStory;

        public Checklist(int id, string name, int userStoryId)
        {
            this.id = id;
            this.Name = name;
            this.userStoryId = userStoryId;
        }

        public int Id { get => id;  }
        public string Name { get; set; }
        public int UserStoryId { get => userStoryId; }
        public UserStory UserStory
        {
            get => userStory; set
            {
                userStory = value;
                userStoryId = value.Id;
            }
        }
        public List<ChecklistItem> ChecklistItems { get; set; } = new List<ChecklistItem>();
        public override string ToString()
        {
            return Name;
        }
    }
}
