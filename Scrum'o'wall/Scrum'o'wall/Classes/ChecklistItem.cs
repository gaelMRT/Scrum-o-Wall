/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   ChecklistItem.cs
 * Desc.    :   This file contains the structure of the ChecklistItem class   
 */
using System.Collections.Generic;

namespace Scrum_o_wall.Classes
{
    public class ChecklistItem : IUsersAssigned
    {
        private readonly int id;
        private int checklistId;
        private Checklist checklist;
        private readonly List<User> assignedUsers = new List<User>();

        public ChecklistItem(int id, string nameItem, bool done, int checklistId)
        {
            this.id = id;
            NameItem = nameItem;
            Done = done;
            this.checklistId = checklistId;
        }

        public int Id => id;
        public string NameItem { get; set; }
        public bool Done { get; set; }
        public int ChecklistId => checklistId;
        public Checklist Checklist
        {
            get => checklist; set
            {
                checklist = value;
                checklistId = value.Id;
            }
        }

        public void AddUser(User user)
        {
            assignedUsers.Add(user);
        }

        public List<User> GetUsers()
        {
            return assignedUsers;
        }

        public void RemoveUser(User user)
        {
            assignedUsers.Remove(user);
        }
        public override string ToString()
        {
            return NameItem;
        }
    }
}
