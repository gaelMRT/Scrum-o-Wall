/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   ProjectMenu.xaml.cs
 * Desc.    :   This file contains the methods behind the ProjectMenu View   
 */
using Scrum_o_wall.Controller;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Scrum_o_wall
{
    /// <summary>
    /// Logique d'interaction pour ProjectMenu.xaml
    /// </summary>
    public partial class ProjectMenu : Window
    {
        public ProjectMenu()
        {
            InitializeComponent();

            DB.GetProjects();
            Loaded += ProjectMenu_Loaded;
        }


        private void ProjectMenu_Loaded(object sender, RoutedEventArgs e)
        {
            //ActualWidth and ActualHeight measured when window is loaded minus border sizes
            cnvsProject.Width = this.ActualWidth;
            cnvsProject.Height = this.ActualHeight;
            //Set the adding project button to 90% width and 90% height
            Canvas.SetLeft(btnAddProject, cnvsProject.Width * .9);
            Canvas.SetTop(btnAddProject, cnvsProject.Height * .9);
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AddProject_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((sender as Control).Name);
        }
    }
}
