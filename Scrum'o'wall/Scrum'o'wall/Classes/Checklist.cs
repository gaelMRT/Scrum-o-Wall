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
        string name;
        int userStoryId;
        List<ChecklistItem> checklistItems;

        public Checklist(int id, string name, int userStoryId)
        {
            this.Id = id;
            this.Name = name;
            this.UserStoryId = userStoryId;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int UserStoryId { get => userStoryId; set => userStoryId = value; }
        public List<ChecklistItem> ChecklistItems { get => checklistItems; set => checklistItems = value; }
    }
}
