﻿/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   ProjectEdit.xaml.cs
 * Desc.    :   This file contains the logic in the ProjectEdit view
 */
using Scrum_o_wall.Classes;
using System;
using System.Windows;

namespace Scrum_o_wall.Views
{
    /// <summary>
    /// Logique d'interaction pour ProjectEdit.xaml
    /// </summary>
    public partial class ProjectEdit : Window
    {
        private readonly Project project;
        public bool Deleted = false;
        private readonly Controller controller;
        public ProjectEdit(Project aProject, Controller aController)
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
            if (dtpckrDateBegin.SelectedDate != null && tbxDesc.Text.Trim().Length > 0 && tbxName.Text.Trim().Length > 0)
            {
                DialogResult = true;
                Close();
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
            DialogResult = null;
            Close();
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Le projet sera supprimé.\nÊtes-vous sûr(e)?", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                DialogResult = true;
                Deleted = true;
                Close();
            }
        }

    }
}
