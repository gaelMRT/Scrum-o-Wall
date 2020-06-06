/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   MindmapEdit.xaml.cs
 * Desc.    :   This file contains the logic in the MindmapEdit view
 */
using Scrum_o_wall.Classes;
using System;
using System.Windows;

namespace Scrum_o_wall.Views
{
    /// <summary>
    /// Logique d'interaction pour MindmapCreate.xaml
    /// </summary>
    public partial class MindmapEdit : Window
    {
        public bool Deleted = false;
        private MindMap mindMap;
        public MindmapEdit(MindMap aMindMap)
        {
            mindMap = aMindMap;
            InitializeComponent();
            tbxName.Text = mindMap.Name;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = null;
            Close();
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Le mindmap sera supprimé.\nÊtes-vous sûr(e)?", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Deleted = true;
                DialogResult = true;
                Close();
            }
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
