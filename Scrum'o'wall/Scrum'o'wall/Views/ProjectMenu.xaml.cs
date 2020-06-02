using Scrum_o_wall.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
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
        Project project;
        Controller controller;
        List<UserControl> sprintUserControls = new List<UserControl>();
        List<UserControl> userStoriesControls = new List<UserControl>();
        List<UserControl> mindMapControls = new List<UserControl>();
        Dictionary<InputDevice, Point> currentPoint = new Dictionary<InputDevice, Point>();
        Dictionary<InputDevice, UserControl> infos = new Dictionary<InputDevice, UserControl>();
        Dictionary<InputDevice, Border> borders = new Dictionary<InputDevice, Border>();

        public ProjectMenu(Project aProject, Controller aController)
        {
            InitializeComponent();
            project = aProject;
            controller = aController;

            lblProjectName.Content = aProject.Name;

            Loaded += ProjectMenu_Loaded;
            PreviewTouchMove += UserStory_PreviewTouchMove;
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
                UserControl mindmapControl = new UserControl();
                mindmapControl.Content = mindMap.ToString();
                mindmapControl.Width = cnvsMindMaps.Width - 40;
                mindmapControl.BorderThickness = new Thickness(1);
                mindmapControl.BorderBrush = Brushes.Black;
                mindmapControl.Cursor = Cursors.Hand;
                mindmapControl.Height = 50;
                mindmapControl.Tag = mindMap;
                mindmapControl.MouseDoubleClick += MindmapControl_Click; 
                mindmapControl.TouchDown += MindmapControl_Click;

                cnvsMindMaps.Children.Add(mindmapControl);
                sprintUserControls.Add(mindmapControl);

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
                UserControl sprintControl = new UserControl();
                sprintControl.Content = sprint.ToString();
                sprintControl.Width = cnvsSprints.Width - 40;
                sprintControl.BorderThickness = new Thickness(1);
                sprintControl.BorderBrush = Brushes.Black;
                sprintControl.Cursor = Cursors.Hand;
                sprintControl.Height = 50;
                sprintControl.Tag = sprint;
                sprintControl.MouseDoubleClick += Sprint_Click;
                sprintControl.TouchDown += Sprint_Click;
                sprintControl.TouchUp += Sprint_TouchUp;
                sprintControl.TouchEnter += Sprint_TouchEnter;
                sprintControl.TouchLeave += Sprint_TouchLeave;
                sprintControl.AllowDrop = true;
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
                UserControl userStoryControl = new UserControl();
                userStoryControl.Content = userStory.ToString();
                userStoryControl.Width = cnvsUserStories.Width - 40;
                userStoryControl.BorderBrush = Brushes.Black;
                userStoryControl.BorderThickness = new Thickness(1);
                userStoryControl.Background = Brushes.LightGray;
                userStoryControl.Cursor = Cursors.Hand;
                userStoryControl.Height = 50;
                userStoryControl.Tag = userStory;
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
                    controller.UpdateUserStory(userStoryEdit.tbxDesc.Text, userStoryEdit.dtpckrDateLimit.SelectedDate, Convert.ToInt32(userStoryEdit.tbxComplexity.Text), Convert.ToInt32(userStoryEdit.tbxCompletedComplexity.Text), userStoryEdit.chckBxBlocked.IsChecked == true, (Priority)userStoryEdit.cbxPriority.SelectedItem, (Classes.Type)userStoryEdit.cbxType.SelectedItem, userStory.State, userStory);
                }
                Refresh();
            }
        }

        private void ProjectMenu_Loaded(object sender, RoutedEventArgs e)
        {
            //set controls sizes
            cnvsBacklog.Width = this.ActualWidth;
            cnvsBacklog.Height = this.ActualHeight;

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

            Canvas.SetLeft(btnAddSprint, Canvas.GetLeft(gbxSprints) + (gbxSprints.Width - btnAddSprint.ActualWidth) / 2.0 );
            Canvas.SetTop(btnAddSprint, Canvas.GetTop(gbxSprints) + gbxSprints.Height + 10);

            Canvas.SetLeft(btnAddMindMap, Canvas.GetLeft(gbxMindMap) + (gbxMindMap.Width - btnAddMindMap.ActualWidth) / 2.0);
            Canvas.SetTop(btnAddMindMap, Canvas.GetTop(gbxMindMap) + gbxMindMap.Height + 10);

            Canvas.SetLeft(btnAddUserStory, Canvas.GetLeft(gbxUserStories) + (gbxUserStories.Width - btnAddUserStory.ActualWidth) / 2.0);
            Canvas.SetTop(btnAddUserStory, Canvas.GetTop(gbxUserStories) + gbxUserStories.Height + 10);

            //Refresh the window
            Refresh();
        }
        private void UserStory_MouseDoubleClick(object sender, EventArgs e)
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
            this.DialogResult = null;
            this.Close();
        }
        private void BtnAddUserStory_Click(object sender, EventArgs e)
        {
            UserStoryCreate userStoryCreate = new UserStoryCreate(controller);
            if (userStoryCreate.ShowDialog() == true)
            {
                controller.CreateUserStory(userStoryCreate.tbxDesc.Text, userStoryCreate.dtpckrDateLimit.SelectedDate, Convert.ToInt32(userStoryCreate.tbxComplexity.Text), (Priority)userStoryCreate.cbxPriority.SelectedItem, (Classes.Type)userStoryCreate.cbxType.SelectedItem, project);
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
        private void btnAddMindMap_Click(object sender, EventArgs e)
        {
            MindmapCreate mindmapCreate = new MindmapCreate();
            if (mindmapCreate.ShowDialog() == true)
            {
                controller.CreateMindMap(mindmapCreate.tbxName.Text, project);
                Refresh();
            }
        }
        private void Sprint_TouchUp(object sender, TouchEventArgs e)
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
                cnvsBacklog.Children.Remove(borders[e.Device]);
                borders.Remove(e.Device);
            }
        }
        private void UserStory_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (currentPoint.ContainsKey(e.Device) || currentPoint.ContainsKey(e.Device) || infos.ContainsKey(e.Device))
            {
                currentPoint.Remove(e.Device);
                infos.Remove(e.Device);
                cnvsBacklog.Children.Remove(borders[e.Device]);
                borders.Remove(e.Device);
            }
            Border border = new Border()
            {
                Height = 40,
                Width = 100,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(2)
            };
            cnvsBacklog.Children.Add(border);
            currentPoint.Add(e.Device, e.GetTouchPoint(null).Position);
            infos.Add(e.Device, sender as UserControl);
            borders.Add(e.Device, border);
        }
        private void UserStory_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            if (currentPoint.ContainsKey(e.Device))
            {
                currentPoint[e.Device] = e.GetTouchPoint(null).Position;


                Canvas.SetLeft(borders[e.Device], currentPoint[e.Device].X - borders[e.Device].Width / 2.0);
                Canvas.SetTop(borders[e.Device], currentPoint[e.Device].Y - borders[e.Device].Height / 2.0);
            }
        }
        private void UsrCtrlUserStory_TouchUp(object sender, TouchEventArgs e)
        {
            if (currentPoint.ContainsKey(e.Device))
            {
                currentPoint.Remove(e.Device);
                infos.Remove(e.Device);
                cnvsBacklog.Children.Remove(borders[e.Device]);
                borders.Remove(e.Device);
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
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    controller.UpdateProject(projectEdit.tbxName.Text, projectEdit.tbxDesc.Text, (DateTime)projectEdit.dtpckrDateBegin.SelectedDate, project);
                    Refresh();
                }
            }
        }

    }
}
