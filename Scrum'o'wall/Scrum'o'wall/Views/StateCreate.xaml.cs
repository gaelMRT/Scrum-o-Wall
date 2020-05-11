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
    /// Logique d'interaction pour StateCreate.xaml
    /// </summary>
    public partial class StateCreate : Window
    {
        public StateCreate()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if(tbxStateName.Text.Length > 1)
            {
                this.DialogResult = true;
                this.Close();
            }
        }

        private void btnConfirm_TouchDown(object sender, TouchEventArgs e)
        {
            if (tbxStateName.Text.Length > 1)
            {
                this.DialogResult = true;
                this.Close();
            }
        }

        private void btnCancel_TouchDown(object sender, TouchEventArgs e)
        {
            this.Close();
        }
    }
}
