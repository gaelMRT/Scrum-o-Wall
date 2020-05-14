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
        public ProjectEdit(Project aProject, Controller aController)
        {
            project = aProject;
            controller = aController;

            InitializeComponent();

            tbxDesc.Text = project.Description;
            tbxName.Text = project.Name;
            dtpckrDateBegin.SelectedDate = project.Begin;
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if(dtpckrDateBegin.SelectedDate != null && tbxDesc.Text.Length > 0 && tbxName.Text.Length > 0)
            {
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Un ou plusieurs champ(s) n'est pas rempli !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnStates_Click(object sender, RoutedEventArgs e)
        {
            StateMenu stateMenu = new StateMenu(project,controller);
            stateMenu.ShowDialog();
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            UserMenu userMenu = new UserMenu(project,controller);
            userMenu.ShowDialog();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnStates_TouchDown(object sender, TouchEventArgs e)
        {
            StateMenu stateMenu = new StateMenu(project, controller);
            stateMenu.ShowDialog();
        }

        private void btnUsers_TouchDown(object sender, TouchEventArgs e)
        {
            UserMenu userMenu = new UserMenu(project, controller);
            userMenu.ShowDialog();
        }

        private void btnCancel_TouchDown(object sender, TouchEventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_TouchDown(object sender, TouchEventArgs e)
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
    }
}
