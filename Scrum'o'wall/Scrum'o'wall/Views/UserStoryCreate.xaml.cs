/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   UserStoryCreate.xaml.cs
 * Desc.    :   This file contains the logic in the UserStoryCreate view
 */
using Scrum_o_wall.Classes;
using System;
using System.Windows;
using System.Windows.Input;

namespace Scrum_o_wall.Views
{
    /// <summary>
    /// Logique d'interaction pour UserStoryCreate.xaml
    /// </summary>
    public partial class UserStoryCreate : Window
    {
        public UserStoryCreate(Controller aController)
        {
            InitializeComponent();

            foreach (Priority priority in aController.Priorities)
            {
                cbxPriority.Items.Add(priority);
            }
            foreach (Classes.Type type in aController.Types)
            {
                cbxType.Items.Add(type);
            }
        }

        private void TbxComplexity_KeyDown(object sender, KeyEventArgs e)
        {
            bool isNumber = (e.Key >= Key.D0 && e.Key <= Key.D9);
            if (!isNumber)
            {
                e.Handled = true;
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = null;
            Close();
        }
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (tbxDesc.Text.Trim().Length > 0 && tbxComplexity.Text.Trim().Length > 0 && cbxPriority.SelectedIndex >= 0 && cbxType.SelectedIndex >= 0)
            {
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Un ou plusieurs champ(s) n'est pas rempli !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
