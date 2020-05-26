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
    /// Logique d'interaction pour ProjectEdit.xaml
    /// </summary>
    public partial class ProjectEdit : Window
    {
        Project project;

        Controller controller;
        public ProjectEdit(Project aProject,Controller aController)
        {
            project = aProject;
            controller = aController;

            InitializeComponent();

            tbxDesc.Text = project.Description;
            tbxName.Text = project.Name;
            dtpckrDateBegin.SelectedDate = project.Begin;
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (dtpckrDateBegin.SelectedDate != null && tbxDesc.Text.Length > 0 && tbxName.Text.Length > 0)
            {
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Un ou plusieurs champ(s) n'est pas rempli !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void BtnStates_Click(object sender, EventArgs e)
        {
            StateMenu stateMenu = new StateMenu(project, controller);
            stateMenu.ShowDialog();
        }
        private void BtnUsers_Click(object sender, EventArgs e)
        {
            UserMenu userMenu = new UserMenu(project, controller.Users, controller);
            userMenu.ShowDialog();
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Le projet sera supprimé.\nÊtes-vous sûr(e)?", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                this.DialogResult = false;
                this.Close();
            }
        }

    }
}
