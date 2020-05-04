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
    /// Logique d'interaction pour CommentCreate.xaml
    /// </summary>
    public partial class CommentCreate : Window
    {
        public CommentCreate(List<User> assignedUsers)
        {
            InitializeComponent();
            foreach (User user in assignedUsers)
            {
                cbxAuthor.Items.Add(user);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if(cbxAuthor.SelectedItem != null && tbxContent.Text.Length > 0)
            {
                this.DialogResult = true;
                this.Close();
            }
        }
    }
}
