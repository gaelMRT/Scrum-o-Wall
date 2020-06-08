/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   StateEdit.xaml.cs
 * Desc.    :   This file contains the logic in the StateEdit view
 */
using Scrum_o_wall.Classes;
using System;
using System.Windows;

namespace Scrum_o_wall.Views
{
    /// <summary>
    /// Logique d'interaction pour StateEdit.xaml
    /// </summary>
    public partial class StateEdit : Window
    {
        private readonly State state;
        public bool Deleted = false;
        public StateEdit(State aState)
        {
            state = aState;
            InitializeComponent();

            tbxStateName.Text = state.Name;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (tbxStateName.Text.Trim().Length > 0)
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
            if (MessageBox.Show("L'état sera supprimé.\nÊtes-vous sûr(e)?", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                DialogResult = true;
                Deleted = true;
                Close();
            }
        }

    }
}
