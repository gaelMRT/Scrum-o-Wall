using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum_o_wall.Classes
{
    public interface IUsersAssigned
    {
        List<User> GetUsers();
        void AddUser(User user);
        void RemoveUser(User user);

    }
}
