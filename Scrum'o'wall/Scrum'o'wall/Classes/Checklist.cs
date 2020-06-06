/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   Checklist.cs
 * Desc.    :   This file contains the structure of the Checklist class   
 */
using System.Collections.Generic;

namespace Scrum_o_wall.Classes
{
    public class Checklist
    {
        private readonly int id;
        private int userStoryId;
        private UserStory userStory;

        public Checklist(int id, string name, int userStoryId)
        {
            this.id = id;
            Name = name;
            this.userStoryId = userStoryId;
        }

        public int Id => id;
        public string Name { get; set; }
        public int UserStoryId => userStoryId;
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
