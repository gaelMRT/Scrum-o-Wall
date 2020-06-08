/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   ChecklistCreate.xaml.cs
 * Desc.    :   This file contains the logic in the ChecklistCreate view
 */
using Scrum_o_wall.Classes;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Scrum_o_wall.Views
{
    /// <summary>
    /// Logique d'interaction pour ChecklistCreate.xaml
    /// </summary>
    public partial class ChecklistCreate : Window
    {
        public List<ChecklistItem> itemsToAdd;
        public ChecklistCreate()
        {
            InitializeComponent();

            itemsToAdd = new List<ChecklistItem>();

            Refresh();
        }

        private void Refresh()
        {
            listItems.Items.Clear();
            foreach (ChecklistItem item in itemsToAdd)
            {
                listItems.Items.Add(item);
            }
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            ChecklistItemCreate checklistItemCreate = new ChecklistItemCreate();
            if (checklistItemCreate.ShowDialog() == true)
            {
                string name = checklistItemCreate.tbxObjet.Text.Trim();
                ChecklistItem checklistItem = new ChecklistItem(-1, name, false, -1);

                itemsToAdd.Add(checklistItem);
                Refresh();
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (tbxName.Text.Trim().Length > 0 && listItems.Items.Count > 0)
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
