/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   NodeCreate.xaml.cs
 * Desc.    :   This file contains the logic in the NodeCreate view
 */
using Scrum_o_wall.Classes;
using System;
using System.Windows;

namespace Scrum_o_wall.Views
{
    /// <summary>
    /// Logique d'interaction pour NodeCreate.xaml
    /// </summary>
    public partial class NodeCreate : Window
    {
        public NodeCreate(MindMap mindMap)
        {
            InitializeComponent();
            foreach (Node node in mindMap.GetAllNodes())
            {
                cbxPrevious.Items.Add(node);
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (tbxName.Text.Trim().Length > 0 && cbxPrevious.SelectedItem != null)
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
