/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   Priority.cs
 * Desc.    :   This file contains the structure of the Priority class   
 */

namespace Scrum_o_wall.Classes
{
    public class Priority
    {
        private readonly int id;

        public Priority(int id, string name)
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
