using Scrum_o_wall.Classes;
using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour BacklogMenu.xaml
    /// </summary>
    public partial class BacklogMenu : Window
    {
        Project currentProject;
        Controller controller;
        public BacklogMenu(Project p, Controller ctrl)
        {
            InitializeComponent();
            currentProject = p;
            controller = ctrl;

            lblProjectName.Content = p.Name;

            Loaded += BacklogMenu_Loaded;
        }

        private void BacklogMenu_Loaded(object sender, RoutedEventArgs e)
        {
            cnvsBacklog.Width = this.ActualWidth;
            cnvsBacklog.Height = this.ActualHeight;

            gbxUserStory.Width = (cnvsBacklog.Width - 25) / 2.0;
            gbxSprint.Width = (cnvsBacklog.Width - 25) / 2.0;
            gbxSprint.Height = (cnvsBacklog.Height - 190);
            gbxUserStory.Height = (cnvsBacklog.Height - 190);

            //Set controls positions
            Canvas.SetLeft(gbxSprint, cnvsBacklog.Width / 2.0 + 2.5);
            Canvas.SetRight(gbxUserStory, cnvsBacklog.Width / 2.0 - 2.5);

            Canvas.SetLeft(lblProjectName, (cnvsBacklog.Width - lblProjectName.ActualWidth) / 2.0);
            Canvas.SetLeft(lblBacklog, (cnvsBacklog.Width - lblBacklog.ActualWidth) / 2.0);

            Canvas.SetLeft(btnReturn, (cnvsBacklog.Width - btnReturn.ActualWidth) / 2.0);
            Canvas.SetTop(btnReturn, cnvsBacklog.Height - btnReturn.ActualHeight - 10);

            //Refresh the window
            Refresh();
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
                userControl.Width = gbxSprint.Width - 20;
                userControl.BorderBrush = Brushes.Black;
                userControl.Background = Brushes.LightGray;
                userControl.Cursor = Cursors.Hand;
                userControl.Height = 20;
                userControl.Tag = sprint;
                userControl.MouseUp += usrCtrlSprint_MouseUp;
                userControl.TouchUp += usrCtrlSprint_TouchUp;

                cnvsBacklog.Children.Add(userControl);

                Canvas.SetLeft(userControl, Canvas.GetLeft(gbxSprint) + 5);
                Canvas.SetTop(userControl, Canvas.GetTop(gbxSprint) + 30 + 30 * i);
            }

            int nbUserStories = currentProject.AllUserStories.Count;
            for (int i = 0; i < nbUserStories; i++)
            {
                UserStory userStory = currentProject.AllUserStories[i];
                //Create userStory frame
                UserControl userControl = new UserControl();
                userControl.Content = userStory.ToString();
                userControl.Width = gbxUserStory.Width - 20;
                userControl.BorderBrush = Brushes.Black;
                userControl.Background = Brushes.LightGray;
                userControl.Cursor = Cursors.Hand;
                userControl.Height = 20;
                userControl.Tag = userStory;
                userControl.MouseUp += usrCtrlUserStory_MouseUp;
                userControl.TouchUp += usrCtrlUserStory_TouchUp;

                cnvsBacklog.Children.Add(userControl);

                Canvas.SetLeft(userControl, Canvas.GetLeft(gbxUserStory) + 5);
                Canvas.SetTop(userControl, Canvas.GetTop(gbxUserStory) + 30 + 30 * i);
            }
        }


        private void usrCtrlUserStory_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //TODO : Modify User Story
            MessageBox.Show("Modification User Story", "Modif", MessageBoxButton.OK);
        }

        private void usrCtrlUserStory_TouchUp(object sender, TouchEventArgs e)
        {
            //TODO : Modify User Story
            MessageBox.Show("Modification User Story", "Modif", MessageBoxButton.OK);
        }

        private void usrCtrlSprint_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Sprint s = (sender as UserControl).Tag as Sprint;
            OpenSprint(s);
        }

        private void usrCtrlSprint_TouchUp(object sender, TouchEventArgs e)
        {
            Sprint s = (sender as UserControl).Tag as Sprint;
            OpenSprint(s);
        }
        private void OpenSprint(Sprint s)
        {
            SprintMenu sprintMenu = new SprintMenu(s, controller);
            sprintMenu.ShowDialog();
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
