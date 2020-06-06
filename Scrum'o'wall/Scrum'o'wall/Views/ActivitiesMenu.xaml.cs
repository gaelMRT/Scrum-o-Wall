/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   ActivitiesMenu.xaml.cs
 * Desc.    :   This file contains the logic in the ActivitiesMenu view
 */
using Scrum_o_wall.Classes;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Scrum_o_wall.Views
{
    /// <summary>
    /// Logique d'interaction pour ActivitiesMenu.xaml
    /// </summary>
    public partial class ActivitiesMenu : Window
    {
        private readonly List<Activity> activities;
        public ActivitiesMenu(List<Activity> someActivities)
        {
            activities = someActivities;
            InitializeComponent();
            foreach (Activity a in activities)
            {
                lstActivities.Items.Add(a);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = null;
            Close();
        }
        private void LstActivities_MouseDoubleClick(object sender, EventArgs e)
        {
            ListBox lbx = sender as ListBox;
            if (lbx.SelectedItem != null)
            {
                Comment comment = lbx.SelectedItem as Comment;
                MessageBox.Show(string.Format("Auteur : {0}\nDate : {1}\n{2}", comment.User, comment.DateTime, comment.Description), "Contenu du commentaire", MessageBoxButton.OK);
            }
        }
    }
}
