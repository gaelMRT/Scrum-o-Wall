using Scrum_o_wall.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        Dictionary<InputDevice, Point> startPoint = new Dictionary<InputDevice, Point>();
        List<GroupBox> columns = new List<GroupBox>();
        List<UserControl> userStories = new List<UserControl>();
        public SprintMenu(Sprint aSprint, Controller aController)
        {
            InitializeComponent();
            sprint = aSprint;
            controller = aController;
            Loaded += SprintMenu_Loaded;

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
        private GroupBox CreateStateColumn(State state)
        {
            //Create the column
            GroupBox gbx = new GroupBox();
            gbx.Height = cnvsSprint.ActualHeight - 190;
            gbx.Width = cnvsSprint.ActualWidth / sprint.Project.States.Count;
            gbx.Name = "gbx" + state.Name.Replace(" ", "");
            gbx.Header = state.Name;
            gbx.Tag = state;
            gbx.BorderBrush = Brushes.Black;
            gbx.BorderThickness = new Thickness(1);

            //Needed for the drag'n'drop
            gbx.AllowDrop = true;
            gbx.Drop += state_Drop;
            gbx.DragEnter += state_DragEnter;
            gbx.DragLeave += state_DragLeave;

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
            GroupBox gbx = columns.Where(c => c.Tag == userStory.CurrentState).First();

            //Create userStory frame
            UserControl userControl = new UserControl();
            userControl.Content = userStory.ToString();
            userControl.Tag = userStory;
            userControl.Height = 20;
            userControl.Width = gbx.Width - 20;
            userControl.BorderBrush = Brushes.Black;
            userControl.Background = Brushes.LightGray;
            userControl.Cursor = Cursors.Hand;
            userControl.MouseUp += usrCtrlUserStory_MouseUp;
            userControl.TouchUp += usrCtrlUserStory_TouchUp;

            //Events for drag'n'drop
            userControl.PreviewTouchDown += userStory_PreviewTouchDown;
            userControl.PreviewTouchMove += userStory_PreviewTouchMove;

            //Add to lists, positionning and return
            cnvsSprint.Children.Add(userControl);
            Canvas.SetLeft(userControl, Canvas.GetLeft(gbx) + 10);
            Canvas.SetTop(userControl, Canvas.GetTop(gbx) + 30 + 30 * cptTop);
            userStories.Add(userControl);
            return userControl;
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
                CreateUserStoryControl(userStory, userStoriesPerState[userStory.CurrentState]);
                userStoriesPerState[userStory.CurrentState]++;
            }
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

        private void userStory_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            startPoint.Add(e.Device, e.GetTouchPoint(null).Position);
        }

        private void state_DragLeave(object sender, DragEventArgs e)
        {
            GroupBox gbx = sender as GroupBox;
            gbx.BorderThickness = new Thickness(1);
        }

        private void state_DragEnter(object sender, DragEventArgs e)
        {
            GroupBox gbx = sender as GroupBox;
            gbx.BorderThickness = new Thickness(5);
        }

        private void state_Drop(object sender, DragEventArgs e)
        {
            GroupBox gbx = sender as GroupBox;
            gbx.BorderThickness = new Thickness(1);

            //Make userStory switch
            State state = gbx.Tag as State;
            UserStory userStory = e.Data.GetData("drag") as UserStory;
            controller.UserStorySwitchState(userStory, state);

            Refresh();
        }
        private void usrCtrlUserStory_MouseUp(object sender, MouseButtonEventArgs e)
        {
            UserStory userStory = (sender as UserControl).Tag as UserStory;
            UserStoryEditing(userStory);
        }

        private void usrCtrlUserStory_TouchUp(object sender, TouchEventArgs e)
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
