using Scrum_o_wall.Classes;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Scrum_o_wall.Views
{
    /// <summary>
    /// Logique d'interaction pour ProjectMenu.xaml
    /// </summary>
    public partial class ProjectMenu : Window
    {
        Project currentProject;
        Controller controller;
        Dictionary<InputDevice, Point> startPoint = new Dictionary<InputDevice, Point>();

        public ProjectMenu(Project p, Controller ctrl)
        {
            InitializeComponent();
            currentProject = p;
            controller = ctrl;

            lblProjectName.Content = p.Name;

            Loaded += ProjectMenu_Loaded;
        }

        private void Refresh()
        {
            int nbSprints = currentProject.Sprints.Count;
            for (int i = 0; i < nbSprints; i++)
            {
                Sprint sprint = currentProject.Sprints[i];
                //Create Sprint frame
                UserControl userControl = new UserControl();
                userControl.Content = sprint.ToString();
                userControl.Width = cnvsSprints.Width - 40;
                userControl.BorderThickness = new Thickness(1);
                userControl.BorderBrush = Brushes.Black;
                userControl.Cursor = Cursors.Hand;
                userControl.Height = 50;
                userControl.Tag = sprint;
                userControl.MouseLeftButtonUp += sprint_Click;
                userControl.TouchDown += sprint_Click;
                userControl.AllowDrop = true;
                userControl.Drop += sprint_Drop;
                userControl.DragEnter += sprint_DragEnter;
                userControl.DragLeave += sprint_DragLeave;
                //Change Color by DateRange
                if (DateTime.Now > sprint.Begin && DateTime.Now < sprint.End)
                {
                    //Actual
                    userControl.Background = Brushes.LightBlue;
                }
                else if (DateTime.Now < sprint.Begin)
                {
                    //Not beginned
                    userControl.Background = Brushes.LightGray;
                }
                else
                {
                    //Already passed
                    userControl.Background = Brushes.LightPink;
                }


                cnvsSprints.Children.Add(userControl);

                Canvas.SetLeft(userControl, 5);
                Canvas.SetTop(userControl, 60 * i);
            }

            int nbUserStories = currentProject.AllUserStories.Count;
            for (int i = 0; i < nbUserStories; i++)
            {
                UserStory userStory = currentProject.AllUserStories[i];
                //Create userStory frame
                UserControl userControl = new UserControl();
                userControl.Content = userStory.ToString();
                userControl.Width = cnvsUserStories.Width - 40;
                userControl.BorderBrush = Brushes.Black;
                userControl.BorderThickness = new Thickness(1);
                userControl.Background = Brushes.LightGray;
                userControl.Cursor = Cursors.Hand;
                userControl.Height = 50;
                userControl.Tag = userStory;
                userControl.MouseLeftButtonUp += userStory_MouseLeftButtonUp;
                userControl.PreviewTouchDown += userStory_PreviewTouchDown;
                userControl.PreviewTouchMove += userStory_PreviewTouchMove;
                userControl.TouchUp += usrCtrlUserStory_TouchUp;

                cnvsUserStories.Children.Add(userControl);

                Canvas.SetLeft(userControl, 5);
                Canvas.SetTop(userControl, 60 * i);
            }
        }
        private void UserStoryEditing(UserStory userStory)
        {
            UserStoryEdit userStoryEdit = new UserStoryEdit(userStory, currentProject, controller);
            if (userStoryEdit.ShowDialog() == true)
            {
                controller.UpdateUserStory(userStoryEdit.tbxDesc.Text, userStoryEdit.dtpckrDateLimit.SelectedDate, Convert.ToInt32(userStoryEdit.tbxComplexity.Text), Convert.ToInt32(userStoryEdit.tbxCompletedComplexity.Text), userStoryEdit.chckBxBlocked.IsChecked == true, (Priority)userStoryEdit.cbxPriority.SelectedItem, (Classes.Type)userStoryEdit.cbxType.SelectedItem, userStory.State, userStory);
                Refresh();
            }
        }

        private void ProjectMenu_Loaded(object sender, RoutedEventArgs e)
        {
            //set controls sizes
            cnvsBacklog.Width = this.ActualWidth;
            cnvsBacklog.Height = this.ActualHeight;

            gbxUserStories.Width = (cnvsBacklog.Width - 25) / 2.0;
            gbxUserStories.Height = (cnvsBacklog.Height - 190);

            gbxSprints.Width = (cnvsBacklog.Width - 25) / 2.0;
            gbxSprints.Height = (cnvsBacklog.Height - 190);

            cnvsSprints.Width = gbxSprints.Width;
            cnvsSprints.Height = gbxSprints.Height - 25;

            cnvsUserStories.Width = gbxUserStories.Width;
            cnvsUserStories.Height = gbxUserStories.Height - 25;

            //Set controls positions
            Canvas.SetLeft(gbxSprints, cnvsBacklog.Width / 2.0 + 2.5);
            Canvas.SetRight(gbxUserStories, cnvsBacklog.Width / 2.0 - 2.5);

            Canvas.SetLeft(lblProjectName, (cnvsBacklog.Width - lblProjectName.ActualWidth) / 2.0);
            Canvas.SetLeft(lblBacklog, (cnvsBacklog.Width - lblBacklog.ActualWidth) / 2.0);

            Canvas.SetLeft(btnReturn, (cnvsBacklog.Width - btnReturn.ActualWidth) / 2.0);
            Canvas.SetTop(btnReturn, cnvsBacklog.Height - btnReturn.ActualHeight - 10);

            Canvas.SetLeft(btnAddSprint, Canvas.GetLeft(gbxSprints) + gbxSprints.Width / 2.0);
            Canvas.SetTop(btnAddSprint, Canvas.GetTop(gbxSprints) + gbxSprints.Height + 10);

            Canvas.SetLeft(btnAddUserStory, Canvas.GetLeft(gbxUserStories) + gbxUserStories.Width / 2.0);
            Canvas.SetTop(btnAddUserStory, Canvas.GetTop(gbxUserStories) + gbxUserStories.Height + 10);

            //Refresh the window
            Refresh();
        }
        private void userStory_MouseLeftButtonUp(object sender, EventArgs e)
        {
            UserStory userStory = (sender as UserControl).Tag as UserStory;
            UserStoryEditing(userStory);
        }
        private void sprint_Click(object sender, EventArgs e)
        {
            Sprint s = (sender as UserControl).Tag as Sprint;
            SprintMenu sprintMenu = new SprintMenu(s, controller);
            sprintMenu.ShowDialog();
        }
        private void Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAddUserStory_Click(object sender, EventArgs e)
        {
            UserStoryCreate userStoryCreate = new UserStoryCreate(controller);
            if (userStoryCreate.ShowDialog() == true)
            {
                controller.CreateUserStory(userStoryCreate.tbxDesc.Text, userStoryCreate.dtpckrDateLimit.SelectedDate, Convert.ToInt32(userStoryCreate.tbxComplexity.Text), (Priority)userStoryCreate.cbxPriority.SelectedItem, (Classes.Type)userStoryCreate.cbxType.SelectedItem, currentProject);
                Refresh();
            }
        }
        private void btnAddSprint_Click(object sender, EventArgs e)
        {
            SprintCreate sprintCreate = new SprintCreate();
            if (sprintCreate.ShowDialog() == true)
            {
                controller.CreateSprint((DateTime)sprintCreate.dtpckDateBegin.SelectedDate, (DateTime)sprintCreate.dtpckDateEnd.SelectedDate, currentProject);
                Refresh();
            }
        }
        private void sprint_DragLeave(object sender, DragEventArgs e)
        {
            UserControl userControl = sender as UserControl;
            userControl.BorderThickness = new Thickness(1);
        }
        private void sprint_DragEnter(object sender, DragEventArgs e)
        {
            UserControl userControl = sender as UserControl;
            userControl.BorderThickness = new Thickness(3);
        }
        private void sprint_Drop(object sender, DragEventArgs e)
        {
            UserControl userControl = sender as UserControl;
            userControl.BorderThickness = new Thickness(1);

            Sprint sprint = userControl.Tag as Sprint;
            UserStory userStory = e.Data.GetData("drag") as UserStory;

            controller.AddUserStoryToSprint(userStory, sprint);
        }
        private void userStory_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (startPoint.ContainsKey(e.Device))
            {
                startPoint.Remove(e.Device);
            }
            startPoint.Add(e.Device, e.GetTouchPoint(null).Position);
        }
        private void userStory_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            if (startPoint.ContainsKey(e.Device))
            {
                Point position = e.GetTouchPoint(null).Position;
                Vector diff = startPoint[e.Device] - position;

                if (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance || Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance)
                {
                    //extract data
                    UserControl userControl = sender as UserControl;
                    UserStory userStory = userControl.Tag as UserStory;

                    //Drag'n'drop init
                    DataObject dragData = new DataObject("drag", userStory);
                    DragDrop.DoDragDrop(userControl, dragData, DragDropEffects.Move);
                }
            }
        }
        private void usrCtrlUserStory_TouchUp(object sender, TouchEventArgs e)
        {
            if (startPoint.ContainsKey(e.Device))
            {
                startPoint.Remove(e.Device);
            }
            else
            {
                UserStory userStory = (sender as UserControl).Tag as UserStory;
                UserStoryEditing(userStory);
            }
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            ProjectEdit projectEdit = new ProjectEdit(currentProject, controller);
            if (projectEdit.ShowDialog() == true)
            {
                controller.UpdateProject(projectEdit.tbxName.Text, projectEdit.tbxDesc.Text, (DateTime)projectEdit.dtpckrDateBegin.SelectedDate, currentProject);
                Refresh();
            }
        }
    }
}
