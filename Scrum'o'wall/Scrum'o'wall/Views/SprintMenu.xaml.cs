using Scrum_o_wall.Classes;
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
        Sprint currentSprint;
        Controller controller;
        public SprintMenu(Sprint s,Controller ctrl)
        {
            InitializeComponent();
            currentSprint = s;
            controller = ctrl;
            Loaded += SprintMenu_Loaded;

            lblProjectName.Content = currentSprint.Project.Name;
            lblSprintName.Content = s.ToString();

            foreach (string state in currentSprint.Project.States)
            {
                GroupBox groupBox = new GroupBox();
                groupBox.Name = "gbx" + state.Replace(" ","");
                groupBox.Content = state;
                cnvsSprint.Children.Add(groupBox);
                Canvas.SetTop(groupBox, 100);
                Canvas.SetBottom(groupBox, 90);
            }
        }

        private void Refresh()
        {
            double leftPadding = 0;
            double widthGbx = cnvsSprint.ActualWidth / currentSprint.Project.States.Count;
            foreach (string state in currentSprint.Project.States)
            {

                object gbx = cnvsSprint.FindName("gbx" + state.Replace(" ", ""));
                GroupBox gbxState = (GroupBox)gbx;
                gbxState.Width = widthGbx;
                gbxState.Header = state;
                Canvas.SetLeft(gbxState, leftPadding);
                leftPadding += widthGbx;
            }
            foreach (UserStory u in currentSprint.UserStories)
            {

            }
        }
        private void SprintMenu_Loaded(object sender, RoutedEventArgs e)
        {
            cnvsSprint.Width = this.ActualWidth;
            cnvsSprint.Height = this.ActualHeight;

            //set control positions
            Canvas.SetLeft(lblProjectName, (cnvsSprint.Width - lblProjectName.ActualWidth) / 2.0);
            Canvas.SetLeft(lblSprintName, (cnvsSprint.Width - lblSprintName.ActualWidth) / 2.0);
            Canvas.SetLeft(btnBacklog, (cnvsSprint.Width) / 2.0 + btnBacklog.ActualWidth);
            Canvas.SetLeft(btnReturn, (cnvsSprint.Width) / 2.0 - btnReturn.ActualWidth);

            Refresh();
        }
        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
