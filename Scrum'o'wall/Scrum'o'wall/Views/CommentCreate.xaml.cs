/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   CommentCreate.xaml.cs
 * Desc.    :   This file contains the logic in the CommentCreate view
 */
using Scrum_o_wall.Classes;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Scrum_o_wall.Views
{
    /// <summary>
    /// Logique d'interaction pour CommentCreate.xaml
    /// </summary>
    public partial class CommentCreate : Window
    {
        public CommentCreate(List<User> assignedUsers)
        {
            InitializeComponent();
            foreach (User user in assignedUsers)
            {
                cbxAuthor.Items.Add(user);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = null;
            Close();
        }
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (cbxAuthor.SelectedItem != null && tbxContent.Text.Trim().Length > 0)
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
