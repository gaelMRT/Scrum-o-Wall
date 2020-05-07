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
    /// Logique d'interaction pour ChecklistMenu.xaml
    /// </summary>
    public partial class ChecklistMenu : Window
    {
        UserStory userStory;
        Controller controller;
        public ChecklistMenu(UserStory aUserStory, Controller aController)
        {
            controller = aController;
            userStory = aUserStory;

            InitializeComponent();

            Refresh();
        }

        private void Refresh()
        {
            ColumnDefinition col1 = new ColumnDefinition();
            col1.Width = new GridLength(30, GridUnitType.Star);
            ColumnDefinition col2 = new ColumnDefinition();
            col2.Width = new GridLength(67, GridUnitType.Star);

            foreach (Checklist chckLst in userStory.Checklists)
            {
                //Create border
                Border border = new Border();
                border.BorderBrush = Brushes.Black;
                border.BorderThickness = new Thickness(1);
                border.Width = 408;
                border.Tag = chckLst;
                border.TouchDown += Border_TouchDown;

                //Create grid
                Grid grd = new Grid();
                grd.Name = "lst" + chckLst.Id.ToString();
                grd.ColumnDefinitions.Add(col1);
                grd.ColumnDefinitions.Add(col2);

                //Create element for name
                TextBlock textBlock = new TextBlock();
                textBlock.VerticalAlignment = VerticalAlignment.Top;
                textBlock.TextWrapping = TextWrapping.Wrap;
                textBlock.Margin = new Thickness(10);
                textBlock.TextAlignment = TextAlignment.Right;
                textBlock.Text = chckLst.Name;

                //Create element for list
                ListView lstView = new ListView();
                lstView.VerticalAlignment = VerticalAlignment.Top;
                lstView.Margin = new Thickness(10);
                lstView.Height = 26 * chckLst.ChecklistItems.Count;
                foreach (ChecklistItem item in chckLst.ChecklistItems)
                {
                    CheckBox checkBox = new CheckBox();
                    checkBox.IsChecked = item.Done;
                    checkBox.Content = item.NameItem;
                    lstView.Items.Add(checkBox);
                }

                grd.Children.Add(textBlock);
                grd.Children.Add(lstView);
                Grid.SetColumn(lstView, 1);
                border.Child = grd;

                lstLists.Items.Add(border);
            }
        }

        private void Border_TouchDown(object sender, TouchEventArgs e)
        {
            Checklist checklist = (sender as Border).Tag as Checklist;
            ChecklistEdit checklistEdit = new ChecklistEdit(checklist, controller);
            if(checklistEdit.ShowDialog() == true)
            {
                List<ChecklistItem> items = new List<ChecklistItem>();
                foreach (var item in checklistEdit.listItems.Items)
                {
                    items.Add(item as ChecklistItem);
                }
                controller.UpdateCheckList(checklistEdit.tbxName.Text, items, checklist);
                Refresh();
            }
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddList_Click(object sender, RoutedEventArgs e)
        {
            ChecklistCreate checklistCreate = new ChecklistCreate();
            if(checklistCreate.ShowDialog() == true)
            {
                Checklist checklist = controller.CreateCheckList(checklistCreate.tbxName.Text,userStory);
                foreach (CheckBox item in checklistCreate.listItems.Items)
                {
                    controller.CreateCheckListItem(item.Content.ToString(), checklist);
                }
                Refresh();
            }
        }
    }
}
