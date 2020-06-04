using Microsoft.Win32;
using Scrum_o_wall.Classes;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Logique d'interaction pour FileCreate.xaml
    /// </summary>
    public partial class FileCreate : Window
    {
        public FileCreate()
        {
            InitializeComponent();
        }

        private void BtnFileSearch_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Multiselect = false;
            if(opf.ShowDialog() == true)
            {
                tbxFileName.Text = opf.FileName;
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = null;
            this.Close();
        }
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if(tbxDescription.Text.Trim().Length > 0 && tbxFileName.Text.Trim().Length > 0 && System.IO.File.Exists(tbxFileName.Text) )
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
