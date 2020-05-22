/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   File.cs
 * Desc.    :   This file contains the structure of the TaskFile class   
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum_o_wall.Classes
{
    public class File
    {
        int id;
        int userStoryId;

        public File(int id, string name, string description,  int userStoryId)
        {
            this.id = id;
            this.Name = name;
            this.Description = description;
            this.userStoryId = userStoryId;
        }

        public int Id { get => id; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserStoryId { get => userStoryId; }

        public override string ToString()
        {
            return Name;
        }
    }
}
