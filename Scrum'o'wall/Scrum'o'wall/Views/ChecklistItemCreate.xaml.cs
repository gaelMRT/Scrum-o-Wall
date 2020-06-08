/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   ChecklistItemCreate.xaml.cs
 * Desc.    :   This file contains the logic in the ChecklistItemCreate view
 */
using System;
using System.Windows;

namespace Scrum_o_wall.Views
{
    /// <summary>
    /// Logique d'interaction pour ChecklistItemCreate.xaml
    /// </summary>
    public partial class ChecklistItemCreate : Window
    {
        public ChecklistItemCreate()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (tbxObjet.Text.Trim().Length > 0)
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
