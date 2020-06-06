/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   IUsersAssigned.cs
 * Desc.    :   This file is the interface to some classes with user assigned
 */
using System.Collections.Generic;

namespace Scrum_o_wall.Classes
{
    public interface IUsersAssigned
    {
        List<User> GetUsers();
        void AddUser(User user);
        void RemoveUser(User user);

    }
}
