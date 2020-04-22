/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   DB.cs
 * Desc.    :   This file is a singlotron's class to access to the database
 */
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Scrum_o_wall
{
    public static class DB
    {
        private static OleDbConnection connection;
        public static OleDbConnection GetConnection()
        {
            if(connection is null)
            {
                string path = "";
                OpenFileDialog opf = new OpenFileDialog();
                opf.Title = "Quel base de données Access utiliser ?";
                opf.DefaultExt = ".accdb|*.accdb";
                opf.Filter = "Fichier Acces (*.accdb)|*.accdb";
                while (opf.ShowDialog() != true || !opf.SafeFileName.Contains(".accdb"))
                {
                    MessageBox.Show("Vous devez obligatoirement donner un fichier valide!", "Attention", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + opf.FileName+ ";Persist Security Info=False;");
            }
            return connection;
        }
    }
}
