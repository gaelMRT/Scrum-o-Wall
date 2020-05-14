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
        public UserMenu(IUsersAssigned anObjectWithAssignedUsers, Controller aController)
        {
            controller = aController;
            objectWithAssignedUsers = anObjectWithAssignedUsers;

            InitializeComponent();

            Refresh();
        }

        private void Refresh()
        {
            lstAssignedUsers.Items.Clear();
            lstPossibleUsers.Items.Clear();
            foreach (User user in controller.Users)
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

        private void Save()
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
            
            MessageBox.Show("La sauvegarde s'est effectuée sans soucis.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.None);
            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            UserCreate userCreate = new UserCreate();
            if(userCreate.ShowDialog() == true)
            {
                controller.CreateUser(userCreate.tbxUserName.Text);
                Refresh();
            }
        }

        private void btnAddUser_TouchDown(object sender, TouchEventArgs e)
        {
            UserCreate userCreate = new UserCreate();
            if (userCreate.ShowDialog() == true)
            {
                controller.CreateUser(userCreate.tbxUserName.Text);
                Refresh();
            }
        }

        private void btnGoLeft_TouchDown(object sender, TouchEventArgs e)
        {
            User state = lstAssignedUsers.SelectedItem as User;
            if (state != null)
            {
                lstAssignedUsers.Items.Remove(state);
                lstPossibleUsers.Items.Add(state);
            }
        }

        private void btnGoRight_TouchDown(object sender, TouchEventArgs e)
        {
            User state = lstPossibleUsers.SelectedItem as User;
            if (state != null)
            {
                lstPossibleUsers.Items.Remove(state);
                lstAssignedUsers.Items.Add(state);
            }
        }

        private void btnSave_TouchDown(object sender, TouchEventArgs e)
        {
            Save();
        }
    }
}
