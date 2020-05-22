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
    /// Logique d'interaction pour FileMenu.xaml
    /// </summary>
    public partial class FileMenu : Window
    {
        UserStory userStory;
        Controller controller;
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
                Border border = new Border();
                border.BorderBrush = Brushes.Black;
                border.BorderThickness = new Thickness(1);
                border.Width = 408;
                border.Tag = file;
                border.TouchDown += FileInList_Click;
                border.MouseLeftButtonDown += FileInList_Click;

                //Create grid
                Grid grd = new Grid();
                grd.Name = "lst" + file.Id.ToString();
                grd.RowDefinitions.Add(new RowDefinition());
                grd.RowDefinitions.Add(new RowDefinition());

                //Create element for name
                TextBlock textBlock = new TextBlock();
                textBlock.VerticalAlignment = VerticalAlignment.Top;
                textBlock.TextWrapping = TextWrapping.Wrap;
                textBlock.Margin = new Thickness(10);
                textBlock.TextAlignment = TextAlignment.Right;
                textBlock.Text = file.Name;

                //Create element for name
                TextBlock descBlock = new TextBlock();
                descBlock.VerticalAlignment = VerticalAlignment.Top;
                descBlock.TextWrapping = TextWrapping.Wrap;
                descBlock.Margin = new Thickness(10);
                descBlock.TextAlignment = TextAlignment.Right;
                descBlock.Text = file.Name;

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
            if(fileEdit.ShowDialog() == true)
            {
                controller.UpdateFile(fileEdit.tbxDescription.Text, file);
                Refresh();
            }
        }
        private void Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAddFile_Click(object sender, EventArgs e)
        {
            FileCreate fileCreate = new FileCreate();
            if(fileCreate.ShowDialog() == true)
            {
                controller.CreateFile(fileCreate.tbxFileName.Text, fileCreate.tbxDescription.Text, userStory);
                Refresh();
            }

        }
    }
}
