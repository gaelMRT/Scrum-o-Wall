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
        Controller ctrl;
        public UserStoryEdit(UserStory aUserStory,Controller aController)
        {
            InitializeComponent();
            userStory = aUserStory;
            ctrl = aController;

            tbxDesc.Text = userStory.Text;
            dtpckrDateLimit.SelectedDate = userStory.DateLimit;
            tbxComplexity.Text = userStory.ComplexityEstimation.ToString();
            tbxCompletedComplexity.Text = userStory.CompletedComplexity.ToString();

            foreach (Priority p in ctrl.Priorities)
            {
                cbxPriority.Items.Add(p);
            }
            foreach (Classes.Type t in ctrl.Types)
            {
                cbxType.Items.Add(t);
            }

            chckBxBlocked.IsChecked = userStory.Blocked;
        }

        private void btnActivities_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUserAssigned_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnChecklists_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnComments_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFiles_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
