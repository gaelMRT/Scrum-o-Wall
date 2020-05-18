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
    /// Logique d'interaction pour UserEdit.xaml
    /// </summary>
    public partial class UserEdit : Window
    {
        User user;
        public UserEdit(User aUser)
        {
            user = aUser;

            tbxUserName.Text = user.Name;

            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(tbxUserName.Text.Length > 1)
            {
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Un ou plusieurs champ(s) n'est pas rempli !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
