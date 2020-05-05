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

        }
        public void Refresh()
        {
            lstFiles.Items.Clear();
            foreach (File file in userStory.Files)
            {
                lstFiles.Items.Add(file);
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

        private void btnAddFile_Click(object sender, RoutedEventArgs e)
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
