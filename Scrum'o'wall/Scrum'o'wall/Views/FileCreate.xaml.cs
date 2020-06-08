/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   FileCreate.xaml.cs
 * Desc.    :   This file contains the logic in the FileCreate view
 */
using Microsoft.Win32;
using System;
using System.Windows;

namespace Scrum_o_wall.Views
{
    /// <summary>
    /// Logique d'interaction pour FileCreate.xaml
    /// </summary>
    public partial class FileCreate : Window
    {
        public FileCreate()
        {
            InitializeComponent();
        }

        private void BtnFileSearch_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog
            {
                Multiselect = false
            };
            if (opf.ShowDialog() == true)
            {
                tbxFileName.Text = opf.FileName;
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            int descriptionLength = tbxDescription.Text.Trim().Length;
            int fileNameLength = tbxFileName.Text.Trim().Length;
            if (descriptionLength > 0 && fileNameLength > 0 && System.IO.File.Exists(tbxFileName.Text))
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
