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
    /// Logique d'interaction pour UserStoryEdit.xaml
    /// </summary>
    public partial class UserStoryEdit : Window
    {
        UserStory userStory;
        Controller controller;
        public UserStoryEdit(UserStory aUserStory,Controller aController)
        {
            InitializeComponent();
            userStory = aUserStory;
            controller = aController;

            tbxDesc.Text = userStory.Text;
            dtpckrDateLimit.SelectedDate = userStory.DateLimit;
            tbxComplexity.Text = userStory.ComplexityEstimation.ToString();
            tbxCompletedComplexity.Text = userStory.CompletedComplexity.ToString();

            foreach (Priority p in controller.Priorities)
            {
                cbxPriority.Items.Add(p);
            }
            foreach (Classes.Type t in controller.Types)
            {
                cbxType.Items.Add(t);
            }


            cbxPriority.SelectedItem = userStory.Priority;
            cbxType.SelectedItem = userStory.Type;

            chckBxBlocked.IsChecked = userStory.Blocked;
        }

        private void btnActivities_Click(object sender, RoutedEventArgs e)
        {
            ActivitiesMenu activitiesMenu = new ActivitiesMenu(userStory.Activities);
            activitiesMenu.ShowDialog();
        }

        private void btnUserAssigned_Click(object sender, RoutedEventArgs e)
        {
            UserMenu userMenu = new UserMenu(userStory, controller);
            userMenu.ShowDialog();
        }

        private void btnChecklists_Click(object sender, RoutedEventArgs e)
        {
            ChecklistMenu checklistMenu = new ChecklistMenu(userStory, controller);
            checklistMenu.ShowDialog();
        }

        private void btnComments_Click(object sender, RoutedEventArgs e)
        {
            CommentMenu commentMenu = new CommentMenu(userStory, controller);
            commentMenu.ShowDialog();
        }

        private void btnFiles_Click(object sender, RoutedEventArgs e)
        {
            FileMenu fileMenu = new FileMenu(userStory, controller);
            fileMenu.ShowDialog();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if(tbxCompletedComplexity.Text.Length > 0 && tbxComplexity.Text.Length > 0 && tbxDesc.Text.Length > 0)
            {
                this.DialogResult = true;
                this.Close();
            }
        }
        private void tbxComplexity_KeyDown(object sender, KeyEventArgs e)
        {
            bool isNumber = (e.Key >= Key.D0 && e.Key <= Key.D9);
            if (!isNumber)
            {
                e.Handled = true;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
