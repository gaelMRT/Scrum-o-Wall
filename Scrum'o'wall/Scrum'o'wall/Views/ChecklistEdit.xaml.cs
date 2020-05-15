using Scrum_o_wall.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Scrum_o_wall.Views
{
    /// <summary>
    /// Logique d'interaction pour ChecklistEdit.xaml
    /// </summary>
    public partial class ChecklistEdit : Window
    {
        Checklist checklist;
        Controller controller;
        UserStory userStory;
        List<ChecklistItem> itemsToAdd;
        public ChecklistEdit(Checklist aChecklist,UserStory aUserStory,Controller aController)
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

        private void ListItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListView lstView = sender as ListView;
            ChecklistItem checklistItem = lstView.SelectedItem as ChecklistItem;
            if(checklist.ChecklistItems.Contains(checklistItem))
            {
                ChecklistItemEdit checklistItemEdit = new ChecklistItemEdit(checklistItem,userStory, controller);
                if(checklistItemEdit.ShowDialog() == true)
                {
                    controller.UpdateCheckListItem(checklistItemEdit.tbxObjet.Text, checklistItemEdit.chkbxDone.IsChecked == true, checklistItem);
                }
            }
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

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            ChecklistItemCreate checklistItemCreate = new ChecklistItemCreate();
            if (checklistItemCreate.ShowDialog() == true)
            {
                ChecklistItem checklistItem = new ChecklistItem(-1, checklistItemCreate.tbxObjet.Text, false, -1);

                itemsToAdd.Add(checklistItem);
                Refresh();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (tbxName.Text.Length > 0 && listItems.Items.Count > 0)
            {
                this.DialogResult = true;
                this.Close();
            }
            else
            {
            }
        }

        private void btnAddItem_TouchDown(object sender, TouchEventArgs e)
        {
            ChecklistItemCreate checklistItemCreate = new ChecklistItemCreate();
            if (checklistItemCreate.ShowDialog() == true)
            {
                ChecklistItem checklistItem = new ChecklistItem(-1, checklistItemCreate.tbxObjet.Text, false, -1);

                itemsToAdd.Add(checklistItem);
                Refresh();
            }
        }

        private void btnCancel_TouchDown(object sender, TouchEventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_TouchDown(object sender, TouchEventArgs e)
        {
            if (tbxName.Text.Length > 0 && listItems.Items.Count > 0)
            {
                this.DialogResult = true;
                this.Close();
            }
        }
    }
}
