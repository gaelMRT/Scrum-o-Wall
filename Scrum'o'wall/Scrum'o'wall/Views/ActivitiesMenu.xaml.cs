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
            Close();
        }
        private void LstActivities_MouseDoubleClick(object sender, EventArgs e)
        {
            ListBox lbx = sender as ListBox;
            if (lbx.SelectedItem != null)
            {
                Activity activity = lbx.SelectedItem as Activity;
                MessageBox.Show(string.Format("Date : {0}\n{1}", activity.DateTime, activity.Description), "Activité", MessageBoxButton.OK);
            }
        }
    }
}
