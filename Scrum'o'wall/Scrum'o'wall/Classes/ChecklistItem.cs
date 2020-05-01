/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   ChecklistItem.cs
 * Desc.    :   This file contains the structure of the ChecklistItem class   
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum_o_wall.Classes
{
    public class ChecklistItem
    {
        int id;
        int checklistId;

        public ChecklistItem(int id, string nameItem, bool done, int checklistId)
        {
            this.id = id;
            this.NameItem = nameItem;
            this.Done = done;
            this.checklistId = checklistId;
        }

        public int Id { get => id;  }
        public string NameItem { get; set; }
        public bool Done { get; set; }
        public int ChecklistId { get => checklistId; }
        public List<User> AssignedUsers { get; set; }
    }
}
