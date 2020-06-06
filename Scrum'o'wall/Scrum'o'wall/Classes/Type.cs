/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   Type.cs
 * Desc.    :   This file contains the structure of the Type class   
 */

namespace Scrum_o_wall.Classes
{
    public class Type
    {
        private readonly int id;

        public Type(int id, string name)
        {
            this.id = id;
            Name = name;
        }

        public int Id => id;
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
