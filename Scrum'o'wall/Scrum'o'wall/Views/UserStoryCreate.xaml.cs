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
    /// Logique d'interaction pour UserStoryCreate.xaml
    /// </summary>
    public partial class UserStoryCreate : Window
    {
        public UserStoryCreate(Controller aController)
        {
            InitializeComponent();

            foreach(Priority priority in aController.Priorities)
            {
                cbxPriority.Items.Add(priority);
            }
            foreach (Classes.Type type in aController.Types)
            {
                cbxType.Items.Add(type);
            }
        }

        private void tbxComplexity_KeyDown(object sender, KeyEventArgs e)
        {
            bool isNumber = (e.Key >= Key.D0 && e.Key <= Key.D9);
            if (!isNumber)
            {
                e.Handled = true;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (tbxDesc.Text.Length > 0 && tbxComplexity.Text.Length > 0 && cbxPriority.SelectedIndex >= 0 && cbxType.SelectedIndex >= 0)
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
