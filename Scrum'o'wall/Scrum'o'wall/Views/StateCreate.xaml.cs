﻿using System;
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

        private void BtnCancel_Click(object sender,EventArgs e)
        {
            this.DialogResult = null;
            this.Close();
        }
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if(tbxStateName.Text.Length > 1)
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
