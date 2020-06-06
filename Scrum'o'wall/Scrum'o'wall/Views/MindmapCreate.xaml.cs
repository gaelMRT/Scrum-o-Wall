/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   MindmapCreate.xaml.cs
 * Desc.    :   This file contains the logic in the MindmapCreate view
 */
using System;
using System.Windows;

namespace Scrum_o_wall.Views
{
    /// <summary>
    /// Logique d'interaction pour MindmapCreate.xaml
    /// </summary>
    public partial class MindmapCreate : Window
    {
        public MindmapCreate()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = null;
            Close();
        }
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (tbxName.Text.Trim().Length > 0)
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
