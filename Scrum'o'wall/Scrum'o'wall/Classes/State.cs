/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   State.cs
 * Desc.    :   This file contains the structure of the State class   
 */

namespace Scrum_o_wall.Classes
{
    public class State
    {
        private readonly int id;

        public State(int id, string name)
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
