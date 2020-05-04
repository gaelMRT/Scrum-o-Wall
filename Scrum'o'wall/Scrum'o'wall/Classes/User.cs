﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum_o_wall.Classes
{
    public class User
    {
        int id;

        public User(int id, string name)
        {
            this.id = id;
            this.Name = name;
        }

        public int Id { get => id; }
        public string Name { get; set; }
    }
}