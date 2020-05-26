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
        Project project;

        public UserStoryEdit(UserStory aUserStory,Project aProject,Controller aController)
        {
            InitializeComponent();
            userStory = aUserStory;
            controller = aController;
            project = aProject;

            tbxDesc.Text = userStory.Description;
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

        private void TbxComplexity_KeyDown(object sender, KeyEventArgs e)
        {
            bool isNumber = (e.Key >= Key.D0 && e.Key <= Key.D9);
            if (!isNumber)
            {
                e.Handled = true;
            }
        }
        private void BtnActivities_Click(object sender, EventArgs e)
        {
            ActivitiesMenu activitiesMenu = new ActivitiesMenu(userStory.Activities);
            activitiesMenu.ShowDialog();
        }
        private void BtnUserAssigned_Click(object sender, EventArgs e)
        {
            UserMenu userMenu = new UserMenu(userStory,project.GetUsers(), controller);
            userMenu.ShowDialog();
        }
        private void BtnChecklists_Click(object sender, EventArgs e)
        {
            ChecklistMenu checklistMenu = new ChecklistMenu(userStory, controller);
            checklistMenu.ShowDialog();
        }
        private void BtnComments_Click(object sender, EventArgs e)
        {
            CommentMenu commentMenu = new CommentMenu(userStory, controller);
            commentMenu.ShowDialog();
        }
        private void BtnFiles_Click(object sender, EventArgs e)
        {
            FileMenu fileMenu = new FileMenu(userStory, controller);
            fileMenu.ShowDialog();
        }
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if(tbxCompletedComplexity.Text.Length > 0 && tbxComplexity.Text.Length > 0 && tbxDesc.Text.Length > 0)
            {
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Un ou plusieurs champ(s) n'est pas rempli !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("La liste sera supprimée.\nÊtes-vous sûr(e)?", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                this.DialogResult = false;
                this.Close();
            }
        }

    }
}
