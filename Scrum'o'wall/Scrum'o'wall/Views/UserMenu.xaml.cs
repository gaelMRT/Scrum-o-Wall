using Scrum_o_wall.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Scrum_o_wall.Views
{
    /// <summary>
    /// Logique d'interaction pour UserMenu.xaml
    /// </summary>
    public partial class UserMenu : Window
    {
        Controller controller;
        IUsersAssigned objectWithAssignedUsers;
        public UserMenu(IUsersAssigned anObjectWithAssignedUsers, Controller aController)
        {
            controller = aController;
            objectWithAssignedUsers = anObjectWithAssignedUsers;

            InitializeComponent();
        }

        private void btnGoLeft_Click(object sender, RoutedEventArgs e)
        {
            User state = lstAssignedUsers.SelectedItem as User;
            if (state != null)
            {
                lstAssignedUsers.Items.Remove(state);
                lstPossibleUsers.Items.Add(state);
            }
        }

        private void btnGoRight_Click(object sender, RoutedEventArgs e)
        {
            User state = lstPossibleUsers.SelectedItem as User;
            if (state != null)
            {
                lstPossibleUsers.Items.Remove(state);
                lstAssignedUsers.Items.Add(state);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            List<User> toRemove = new List<User>();
            List<User> toAdd = new List<User>();
            foreach (User user in controller.Users)
            {
                if (lstAssignedUsers.Items.Contains(user) && !objectWithAssignedUsers.GetUsers().Contains(user))
                {
                    toAdd.Add(user);
                }
                else if (lstPossibleUsers.Items.Contains(user) && objectWithAssignedUsers.GetUsers().Contains(user))
                {
                    toRemove.Add(user);
                }
            }
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            UserCreate userCreate = new UserCreate();
            if(userCreate.ShowDialog() == true)
            {
                controller.CreateUser(userCreate.tbxUserName.Text);
            }
        }
    }
}
