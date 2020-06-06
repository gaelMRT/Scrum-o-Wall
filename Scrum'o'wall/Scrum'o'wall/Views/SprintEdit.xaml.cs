/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   SprintEdit.xaml.cs
 * Desc.    :   This file contains the logic in the SprintEdit view
 */
using Scrum_o_wall.Classes;
using System;
using System.Windows;

namespace Scrum_o_wall.Views
{
    /// <summary>
    /// Logique d'interaction pour SprintEdit.xaml
    /// </summary>
    public partial class SprintEdit : Window
    {
        private readonly Sprint sprint;
        public bool Deleted = false;
        public SprintEdit(Sprint aSprint)
        {
            sprint = aSprint;
            InitializeComponent();

            dtpckDateBegin.SelectedDate = sprint.Begin;
            dtpckDateEnd.SelectedDate = sprint.End;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = null;
            Close();
        }
        private void BtnConfirm_Click(object sender, EventArgs e)
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
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Le sprint sera supprimé.\nÊtes-vous sûr(e)?", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                DialogResult = true;
                Deleted = true;
                Close();
            }
        }

    }
}
