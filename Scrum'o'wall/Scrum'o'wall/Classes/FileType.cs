/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   FileType.cs
 * Desc.    :   This file contains the structure of the FileType class   
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum_o_wall.Classes
{
    public class FileType
    {
        int id;

        public FileType(int id, string name)
        {
            this.id = id;
            this.Name = name;
        }

        public int Id { get => id; }
        public string Name { get; set; }
    }
}
