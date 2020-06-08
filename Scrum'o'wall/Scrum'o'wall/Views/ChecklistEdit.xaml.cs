/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   ChecklistEdit.xaml.cs
 * Desc.    :   This file contains the logic in the ChecklistEdit view
 */
using Scrum_o_wall.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Scrum_o_wall.Views
{
    /// <summary>
    /// Logique d'interaction pour ChecklistEdit.xaml
    /// </summary>
    public partial class ChecklistEdit : Window
    {
        private readonly Checklist checklist;
        private readonly Controller controller;
        private readonly UserStory userStory;
        private readonly List<ChecklistItem> itemsToAdd;
        public bool Deleted = false;
        public ChecklistEdit(Checklist aChecklist, UserStory aUserStory, Controller aController)
        {
            checklist = aChecklist;
            controller = aController;
            userStory = aUserStory;

            InitializeComponent();

            itemsToAdd = new List<ChecklistItem>();

            tbxName.Text = checklist.Name;
            listItems.MouseDoubleClick += ListItems_MouseDoubleClick;

            Refresh();
        }

        private void Refresh()
        {
            listItems.Items.Clear();
            foreach (ChecklistItem item in checklist.ChecklistItems)
            {
                listItems.Items.Add(item);
            }
            foreach (ChecklistItem item in itemsToAdd)
            {
                listItems.Items.Add(item);
            }
        }

        private void ListItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListView lstView = sender as ListView;
            ChecklistItem checklistItem = lstView.SelectedItem as ChecklistItem;
            if (checklist.ChecklistItems.Contains(checklistItem))
            {
                ChecklistItemEdit checklistItemEdit = new ChecklistItemEdit(checklistItem, userStory, controller);
                if (checklistItemEdit.ShowDialog() == true)
                {
                    if (checklistItemEdit.Deleted)
                    {
                        controller.Delete(checklistItem);
                    }
                    else
                    {
                        string objet = checklistItemEdit.tbxObjet.Text.Trim();
                        bool done = checklistItemEdit.chkbxDone.IsChecked == true;
                        controller.UpdateCheckListItem(objet, done, checklistItem);
                    }
                    Refresh();
                }
            }
        }
        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            ChecklistItemCreate checklistItemCreate = new ChecklistItemCreate();
            if (checklistItemCreate.ShowDialog() == true)
            {
                ChecklistItem checklistItem = new ChecklistItem(-1, checklistItemCreate.tbxObjet.Text.Trim(), false, -1);

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
                MessageBox.Show("Le nom n'est pas rempli ou il n'y a aucun objet dans la liste.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("La liste sera supprimée.\nÊtes-vous sûr(e)?", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Deleted = true;
                DialogResult = true;
                Close();
            }
        }
    }
}
