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
        string nameItem;
        bool done;
        int checklistId;
        List<User> assignedUsers;

        public ChecklistItem(int id, string nameItem, bool done, int checklistId)
        {
            this.id = id;
            this.nameItem = nameItem;
            this.done = done;
            this.checklistId = checklistId;
        }

        public int Id { get => id; set => id = value; }
        public string NameItem { get => nameItem; set => nameItem = value; }
        public bool Done { get => done; set => done = value; }
        public int ChecklistId { get => checklistId; set => checklistId = value; }
        public List<User> AssignedUsers { get => assignedUsers; set => assignedUsers = value; }
    }
}
