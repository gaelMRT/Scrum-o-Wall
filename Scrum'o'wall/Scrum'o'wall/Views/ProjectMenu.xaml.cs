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
        Project currentProject;
        Controller controller;
        List<UserControl> sprintUserControls = new List<UserControl>();
        Dictionary<InputDevice, Point> currentPoint = new Dictionary<InputDevice, Point>();
        Dictionary<InputDevice, UserControl> infos = new Dictionary<InputDevice, UserControl>();
        Dictionary<InputDevice, Border> borders = new Dictionary<InputDevice, Border>();

        public ProjectMenu(Project p, Controller ctrl)
        {
            InitializeComponent();
            currentProject = p;
            controller = ctrl;

            lblProjectName.Content = p.Name;

            Loaded += ProjectMenu_Loaded;
            PreviewTouchMove += userStory_PreviewTouchMove;
        }

        private void Refresh()
        {
            int nbSprints = currentProject.Sprints.Count;
            sprintUserControls.Clear();
            for (int i = 0; i < nbSprints; i++)
            {
                Sprint sprint = currentProject.Sprints[i];
                //Create Sprint frame
                UserControl sprintControl = new UserControl();
                sprintControl.Content = sprint.ToString();
                sprintControl.Width = cnvsSprints.Width - 40;
                sprintControl.BorderThickness = new Thickness(1);
                sprintControl.BorderBrush = Brushes.Black;
                sprintControl.Cursor = Cursors.Hand;
                sprintControl.Height = 50;
                sprintControl.Tag = sprint;
                sprintControl.MouseLeftButtonDown += sprint_Click;
                sprintControl.TouchDown += sprint_Click;
                sprintControl.TouchUp += sprint_TouchUp;
                sprintControl.TouchEnter += sprint_TouchEnter;
                sprintControl.TouchLeave += sprint_TouchLeave;
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

            int nbUserStories = currentProject.AllUserStories.Count;
            for (int i = 0; i < nbUserStories; i++)
            {
                UserStory userStory = currentProject.AllUserStories[i];
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
                userStoryControl.MouseLeftButtonUp += userStory_MouseLeftButtonUp;
                userStoryControl.PreviewTouchDown += userStory_PreviewTouchDown;
                userStoryControl.TouchUp += usrCtrlUserStory_TouchUp;

                Stylus.SetIsPressAndHoldEnabled(userStoryControl, false);

                cnvsUserStories.Children.Add(userStoryControl);

                Canvas.SetLeft(userStoryControl, 5);
                Canvas.SetTop(userStoryControl, 60 * i);
            }
        }

        private void sprint_TouchEnter(object sender, TouchEventArgs e)
        {
            if (currentPoint.ContainsKey(e.Device))
            {
                (sender as UserControl).BorderThickness = new Thickness(3);
            }
        }
        private void sprint_TouchLeave(object sender, TouchEventArgs e)
        {
            if (currentPoint.ContainsKey(e.Device))
            {
                (sender as UserControl).BorderThickness = new Thickness(1);
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
        private void sprint_TouchUp(object sender, TouchEventArgs e)
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
        private void userStory_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            Console.WriteLine("OK");
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
        private void userStory_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            if (currentPoint.ContainsKey(e.Device))
            {
                currentPoint[e.Device] = e.GetTouchPoint(null).Position;
                Console.WriteLine(String.Format("Point :{0},{1}", currentPoint[e.Device].X, currentPoint[e.Device].Y));


                Canvas.SetLeft(borders[e.Device], currentPoint[e.Device].X - borders[e.Device].Width / 2.0);
                Canvas.SetTop(borders[e.Device], currentPoint[e.Device].Y - borders[e.Device].Height / 2.0);
            }
        }
        private void usrCtrlUserStory_TouchUp(object sender, TouchEventArgs e)
        {
            if (currentPoint.ContainsKey(e.Device))
            {
                currentPoint.Remove(e.Device);
                borders.Remove(e.Device);
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
            ProjectEdit projectEdit = new ProjectEdit(currentProject, controller);
            if (projectEdit.ShowDialog() == true)
            {
                controller.UpdateProject(projectEdit.tbxName.Text, projectEdit.tbxDesc.Text, (DateTime)projectEdit.dtpckrDateBegin.SelectedDate, currentProject);
                Refresh();
            }
        }
    }
}
