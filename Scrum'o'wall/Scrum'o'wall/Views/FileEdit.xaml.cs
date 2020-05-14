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
    /// Logique d'interaction pour FileEdit.xaml
    /// </summary>
    public partial class FileEdit : Window
    {
        Controller controller;
        File file;
        public FileEdit(File aFile, Controller aController)
        {
            file = aFile;

            controller = aController;

            InitializeComponent();

            foreach (FileType fileType in controller.FileTypes)
            {
                cbxFileTypes.Items.Add(fileType);
            }

            tbxDescription.Text = file.Description;
            tbxFileName.Text = file.Name;
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (tbxDescription.Text.Length > 1 && tbxFileName.Text.Length > 1 && System.IO.File.Exists(tbxFileName.Text) && cbxFileTypes.SelectedItem != null)
            {
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Un ou plusieurs champ(s) n'est pas rempli !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancel_TouchDown(object sender, TouchEventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_TouchDown(object sender, TouchEventArgs e)
        {
            if (tbxDescription.Text.Length > 1 && tbxFileName.Text.Length > 1 && System.IO.File.Exists(tbxFileName.Text) && cbxFileTypes.SelectedItem != null)
            {
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Un ou plusieurs champ(s) n'est pas rempli !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
