using Scrum_o_wall.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        List<User> possibleUsers;
        public UserMenu(IUsersAssigned anObjectWithAssignedUsers,List<User> possibilities, Controller aController)
        {
            controller = aController;
            objectWithAssignedUsers = anObjectWithAssignedUsers;
            possibleUsers = possibilities;

            InitializeComponent();

            Refresh();
        }

        private void Refresh()
        {
            lstAssignedUsers.Items.Clear();
            lstPossibleUsers.Items.Clear();
            foreach (User user in possibleUsers)
            {
                if (objectWithAssignedUsers.GetUsers().Contains(user))
                {
                    lstAssignedUsers.Items.Add(user);
                }
                else
                {
                    lstPossibleUsers.Items.Add(user);
                }
            }
        }

        private void BtnGoLeft_Click(object sender, EventArgs e)
        {
            User state = lstAssignedUsers.SelectedItem as User;
            if (state != null)
            {
                lstAssignedUsers.Items.Remove(state);
                lstPossibleUsers.Items.Add(state);
            }
        }
        private void BtnGoRight_Click(object sender, EventArgs e)
        {
            User state = lstPossibleUsers.SelectedItem as User;
            if (state != null)
            {
                lstPossibleUsers.Items.Remove(state);
                lstAssignedUsers.Items.Add(state);
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
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
            foreach (User user in toAdd)
            {
                controller.AddUserToIUsersAssigned(user, objectWithAssignedUsers);
            }
            foreach (User user in toRemove)
            {
                controller.RemoveUserFromIUsersAssigned(user, objectWithAssignedUsers);
            }

            this.Close();
        }
        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            UserCreate userCreate = new UserCreate();
            if(userCreate.ShowDialog() == true)
            {
                controller.CreateUser(userCreate.tbxUserName.Text);
                Refresh();
            }
        }

        private void Lst_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            User user = (sender as ListBox).SelectedItem as User;
            UserEdit userEdit = new UserEdit(user);
            switch (userEdit.ShowDialog())
            {
                case true:
                    controller.UpdateUser(userEdit.tbxUserName.Text, user);
                    Refresh();
                    break;
                case false:
                    controller.DeleteUser(user);
                    Refresh();
                    break;
                default:
                    break;
            }
        }
    }
}
