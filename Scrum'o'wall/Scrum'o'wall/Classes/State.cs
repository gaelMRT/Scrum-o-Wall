/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   State.cs
 * Desc.    :   This file contains the structure of the State class   
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum_o_wall.Classes
{
    public class State
    {
        int id;

        public State(int id, string name)
        {
            this.id = id;
            this.Name = name;
        }

        public int Id { get => id; }
        public string Name { get; set; }
    }
}
