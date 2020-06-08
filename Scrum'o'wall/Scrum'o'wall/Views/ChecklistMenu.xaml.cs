/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   ChecklistMenu.xaml.cs
 * Desc.    :   This file contains the logic in the ChecklistMenu view
 */
using Scrum_o_wall.Classes;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Scrum_o_wall.Views
{
    /// <summary>
    /// Logique d'interaction pour ChecklistMenu.xaml
    /// </summary>
    public partial class ChecklistMenu : Window
    {
        private readonly UserStory userStory;
        private readonly Controller controller;
        public ChecklistMenu(UserStory aUserStory, Controller aController)
        {
            controller = aController;
            userStory = aUserStory;

            InitializeComponent();

            Refresh();
        }

        private void Refresh()
        {
            lstLists.Items.Clear();
            foreach (Checklist chckLst in userStory.Checklists)
            {
                ColumnDefinition col1 = new ColumnDefinition
                {
                    Width = new GridLength(30, GridUnitType.Star)
                };
                ColumnDefinition col2 = new ColumnDefinition
                {
                    Width = new GridLength(67, GridUnitType.Star)
                };

                //Create border
                Border border = new Border
                {
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1),
                    Width = 390,
                    Tag = chckLst
                };

                //Create grid
                Grid grd = new Grid
                {
                    Name = "lst" + chckLst.Id.ToString()
                };
                grd.ColumnDefinitions.Add(col1);
                grd.ColumnDefinitions.Add(col2);
                grd.RowDefinitions.Add(new RowDefinition());
                grd.RowDefinitions.Add(new RowDefinition());

                //Create element for name
                TextBlock textBlock = new TextBlock
                {
                    VerticalAlignment = VerticalAlignment.Top,
                    TextWrapping = TextWrapping.Wrap,
                    Margin = new Thickness(10),
                    TextAlignment = TextAlignment.Right,
                    Text = chckLst.Name
                };

                //Create element for list
                ListView lstView = new ListView
                {
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(10),
                    Height = 26 * chckLst.ChecklistItems.Count
                };
                foreach (ChecklistItem item in chckLst.ChecklistItems)
                {
                    CheckBox checkBox = new CheckBox
                    {
                        IsChecked = item.Done,
                        Content = item.NameItem,
                        Tag = item
                    };
                    checkBox.Checked += ChecklistItem_Checked;
                    lstView.Items.Add(checkBox);
                }

                grd.Children.Add(textBlock);
                grd.Children.Add(lstView);
                Grid.SetRowSpan(lstView, 2);
                Grid.SetColumn(lstView, 1);
                border.Child = grd;

                lstLists.Items.Add(border);
            }
        }

        private void ChecklistItem_Checked(object sender, RoutedEventArgs e)
        {
            ChecklistItem item = (sender as CheckBox).Tag as ChecklistItem;
            item.Done = (sender as CheckBox).IsChecked == true;
            controller.UpdateCheckListItem(item.NameItem, item.Done, item);
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnAddList_Click(object sender, EventArgs e)
        {
            ChecklistCreate checklistCreate = new ChecklistCreate();
            if (checklistCreate.ShowDialog() == true)
            {
                string name = checklistCreate.tbxName.Text.Trim();
                Checklist checklist = controller.CreateCheckList(name, userStory);
                foreach (ChecklistItem item in checklistCreate.itemsToAdd)
                {
                    controller.CreateCheckListItem(item.NameItem, checklist);
                }
                Refresh();
            }
        }

        private void lstLists_TouchUp(object sender, EventArgs e)
        {
            if(lstLists.SelectedItem != null)
            {
                Checklist checklist = (lstLists.SelectedItem as Border).Tag as Checklist;
                ChecklistEdit checklistEdit = new ChecklistEdit(checklist, userStory, controller);
                if (checklistEdit.ShowDialog() == true)
                {
                    if (checklistEdit.Deleted)
                    {
                        controller.Delete(checklist);
                    }
                    else
                    {
                        List<ChecklistItem> items = new List<ChecklistItem>();
                        foreach (object item in checklistEdit.listItems.Items)
                        {
                            items.Add(item as ChecklistItem);
                        }
                        string name = checklistEdit.tbxName.Text.Trim();
                        controller.UpdateCheckList(name, items, checklist);
                    }
                    Refresh();
                }
            }
        }

    }
}
