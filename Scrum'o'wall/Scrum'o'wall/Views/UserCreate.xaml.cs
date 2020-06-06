/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   UserCreate.xaml.cs
 * Desc.    :   This file contains the logic in the UserCreate view
 */
using System;
using System.Windows;

namespace Scrum_o_wall.Views
{
    /// <summary>
    /// Logique d'interaction pour UserCreate.xaml
    /// </summary>
    public partial class UserCreate : Window
    {
        public UserCreate()
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
            if (tbxUserName.Text.Trim().Length > 0)
            {
                DialogResult = true;
                Close();
            }
        }

    }
}
