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
        List<GroupBox> columns = new List<GroupBox>();
        List<UserControl> userStories = new List<UserControl>();

        Dictionary<InputDevice, Point> currentPoint = new Dictionary<InputDevice, Point>();
        Dictionary<InputDevice, UserControl> infos = new Dictionary<InputDevice, UserControl>();
        Dictionary<InputDevice, Border> borders = new Dictionary<InputDevice, Border>();
        public SprintMenu(Sprint aSprint, Controller aController)
        {
            InitializeComponent();
            sprint = aSprint;
            controller = aController;
            Loaded += SprintMenu_Loaded;
            PreviewTouchMove += sprintMenu_PreviewTouchMove;

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
            TouchUp += userStory_PreviewTouchUp;
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
            TextBlock content = new TextBlock();
            content.Text = userStory.ToString();
            content.TextWrapping = TextWrapping.Wrap;

            UserControl userControl = new UserControl();
            userControl.Content = content;
            userControl.Tag = userStory;
            userControl.Height = 50;
            userControl.Width = gbx.Width - 20;
            userControl.BorderBrush = Brushes.Black;
            userControl.Background = Brushes.LightGray;
            userControl.Cursor = Cursors.Hand;
            userControl.MouseUp += usrCtrlUserStory_Click;
            userControl.TouchUp += usrCtrlUserStory_Click;

            //Events for drag'n'drop
            userControl.PreviewTouchDown += userStory_PreviewTouchDown;
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
            cnvsSprint.Width = this.ActualWidth;
            cnvsSprint.Height = this.ActualHeight;

            //set control positions
            Canvas.SetLeft(lblProjectName, (cnvsSprint.Width - lblProjectName.ActualWidth) / 2.0);
            Canvas.SetLeft(lblSprintName, (cnvsSprint.Width - lblSprintName.ActualWidth) / 2.0);
            Canvas.SetLeft(btnBurndownChart, (cnvsSprint.Width) / 2.0 + btnBurndownChart.ActualWidth);
            Canvas.SetLeft(btnReturn, (cnvsSprint.Width) / 2.0 - btnReturn.ActualWidth);

            Refresh();
        }
        private void userStory_PreviewTouchUp(object sender, TouchEventArgs e)
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

                    currentPoint.Remove(e.Device);
                    infos.Remove(e.Device);
                    cnvsSprint.Children.Remove(borders[e.Device]);
                    borders.Remove(e.Device);
                    Refresh();
                }
            }
        }
        private void sprintMenu_PreviewTouchMove(object sender, TouchEventArgs e)
        {

            if (currentPoint.ContainsKey(e.Device))
            {
                currentPoint[e.Device] = e.GetTouchPoint(null).Position;

                Canvas.SetLeft(borders[e.Device], currentPoint[e.Device].X - borders[e.Device].Width / 2.0);
                Canvas.SetTop(borders[e.Device], currentPoint[e.Device].Y - borders[e.Device].Height / 2.0);
            }

            foreach (GroupBox col in columns)
            {
                col.BorderThickness = new Thickness(1);

            }
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
        private void userStory_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (currentPoint.ContainsKey(e.Device))
            {
                currentPoint.Remove(e.Device);
                borders.Remove(e.Device);
                infos.Remove(e.Device);
            }

            Border border = new Border()
            {
                Height = 40,
                Width = 100,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(2)
            };
            cnvsSprint.Children.Add(border);
            currentPoint.Add(e.Device, e.GetTouchPoint(null).Position);
            infos.Add(e.Device, sender as UserControl);
            borders.Add(e.Device, border);
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
        private void usrCtrlUserStory_Click(object sender, EventArgs e)
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
                    controller.UpdateUserStory(userStoryEdit.tbxDesc.Text, userStoryEdit.dtpckrDateLimit.SelectedDate, Convert.ToInt32(userStoryEdit.tbxComplexity.Text), Convert.ToInt32(userStoryEdit.tbxCompletedComplexity.Text), userStoryEdit.chckBxBlocked.IsChecked == true, (Priority)userStoryEdit.cbxPriority.SelectedItem, (Classes.Type)userStoryEdit.cbxType.SelectedItem, userStory.State, userStory);
                }
                Refresh();
            }
        }
        private void addColumn_Click(object sender, RoutedEventArgs e)
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
            this.DialogResult = null;
            this.Close();
        }

        private void btnEditSprint_Click(object sender, RoutedEventArgs e)
        {
            SprintEdit sprintEdit = new SprintEdit(sprint);
            if (sprintEdit.ShowDialog() == true)
            {
                if (sprintEdit.Deleted)
                {
                    controller.Delete(sprint);
                    this.DialogResult = true;
                    this.Close();
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
