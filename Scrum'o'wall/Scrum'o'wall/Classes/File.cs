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
        string name;
        string description;
        int fileTypeId;
        int userStoryId;

        public File(int id, string name, string description, int fileTypeId, int userStoryId)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.FileTypeId = fileTypeId;
            this.UserStoryId = userStoryId;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public int FileTypeId { get => fileTypeId; set => fileTypeId = value; }
        public int UserStoryId { get => userStoryId; set => userStoryId = value; }
    }
}
