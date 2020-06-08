/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   SprintCreate.xaml.cs
 * Desc.    :   This file contains the logic in the SprintCreate view
 */
using System;
using System.Windows;

namespace Scrum_o_wall.Views
{
    /// <summary>
    /// Logique d'interaction pour SprintCreate.xaml
    /// </summary>
    public partial class SprintCreate : Window
    {
        public SprintCreate()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnAddProject_Click(object sender, EventArgs e)
        {
            if (dtpckDateBegin.SelectedDate != null && dtpckDateEnd.SelectedDate != null)
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
