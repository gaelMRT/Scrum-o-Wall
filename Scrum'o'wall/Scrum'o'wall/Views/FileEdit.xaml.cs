/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   FileEdit.xaml.cs
 * Desc.    :   This file contains the logic in the FileEdit view
 */
using Scrum_o_wall.Classes;
using System;
using System.Windows;

namespace Scrum_o_wall.Views
{
    /// <summary>
    /// Logique d'interaction pour FileEdit.xaml
    /// </summary>
    public partial class FileEdit : Window
    {
        private readonly File file;
        public bool Deleted = false;


        public FileEdit(File aFile)
        {
            file = aFile;

            InitializeComponent();

            tbxDescription.Text = file.Description;
            tbxFileName.Text = file.Name;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            int descriptionLength = tbxDescription.Text.Trim().Length;
            if (descriptionLength > 0)
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
            if (MessageBox.Show("Le fichier sera supprimé.\nÊtes-vous sûr(e)?", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                DialogResult = true;
                Deleted = true;
                Close();
            }
        }
    }
}
