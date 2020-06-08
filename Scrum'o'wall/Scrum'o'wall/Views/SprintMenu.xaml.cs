/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   SprintMenu.xaml.cs
 * Desc.    :   This file contains the logic in the SprintMenu view
 */
using Scrum_o_wall.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Scrum_o_wall.Views
{
    /// <summary>
    /// Logique d'interaction pour SprintMenu.xaml
    /// </summary>
    public partial class SprintMenu : Window
    {
        private readonly Sprint sprint;
        private readonly Controller controller;
        private readonly List<GroupBox> columns = new List<GroupBox>();
        private readonly List<UserControl> userStories = new List<UserControl>();

        private readonly Dictionary<InputDevice, Point> currentPoint = new Dictionary<InputDevice, Point>();
        private readonly Dictionary<InputDevice, UserControl> infos = new Dictionary<InputDevice, UserControl>();

        public SprintMenu(Sprint aSprint, Controller aController)
        {
            InitializeComponent();
            sprint = aSprint;
            controller = aController;

            Loaded += SprintMenu_Loaded;
            PreviewTouchMove += SprintMenu_PreviewTouchMove;
            TouchUp += SprintMenu_PreviewTouchUp;

            lblProjectName.Content = sprint.Project.Name;
            lblSprintName.Content = aSprint.ToString();

        }


        private void CleanLists()
        {
            foreach (GroupBox gbx in columns)
            {
                cnvsSprint.Children.Remove(gbx);
            }
            columns.Clear();
            foreach (UserControl userControl in userStories)
            {
                cnvsSprint.Children.Remove(userControl);
            }
            userStories.Clear();
        }
        /// <summary>
        /// Refresh the view with it content
        /// </summary>
        private void Refresh()
        {
            CleanLists();

            //Declare variables for userstories positioning
            Dictionary<State, int> userStoriesPerState = new Dictionary<State, int>();

            foreach (KeyValuePair<int, State> keyValuePair in sprint.Project.States)
            {
                State state = keyValuePair.Value;
                CreateStateColumn(state);
                userStoriesPerState.Add(state, 0);
            }
            /// Place UserStories
            foreach (KeyValuePair<int, UserStory> item in sprint.OrderedUserStories)
            {
                UserStory userStory = item.Value;
                CreateUserStoryControl(userStory, userStoriesPerState[userStory.State]);
                userStoriesPerState[userStory.State]++;
            }
        }
        private GroupBox CreateStateColumn(State state)
        {
            //Create the column
            GroupBox gbx = new GroupBox
            {
                Height = cnvsSprint.ActualHeight - 190,
                Width = cnvsSprint.ActualWidth / sprint.Project.States.Count,
                Name = "gbx" + state.Name.Replace(" ", "").Replace("'",""),
                Header = state.Name,
                Tag = state,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(1)
            };

            //Positioning and put into canvas
            cnvsSprint.Children.Add(gbx);
            Canvas.SetTop(gbx, 100);
            Canvas.SetBottom(gbx, 90);
            Canvas.SetLeft(gbx, gbx.Width * columns.Count);

            //added to list and returned
            columns.Add(gbx);
            return gbx;
        }


        private UserControl CreateUserStoryControl(UserStory userStory, int cptTop = 0)
        {
            GroupBox gbx = columns.Where(c => c.Tag == userStory.State).First();

            //Create userStory frame
            TextBlock content = new TextBlock
            {
                Text = userStory.ToString(),
                TextWrapping = TextWrapping.Wrap
            };

            UserControl userControl = new UserControl
            {
                Content = content,
                Tag = userStory,
                Height = 50,
                Width = gbx.Width - 20,
                BorderBrush = Brushes.Black,
                Cursor = Cursors.Hand
            };
            // Set background color by limit date
            if (userStory.DateLimit != null)
            {
                if (DateTime.Now > userStory.DateLimit)
                {
                    userControl.Background = Brushes.LightBlue;
                }
                else
                {
                    userControl.Background = Brushes.LightPink;
                }
            }
            else
            {
                userControl.Background = Brushes.LightGray;
            }
            userControl.MouseDoubleClick += UsrCtrlUserStory_Click;
            userControl.TouchUp += UsrCtrlUserStory_Click;

            //Events for drag'n'drop
            userControl.PreviewTouchDown += UserStory_PreviewTouchDown;
            Stylus.SetIsPressAndHoldEnabled(userControl, false);

            //Add to lists, positionning and return
            cnvsSprint.Children.Add(userControl);
            Canvas.SetLeft(userControl, Canvas.GetLeft(gbx) + 10);
            Canvas.SetTop(userControl, Canvas.GetTop(gbx) + 30 + 60 * cptTop);
            userStories.Add(userControl);
            return userControl;
        }

        private void SprintMenu_Loaded(object sender, RoutedEventArgs e)
        {
            cnvsSprint.Width = ActualWidth;
            cnvsSprint.Height = ActualHeight;

            //set control positions
            Canvas.SetLeft(lblProjectName, (cnvsSprint.Width - lblProjectName.ActualWidth) / 2.0);
            Canvas.SetLeft(lblSprintName, (cnvsSprint.Width - lblSprintName.ActualWidth) / 2.0);
            Canvas.SetLeft(btnBurndownChart, (cnvsSprint.Width) / 2.0 + btnBurndownChart.ActualWidth);
            Canvas.SetLeft(btnReturn, (cnvsSprint.Width) / 2.0 - btnReturn.ActualWidth);

            Refresh();
        }
        private void SprintMenu_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            if (currentPoint.ContainsKey(e.Device))
            {
                //Search the contained groupbox
                Point p = e.GetTouchPoint(null).Position;
                GroupBox gbxState = null;
                foreach (GroupBox col in columns)
                {
                    double leftBound = Canvas.GetLeft(col);
                    double rightBound = leftBound + col.Width;
                    double topBound = Canvas.GetTop(col);
                    double bottomBound = topBound + col.Height;
                    if (p.X > leftBound && p.X < rightBound &&
                        p.Y > topBound && p.Y < bottomBound)
                    {
                        gbxState = col;
                        break;
                    }
                }
                //if release in a groupbox, change state
                if (gbxState != null)
                {
                    gbxState.BorderThickness = new Thickness(1);

                    State state = gbxState.Tag as State;
                    UserStory userStory = (infos[e.Device] as UserControl).Tag as UserStory;
                    controller.UserStorySwitchState(userStory, state);
                }
                currentPoint.Remove(e.Device);
                infos.Remove(e.Device);
                Refresh();
            }
        }
        private void SprintMenu_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            //Update position of point
            if (currentPoint.ContainsKey(e.Device))
            {
                currentPoint[e.Device] = e.GetTouchPoint(null).Position;
            }
            //Set border thickness to default
            foreach (GroupBox col in columns)
            {
                col.BorderThickness = new Thickness(1);
            }
            //Verify each points to change border thickness if in bounds
            foreach (KeyValuePair<InputDevice, Point> keyValuePair in currentPoint)
            {
                Point p = keyValuePair.Value;
                foreach (GroupBox col in columns)
                {
                    double leftBound = Canvas.GetLeft(col);
                    double rightBound = leftBound + col.Width;
                    double topBound = Canvas.GetTop(col);
                    double bottomBound = topBound + col.Height;

                    if (p.X > leftBound && p.X < rightBound &&
                        p.Y > topBound && p.Y < bottomBound)
                    {
                        col.BorderThickness = new Thickness(3);
                    }
                }
            }
        }
        private void UserStory_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (currentPoint.ContainsKey(e.Device))
            {
                currentPoint.Remove(e.Device);
                infos.Remove(e.Device);
            }

            currentPoint.Add(e.Device, e.GetTouchPoint(null).Position);
            infos.Add(e.Device, sender as UserControl);
        }
        private void State_DragLeave(object sender, DragEventArgs e)
        {
            GroupBox gbx = sender as GroupBox;
            gbx.BorderThickness = new Thickness(1);
        }
        private void State_DragEnter(object sender, DragEventArgs e)
        {
            GroupBox gbx = sender as GroupBox;
            gbx.BorderThickness = new Thickness(5);
        }
        private void State_Drop(object sender, DragEventArgs e)
        {
            GroupBox gbx = sender as GroupBox;
            gbx.BorderThickness = new Thickness(1);

            //Make userStory switch
            State state = gbx.Tag as State;
            UserStory userStory = e.Data.GetData("drag") as UserStory;
            controller.UserStorySwitchState(userStory, state);

            Refresh();
        }
        private void UsrCtrlUserStory_Click(object sender, EventArgs e)
        {
            UserStory userStory = (sender as UserControl).Tag as UserStory;
            UserStoryEdit userStoryEdit = new UserStoryEdit(userStory, sprint.Project, controller);
            if (userStoryEdit.ShowDialog() == true)
            {
                if (userStoryEdit.Deleted)
                {
                    controller.Delete(userStory);
                }
                else
                {
                    string desc = userStoryEdit.tbxDesc.Text.Trim();
                    DateTime? dateLimite = userStoryEdit.dtpckrDateLimit.SelectedDate;
                    int complexity = Convert.ToInt32(userStoryEdit.tbxComplexity.Text);
                    int completedComplexity = Convert.ToInt32(userStoryEdit.tbxCompletedComplexity.Text);
                    bool blocked = userStoryEdit.chckBxBlocked.IsChecked == true;
                    Priority priority = (Priority)userStoryEdit.cbxPriority.SelectedItem;
                    Classes.Type type = (Classes.Type)userStoryEdit.cbxType.SelectedItem;
                    State state = userStory.State;

                    controller.UpdateUserStory(desc, dateLimite, complexity, completedComplexity, blocked, priority, type, state, userStory);
                }
                Refresh();
            }
        }
        private void AddColumn_Click(object sender, RoutedEventArgs e)
        {
            StateMenu stateMenu = new StateMenu(sprint.Project, controller);
            stateMenu.ShowDialog();
            Refresh();
        }
        private void BtnBurndownChart_Click(object sender, EventArgs e)
        {
            BurndownChart burndownChart = new BurndownChart(sprint);
            burndownChart.ShowDialog();
        }
        private void BtnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnEditSprint_Click(object sender, RoutedEventArgs e)
        {
            SprintEdit sprintEdit = new SprintEdit(sprint);
            if (sprintEdit.ShowDialog() == true)
            {
                if (sprintEdit.Deleted)
                {
                    controller.Delete(sprint);
                    DialogResult = true;
                    Close();
                }
                else
                {
                    DateTime begin = sprintEdit.dtpckDateBegin.SelectedDate == null ? DateTime.Now : sprintEdit.dtpckDateBegin.SelectedDate.Value;
                    DateTime end = sprintEdit.dtpckDateEnd.SelectedDate == null ? DateTime.Now + new TimeSpan(7, 0, 0, 0) : sprintEdit.dtpckDateEnd.SelectedDate.Value;
                    controller.UpdateSprint(begin, end, sprint);
                    Refresh();
                }
            }
        }
    }
}
