/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   UserMenu.xaml.cs
 * Desc.    :   This file contains the logic in the UserMenu view
 */
using Scrum_o_wall.Classes;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Scrum_o_wall.Views
{
    /// <summary>
    /// Logique d'interaction pour UserMenu.xaml
    /// </summary>
    public partial class UserMenu : Window
    {
        private readonly Controller controller;
        private readonly IUsersAssigned objectWithAssignedUsers;
        private readonly List<User> possibleUsers;
        public UserMenu(IUsersAssigned anObjectWithAssignedUsers, List<User> possibilities, Controller aController)
        {
            controller = aController;
            objectWithAssignedUsers = anObjectWithAssignedUsers;
            possibleUsers = possibilities;

            InitializeComponent();

            Refresh();
        }

        private void UserMenu_Closing(object sender, EventArgs e)
        {
            if (MessageBox.Show("Les changements non sauvegardés seront perdus.\nVoulez-vous sauvegarder les modifications ?", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Save();
            }
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
            if (lstAssignedUsers.SelectedItem is User state)
            {
                lstAssignedUsers.Items.Remove(state);
                lstPossibleUsers.Items.Add(state);
            }
        }
        private void BtnGoRight_Click(object sender, EventArgs e)
        {
            if (lstPossibleUsers.SelectedItem is User state)
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
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            Save();
            Close();
        }
        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            UserCreate userCreate = new UserCreate();
            if (userCreate.ShowDialog() == true)
            {
                controller.CreateUser(userCreate.tbxUserName.Text, objectWithAssignedUsers);
                Refresh();
            }
        }

        private void Lst_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            User user = (sender as ListBox).SelectedItem as User;
            UserEdit userEdit = new UserEdit(user);
            if (userEdit.ShowDialog() == true)
            {
                if (userEdit.Deleted)
                {
                    controller.Delete(user);
                }
                else
                {
                    string name = userEdit.tbxUserName.Text.Trim();
                    controller.UpdateUser(name, user);
                }
                Refresh();
            }
        }
    }
}
