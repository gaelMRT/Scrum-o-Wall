/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   ChecklistItemEdit.xaml.cs
 * Desc.    :   This file contains the logic in the ChecklistItemEdit view
 */
using Scrum_o_wall.Classes;
using System;
using System.Windows;

namespace Scrum_o_wall.Views
{
    /// <summary>
    /// Logique d'interaction pour ChecklistItemEdit.xaml
    /// </summary>
    public partial class ChecklistItemEdit : Window
    {
        private readonly ChecklistItem checklistItem;
        private readonly Controller controller;
        private readonly UserStory userStory;
        public bool Deleted = false;

        public ChecklistItemEdit(ChecklistItem aChecklistItem, UserStory aUserStory, Controller aController)
        {
            checklistItem = aChecklistItem;
            controller = aController;
            userStory = aUserStory;

            InitializeComponent();

            tbxObjet.Text = checklistItem.NameItem;
            chkbxDone.IsChecked = checklistItem.Done;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = null;
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
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("L'objet de la liste sera supprimé.\nÊtes-vous sûr(e)?", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                DialogResult = true;
                Deleted = true;
                Close();
            }
        }
        private void BtnAssignedUsers_Click(object sender, EventArgs e)
        {
            UserMenu userMenu = new UserMenu(checklistItem, userStory.GetUsers(), controller);
            userMenu.ShowDialog();
        }

    }
}
