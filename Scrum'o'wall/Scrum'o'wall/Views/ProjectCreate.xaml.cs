/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   ProjectCreate.xaml.cs
 * Desc.    :   This file contains the logic in the ProjectCreate view
 */
using System.Windows;

namespace Scrum_o_wall.Views
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class ProjectCreate : Window
    {
        public ProjectCreate()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void BtnAddProject_Click(object sender, RoutedEventArgs e)
        {
            int nameLength = tbxName.Text.Trim().Length;
            int descLength = tbxDesc.Text.Trim().Length;
            if (nameLength > 0 && descLength > 0 && tbxDate.SelectedDate != null)
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
