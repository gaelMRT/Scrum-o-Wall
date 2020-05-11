﻿using Scrum_o_wall.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Logique d'interaction pour SprintMenu.xaml
    /// </summary>
    public partial class SprintMenu : Window
    {
        Sprint sprint;
        Controller controller;
        public SprintMenu(Sprint aSprint, Controller aController)
        {
            InitializeComponent();
            sprint = aSprint;
            controller = aController;
            Loaded += SprintMenu_Loaded;

            lblProjectName.Content = sprint.Project.Name;
            lblSprintName.Content = aSprint.ToString();
            //Define NameScope to use FindName later
            NameScope.SetNameScope(cnvsSprint, new NameScope());
            foreach (KeyValuePair<int, State> keyValuePair in sprint.Project.States)
            {
                State state = keyValuePair.Value;
                GroupBox groupBox = new GroupBox();
                groupBox.Name = "gbx" + state.Name.Replace(" ", "");
                groupBox.Content = state;
                cnvsSprint.Children.Add(groupBox);
                Canvas.SetTop(groupBox, 100);
                Canvas.SetBottom(groupBox, 90);
                //Register Name to find it with FindName later
                cnvsSprint.RegisterName(groupBox.Name, groupBox);

            }
        }
        private void SprintMenu_Loaded(object sender, RoutedEventArgs e)
        {
            cnvsSprint.Width = this.ActualWidth;
            cnvsSprint.Height = this.ActualHeight;

            //set control positions
            Canvas.SetLeft(lblProjectName, (cnvsSprint.Width - lblProjectName.ActualWidth) / 2.0);
            Canvas.SetLeft(lblSprintName, (cnvsSprint.Width - lblSprintName.ActualWidth) / 2.0);
            Canvas.SetLeft(btnBurndownChart, (cnvsSprint.Width) / 2.0 + btnBurndownChart.ActualWidth);
            Canvas.SetLeft(btnReturn, (cnvsSprint.Width) / 2.0 - btnReturn.ActualWidth);

            Refresh();
        }

        /// <summary>
        /// Refresh the view with it content
        /// </summary>
        private void Refresh()
        {
            //Declare variables for groupbox and userstories positioning
            double widthGbx = cnvsSprint.ActualWidth / sprint.Project.States.Count;
            Dictionary<State, int> userStoriesPerState = new Dictionary<State, int>();


            foreach (KeyValuePair<int, State> keyValuePair in sprint.Project.States)
            {
                State state = keyValuePair.Value;
                GroupBox gbx = (GroupBox)cnvsSprint.FindName("gbx" + state.Name.Replace(" ", ""));
                if (gbx != null)
                {
                    gbx.Width = widthGbx;
                    gbx.Height = cnvsSprint.ActualHeight - 190;
                    gbx.Header = state.Name;
                    gbx.Content = "";
                    Canvas.SetLeft(gbx, keyValuePair.Key * widthGbx);
                    userStoriesPerState.Add(state, 0);
                }
                else
                {
                    MessageBox.Show("Un problème est survenue avec l'état '" + state.Name + "'.");
                }
            }
            /// Place UserStories
            foreach (KeyValuePair<int, UserStory> item in sprint.OrderedUserStories)
            {
                UserStory userStory = item.Value;
                GroupBox gbx = (GroupBox)cnvsSprint.FindName("gbx" + userStory.CurrentState.Name.Replace(" ", ""));
                if (gbx == null)
                {
                    MessageBox.Show("Un problème est survenue avec l'état '" + userStory.CurrentState.Name + "'.");
                }

                //Create userStory frame
                UserControl userControl = new UserControl();
                userControl.Content = userStory.ToString();
                userControl.Width = widthGbx - 20;
                userControl.BorderBrush = Brushes.Black;
                userControl.Background = Brushes.LightGray;
                userControl.Cursor = Cursors.Hand;
                userControl.Height = 20;
                userControl.Tag = userStory;
                userControl.MouseUp += usrCtrlUserStory_MouseUp;
                userControl.TouchDown += usrCtrlUserStory_TouchDown;

                cnvsSprint.Children.Add(userControl);


                Canvas.SetLeft(userControl, Canvas.GetLeft(gbx) + 10);
                Canvas.SetTop(userControl, Canvas.GetTop(gbx) + 30 + 30 * userStoriesPerState[userStory.CurrentState]);
                userStoriesPerState[userStory.CurrentState]++;

            }
        }



        private void usrCtrlUserStory_MouseUp(object sender, MouseButtonEventArgs e)
        {
            UserStory userStory = (sender as UserControl).Tag as UserStory;
            UserStoryEditing(userStory);
        }

        private void usrCtrlUserStory_TouchDown(object sender, TouchEventArgs e)
        {
            UserStory userStory = (sender as UserControl).Tag as UserStory;
            UserStoryEditing(userStory);
        }


        private void UserStoryEditing(UserStory userStory)
        {
            UserStoryEdit userStoryEdit = new UserStoryEdit(userStory, controller);
            if (userStoryEdit.ShowDialog() == true)
            {
                controller.UpdateUserStory(userStoryEdit.tbxDesc.Text, userStoryEdit.dtpckrDateLimit.SelectedDate, Convert.ToInt32(userStoryEdit.tbxComplexity.Text), Convert.ToInt32(userStoryEdit.tbxCompletedComplexity.Text), userStoryEdit.chckBxBlocked.IsChecked == true, (Priority)userStoryEdit.cbxPriority.SelectedItem, (Classes.Type)userStoryEdit.cbxType.SelectedItem, userStory, sprint.Project);
                Refresh();
            }
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void addColumn_Click(object sender, RoutedEventArgs e)
        {
            StateMenu stateMenu = new StateMenu(sprint.Project, controller);
            stateMenu.ShowDialog();
            Refresh();
        }

        private void btnBurndownChart_Click(object sender, RoutedEventArgs e)
        {
            BurndownChart burndownChart = new BurndownChart(sprint);
            burndownChart.ShowDialog();
        }

        private void btnBurndownChart_TouchDown(object sender, TouchEventArgs e)
        {
            BurndownChart burndownChart = new BurndownChart(sprint);
            burndownChart.ShowDialog();
        }

        private void btnReturn_TouchDown(object sender, TouchEventArgs e)
        {
            this.Close();
        }
    }
}
