/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   FileMenu.xaml.cs
 * Desc.    :   This file contains the logic in the FileMenu view
 */
using Scrum_o_wall.Classes;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Scrum_o_wall.Views
{
    /// <summary>
    /// Logique d'interaction pour FileMenu.xaml
    /// </summary>
    public partial class FileMenu : Window
    {
        private readonly UserStory userStory;
        private readonly Controller controller;
        public FileMenu(UserStory aUserStory, Controller aController)
        {
            userStory = aUserStory;
            controller = aController;


            InitializeComponent();

            Refresh();
        }

        public void Refresh()
        {
            lstFiles.Items.Clear();
            foreach (File file in userStory.Files)
            {
                //Create border
                Border border = new Border
                {
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1),
                    Width = 408,
                    Tag = file
                };
                border.TouchDown += FileInList_Click;
                border.MouseLeftButtonDown += FileInList_Click;

                //Create grid
                Grid grd = new Grid
                {
                    Name = "lst" + file.Id.ToString()
                };
                grd.RowDefinitions.Add(new RowDefinition());
                grd.RowDefinitions.Add(new RowDefinition());

                //Create element for name
                TextBlock textBlock = new TextBlock
                {
                    VerticalAlignment = VerticalAlignment.Top,
                    TextWrapping = TextWrapping.Wrap,
                    Margin = new Thickness(10),
                    TextAlignment = TextAlignment.Right,
                    Text = file.Name
                };

                //Create element for name
                TextBlock descBlock = new TextBlock
                {
                    VerticalAlignment = VerticalAlignment.Top,
                    TextWrapping = TextWrapping.Wrap,
                    Margin = new Thickness(10),
                    TextAlignment = TextAlignment.Right,
                    Text = file.Name
                };

                grd.Children.Add(textBlock);
                grd.Children.Add(descBlock);
                Grid.SetColumn(descBlock, 1);
                border.Child = grd;

                lstFiles.Items.Add(file);
            }
        }

        private void FileInList_Click(object sender, EventArgs e)
        {
            File file = (sender as Border).Tag as File;
            FileEdit fileEdit = new FileEdit(file);
            if (fileEdit.ShowDialog() == true)
            {
                if (fileEdit.Deleted)
                {
                    controller.Delete(file);
                }
                else
                {
                    controller.UpdateFile(fileEdit.tbxDescription.Text.Trim(), file);
                }
                Refresh();
            }
            if (fileEdit.ShowDialog() == true)
            {
                controller.UpdateFile(fileEdit.tbxDescription.Text.Trim(), file);
            }
            Refresh();
        }
        private void Quit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnAddFile_Click(object sender, EventArgs e)
        {
            FileCreate fileCreate = new FileCreate();
            if (fileCreate.ShowDialog() == true)
            {
                string fileName = fileCreate.tbxFileName.Text.Trim();
                string description = fileCreate.tbxDescription.Text.Trim();
                controller.CreateFile(fileName, description, userStory);
                Refresh();
            }

        }

        private void LstFiles_MouseDoubleClick(object sender, EventArgs e)
        {
            ListBox lbx = sender as ListBox;
            if (lbx.SelectedItem != null)
            {
                File file = lbx.SelectedItem as File;
                FileEdit fileEdit = new FileEdit(file);
                if (fileEdit.ShowDialog() == true)
                {
                    if (fileEdit.Deleted)
                    {
                        controller.Delete(file);
                    }
                    else
                    {
                        controller.UpdateFile(fileEdit.tbxDescription.Text, file);
                    }
                    Refresh();
                }
            }
        }
    }
}
