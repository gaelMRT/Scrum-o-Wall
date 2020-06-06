/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   ProjectMenu.xaml.cs
 * Desc.    :   This file contains the logic in the ProjectMenu view
 */
using Scrum_o_wall.Classes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        private readonly Project project;
        private readonly Controller controller;
        private List<UserControl> sprintUserControls = new List<UserControl>();
        private List<UserControl> userStoriesControls = new List<UserControl>();
        private List<UserControl> mindMapControls = new List<UserControl>();

        private Dictionary<InputDevice, Point> currentPoint = new Dictionary<InputDevice, Point>();
        private Dictionary<InputDevice, UserControl> infos = new Dictionary<InputDevice, UserControl>();

        public ProjectMenu(Project aProject, Controller aController)
        {
            InitializeComponent();
            project = aProject;
            controller = aController;

            lblProjectName.Content = aProject.Name;

            Loaded += ProjectMenu_Loaded;
            PreviewTouchMove += Canvas_PreviewTouchMove;
            TouchUp += Canvas_TouchUp;
        }

        private void Canvas_TouchUp(object sender, TouchEventArgs e)
        {
            if (currentPoint.ContainsKey(e.Device))
            {
                currentPoint.Remove(e.Device);
                infos.Remove(e.Device);
            }
        }

        private void Refresh()
        {
            int nbMindMaps = project.MindMaps.Count;
            foreach (UserControl mindmapControl in mindMapControls)
            {
                cnvsMindMaps.Children.Remove(mindmapControl);
            }
            mindMapControls.Clear();
            for (int i = 0; i < nbMindMaps; i++)
            {
                MindMap mindMap = project.MindMaps[i];
                //Create Sprint frame
                UserControl mindmapControl = new UserControl
                {
                    Content = mindMap.ToString(),
                    Width = cnvsMindMaps.Width - 40,
                    BorderThickness = new Thickness(1),
                    BorderBrush = Brushes.Black,
                    Cursor = Cursors.Hand,
                    Height = 50,
                    Tag = mindMap
                };
                mindmapControl.MouseDoubleClick += MindmapControl_Click;
                mindmapControl.TouchDown += MindmapControl_Click;

                cnvsMindMaps.Children.Add(mindmapControl);
                mindMapControls.Add(mindmapControl);

                Canvas.SetLeft(mindmapControl, 5);
                Canvas.SetTop(mindmapControl, 60 * i);
            }

            int nbSprints = project.Sprints.Count;
            foreach (UserControl sprintControl in sprintUserControls)
            {
                cnvsSprints.Children.Remove(sprintControl);
            }
            sprintUserControls.Clear();
            for (int i = 0; i < nbSprints; i++)
            {
                Sprint sprint = project.Sprints[i];
                //Create Sprint frame
                UserControl sprintControl = new UserControl
                {
                    Content = sprint.ToString(),
                    Width = cnvsSprints.Width - 40,
                    BorderThickness = new Thickness(1),
                    BorderBrush = Brushes.Black,
                    Cursor = Cursors.Hand,
                    Height = 50,
                    Tag = sprint
                };
                sprintControl.MouseDoubleClick += Sprint_Click;
                sprintControl.TouchDown += Sprint_Click;
                sprintControl.PreviewTouchUp += Sprint_PreviewTouchUp;
                sprintControl.TouchEnter += Sprint_TouchEnter;
                sprintControl.TouchLeave += Sprint_TouchLeave;
                //Change Color by DateRange
                if (DateTime.Now > sprint.Begin && DateTime.Now < sprint.End)
                {
                    //Actual
                    sprintControl.Background = Brushes.LightBlue;
                }
                else if (DateTime.Now < sprint.Begin)
                {
                    //Not beginned
                    sprintControl.Background = Brushes.LightGray;
                }
                else
                {
                    //Already passed
                    sprintControl.Background = Brushes.LightPink;
                }


                cnvsSprints.Children.Add(sprintControl);
                sprintUserControls.Add(sprintControl);

                Canvas.SetLeft(sprintControl, 5);
                Canvas.SetTop(sprintControl, 60 * i);
            }

            int nbUserStories = project.AllUserStories.Count;
            foreach (UserControl userStoryControl in userStoriesControls)
            {
                cnvsUserStories.Children.Remove(userStoryControl);
            }
            userStoriesControls.Clear();
            for (int i = 0; i < nbUserStories; i++)
            {
                UserStory userStory = project.AllUserStories[i];
                //Create userStory frame
                TextBlock content = new TextBlock
                {
                    Text = userStory.ToString(),
                    TextWrapping = TextWrapping.Wrap
                };
                UserControl userStoryControl = new UserControl
                {
                    Content = content,
                    Cursor = Cursors.Hand,
                    Height = 50,
                    Tag = userStory,
                    Width = cnvsUserStories.Width - 40,
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1)
                };
                // Change color by limit date (if exists and happened or not)
                if (userStory.DateLimit != null)
                {
                    if (DateTime.Now > userStory.DateLimit)
                    {
                        userStoryControl.Background = Brushes.LightPink;
                    }
                    else
                    {
                        userStoryControl.Background = Brushes.LightBlue;
                    }
                }
                else
                {
                    userStoryControl.Background = Brushes.LightGray;
                }
                userStoryControl.MouseDoubleClick += UserStory_MouseDoubleClick;
                userStoryControl.PreviewTouchDown += UserStory_PreviewTouchDown;
                userStoryControl.TouchUp += UsrCtrlUserStory_TouchUp;

                Stylus.SetIsPressAndHoldEnabled(userStoryControl, false);

                cnvsUserStories.Children.Add(userStoryControl);
                userStoriesControls.Add(userStoryControl);

                Canvas.SetLeft(userStoryControl, 5);
                Canvas.SetTop(userStoryControl, 60 * i);
            }
        }

        private void MindmapControl_Click(object sender, EventArgs e)
        {
            MindMap m = (sender as UserControl).Tag as MindMap;
            MindmapMenu mindmapMenu = new MindmapMenu(m, controller);
            mindmapMenu.ShowDialog();
            Refresh();
        }

        private void Sprint_TouchEnter(object sender, TouchEventArgs e)
        {
            if (currentPoint.ContainsKey(e.Device))
            {
                (sender as UserControl).BorderThickness = new Thickness(3);
            }
        }
        private void Sprint_TouchLeave(object sender, TouchEventArgs e)
        {
            if (currentPoint.ContainsKey(e.Device))
            {
                (sender as UserControl).BorderThickness = new Thickness(1);
            }
        }


        private void UserStoryEditing(UserStory userStory)
        {
            UserStoryEdit userStoryEdit = new UserStoryEdit(userStory, project, controller);

            if (userStoryEdit.ShowDialog() == true)
            {
                if (userStoryEdit.Deleted)
                {
                    controller.Delete(userStory);
                }
                else
                {
                    controller.UpdateUserStory(userStoryEdit.tbxDesc.Text.Trim(), userStoryEdit.dtpckrDateLimit.SelectedDate, Convert.ToInt32(userStoryEdit.tbxComplexity.Text), Convert.ToInt32(userStoryEdit.tbxCompletedComplexity.Text), userStoryEdit.chckBxBlocked.IsChecked == true, (Priority)userStoryEdit.cbxPriority.SelectedItem, (Classes.Type)userStoryEdit.cbxType.SelectedItem, userStory.State, userStory);
                }
                Refresh();
            }
        }

        private void ProjectMenu_Loaded(object sender, RoutedEventArgs e)
        {
            //set controls sizes
            cnvsBacklog.Width = ActualWidth;
            cnvsBacklog.Height = ActualHeight;

            gbxUserStories.Width = (cnvsBacklog.Width - 25) / 3.0;
            gbxUserStories.Height = (cnvsBacklog.Height - 250);

            gbxSprints.Width = (cnvsBacklog.Width - 25) / 3.0;
            gbxSprints.Height = (cnvsBacklog.Height - 250);

            gbxMindMap.Width = (cnvsBacklog.Width - 25) / 3.0;
            gbxMindMap.Height = (cnvsBacklog.Height - 250);

            cnvsMindMaps.Width = gbxMindMap.Width;
            cnvsMindMaps.Height = gbxMindMap.Height - 25;

            cnvsSprints.Width = gbxSprints.Width;
            cnvsSprints.Height = gbxSprints.Height - 25;

            cnvsUserStories.Width = gbxUserStories.Width;
            cnvsUserStories.Height = gbxUserStories.Height - 25;

            //Set controls positions
            Canvas.SetLeft(gbxUserStories, 10);
            Canvas.SetLeft(gbxSprints, gbxUserStories.Width + Canvas.GetLeft(gbxUserStories) + 5);
            Canvas.SetLeft(gbxMindMap, gbxSprints.Width + Canvas.GetLeft(gbxSprints) + 5);

            Canvas.SetLeft(lblProjectName, (cnvsBacklog.Width - lblProjectName.ActualWidth) / 2.0);
            Canvas.SetLeft(lblBacklog, (cnvsBacklog.Width - lblBacklog.ActualWidth) / 2.0);

            Canvas.SetLeft(btnReturn, (cnvsBacklog.Width - btnReturn.ActualWidth) / 2.0);
            Canvas.SetTop(btnReturn, cnvsBacklog.Height - btnReturn.ActualHeight - 10);

            Canvas.SetLeft(btnAddSprint, Canvas.GetLeft(gbxSprints) + (gbxSprints.Width - btnAddSprint.ActualWidth) / 2.0);
            Canvas.SetTop(btnAddSprint, Canvas.GetTop(gbxSprints) + gbxSprints.Height + 10);

            Canvas.SetLeft(btnAddMindMap, Canvas.GetLeft(gbxMindMap) + (gbxMindMap.Width - btnAddMindMap.ActualWidth) / 2.0);
            Canvas.SetTop(btnAddMindMap, Canvas.GetTop(gbxMindMap) + gbxMindMap.Height + 10);

            Canvas.SetLeft(btnAddUserStory, Canvas.GetLeft(gbxUserStories) + (gbxUserStories.Width - btnAddUserStory.ActualWidth) / 2.0);
            Canvas.SetTop(btnAddUserStory, Canvas.GetTop(gbxUserStories) + gbxUserStories.Height + 10);

            //Refresh the window
            Refresh();
        }
        private void UserStory_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UserStory userStory = (sender as UserControl).Tag as UserStory;
            UserStoryEditing(userStory);
        }
        private void Sprint_Click(object sender, EventArgs e)
        {
            Sprint s = (sender as UserControl).Tag as Sprint;
            SprintMenu sprintMenu = new SprintMenu(s, controller);
            sprintMenu.ShowDialog();
            Refresh();
        }
        private void Quit_Click(object sender, EventArgs e)
        {
            DialogResult = null;
            Close();
        }
        private void BtnAddUserStory_Click(object sender, EventArgs e)
        {
            UserStoryCreate userStoryCreate = new UserStoryCreate(controller);
            if (userStoryCreate.ShowDialog() == true)
            {
                controller.CreateUserStory(userStoryCreate.tbxDesc.Text.Trim(), userStoryCreate.dtpckrDateLimit.SelectedDate, Convert.ToInt32(userStoryCreate.tbxComplexity.Text), (Priority)userStoryCreate.cbxPriority.SelectedItem, (Classes.Type)userStoryCreate.cbxType.SelectedItem, project);
                Refresh();
            }
        }
        private void BtnAddSprint_Click(object sender, EventArgs e)
        {
            SprintCreate sprintCreate = new SprintCreate();
            if (sprintCreate.ShowDialog() == true)
            {
                controller.CreateSprint((DateTime)sprintCreate.dtpckDateBegin.SelectedDate, (DateTime)sprintCreate.dtpckDateEnd.SelectedDate, project);
                Refresh();
            }
        }
        private void BtnAddMindMap_Click(object sender, EventArgs e)
        {
            MindmapCreate mindmapCreate = new MindmapCreate();
            if (mindmapCreate.ShowDialog() == true)
            {
                controller.CreateMindMap(mindmapCreate.tbxName.Text.Trim(), project);
                Refresh();
            }
        }
        private void Sprint_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            if (currentPoint.ContainsKey(e.Device))
            {
                currentPoint[e.Device] = e.GetTouchPoint(null).Position;
                UserControl sprintControl = sender as UserControl;
                sprintControl.BorderThickness = new Thickness(1);
                double leftBound = Canvas.GetLeft(sprintControl) + Canvas.GetLeft(gbxSprints);
                double rightBound = leftBound + sprintControl.Width;
                double topBound = Canvas.GetTop(sprintControl) + Canvas.GetTop(cnvsSprints);
                double bottomBound = topBound + sprintControl.Height;

                Sprint sprint = sprintControl.Tag as Sprint;
                UserStory userStory = (infos[e.Device] as UserControl).Tag as UserStory;

                if (controller.AddUserStoryToSprint(userStory, sprint))
                {
                    Task.Factory.StartNew(() => MessageBox.Show("Enregistrement rajouté", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information));
                }
                else
                {
                    Task.Factory.StartNew(() => MessageBox.Show("Enregistrement déjà existant", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error));
                }

                currentPoint.Remove(e.Device);
                infos.Remove(e.Device);
            }
        }
        private void UserStory_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (currentPoint.ContainsKey(e.Device) || infos.ContainsKey(e.Device))
            {
                currentPoint.Remove(e.Device);
                infos.Remove(e.Device);
            }
            currentPoint.Add(e.Device, e.GetTouchPoint(null).Position);
            infos.Add(e.Device, sender as UserControl);
        }
        private void Canvas_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            if (currentPoint.ContainsKey(e.Device))
            {
                currentPoint[e.Device] = e.GetTouchPoint(null).Position;
            }
        }
        private void UsrCtrlUserStory_TouchUp(object sender, TouchEventArgs e)
        {
            if (currentPoint.ContainsKey(e.Device))
            {
                currentPoint.Remove(e.Device);
                infos.Remove(e.Device);
            }
            else
            {
                UserStory userStory = (sender as UserControl).Tag as UserStory;
                UserStoryEditing(userStory);
            }
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            ProjectEdit projectEdit = new ProjectEdit(project, controller);
            if (projectEdit.ShowDialog() == true)
            {
                if (projectEdit.Deleted)
                {
                    controller.Delete(project);
                    DialogResult = true;
                    Close();
                }
                else
                {
                    controller.UpdateProject(projectEdit.tbxName.Text.Trim(), projectEdit.tbxDesc.Text.Trim(), (DateTime)projectEdit.dtpckrDateBegin.SelectedDate, project);
                    Refresh();
                }
            }
        }

    }
}
