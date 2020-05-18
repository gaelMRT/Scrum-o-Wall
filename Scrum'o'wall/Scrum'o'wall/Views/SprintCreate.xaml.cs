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
    /// Logique d'interaction pour SprintCreate.xaml
    /// </summary>
    public partial class SprintCreate : Window
    {
        public SprintCreate()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAddProject_Click(object sender, EventArgs e)
        {
            if (dtpckDateBegin.SelectedDate != null  && dtpckDateEnd.SelectedDate != null)
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
