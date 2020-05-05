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
    /// Logique d'interaction pour ProjectEdit.xaml
    /// </summary>
    public partial class ProjectEdit : Window
    {
        public ProjectEdit()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if(tbxDate.SelectedDate != null && tbxDesc.Text.Length > 0 && tbxName.Text.Length > 0)
            {
                this.DialogResult = true;
                this.Close();
            }
        }

        private void btnStates_Click(object sender, RoutedEventArgs e)
        {
            StateMenu stateMenu = new StateMenu();
            stateMenu.ShowDialog();
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            UserMenu userMenu = new UserMenu();
            userMenu.ShowDialog();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
