/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   User.cs
 * Desc.    :   This file contains the structure of the User class   
 */

namespace Scrum_o_wall.Classes
{
    public class User
    {
        private readonly int id;

        public User(int id, string name)
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
