/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   UserEdit.xaml.cs
 * Desc.    :   This file contains the logic in the UserEdit view
 */
using Scrum_o_wall.Classes;
using System;
using System.Windows;

namespace Scrum_o_wall.Views
{
    /// <summary>
    /// Logique d'interaction pour UserEdit.xaml
    /// </summary>
    public partial class UserEdit : Window
    {
        private readonly User user;
        public bool Deleted = false;
        public UserEdit(User aUser)
        {
            user = aUser;

            InitializeComponent();

            tbxUserName.Text = user.Name;
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (tbxUserName.Text.Trim().Length > 0)
            {
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Un ou plusieurs champ(s) n'est pas rempli !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("L'utilisateur sera supprimé.\nÊtes-vous sûr(e)?", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Deleted = true;
                DialogResult = true;
                Close();
            }
        }

    }
}
