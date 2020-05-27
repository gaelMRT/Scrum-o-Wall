/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   MainMenu.xaml.cs
 * Desc.    :   This file contains the methods behind the MainMenu View   
 */
using Scrum_o_wall.Classes;
using Scrum_o_wall.Views;
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
    /// Logique d'interaction pour MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        Controller controller;
        List<UserControl> projectControls = new List<UserControl>();
        public MainMenu()
        {
            InitializeComponent();
            controller = new Controller();
            Loaded += MainMenu_Loaded;
        }

        private void Refresh()
        {
            //Create controls for the projects
            int maxProj = controller.Projects.Count;
            foreach (UserControl project in projectControls)
            {
                cnvsProject.Children.Remove(project);
            }
            projectControls.Clear();
            for (int i = 0; i < maxProj; i++)
            {
                Project p = controller.Projects[i];

                //create a control for title
                Label title = new Label();
                title.Content = p.Name;
                title.HorizontalContentAlignment = HorizontalAlignment.Center;
                title.FontSize = 24;
                Grid.SetRow(title, 0);

                //Create a control for description
                Label desc = new Label();
                TextBlock txtBlck = new TextBlock();
                txtBlck.TextWrapping = TextWrapping.WrapWithOverflow;
                txtBlck.Text = p.Description;
                desc.Content = txtBlck;
                desc.HorizontalAlignment = HorizontalAlignment.Stretch;
                desc.FontSize = 18;
                Grid.SetRow(desc, 1);

                //Create a control of date
                Label date = new Label();
                date.Content = "Date de début : " + p.Begin.ToShortDateString();
                date.HorizontalContentAlignment = HorizontalAlignment.Left;
                date.FontSize = 18;
                Grid.SetRow(date, 2);

                //Place controls in a grid
                Grid grd = new Grid();
                grd.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(60) });
                grd.RowDefinitions.Add(new RowDefinition());
                grd.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(40) });
                grd.Children.Add(title);
                grd.Children.Add(desc);
                grd.Children.Add(date);

                //Create project frame
                UserControl usrCntrl = new UserControl();
                usrCntrl.Width = cnvsProject.Width / 4;
                usrCntrl.Height = cnvsProject.Height / 5;
                usrCntrl.Content = grd;
                usrCntrl.BorderBrush = Brushes.Black;
                usrCntrl.Background = Brushes.LightGray;
                usrCntrl.Cursor = Cursors.Hand;
                usrCntrl.Tag = p;
                usrCntrl.TouchDown += UsrCntrl_Click;
                usrCntrl.MouseLeftButtonDown += UsrCntrl_Click;

                //Positioning of control
                Canvas.SetLeft(usrCntrl, (cnvsProject.Width - usrCntrl.Width) / 2.0 + ((usrCntrl.Width + usrCntrl.Width / 4) * (i % 3 - 1)));
                Canvas.SetTop(usrCntrl, 20 + (usrCntrl.Height + usrCntrl.Height / 5) * (i / 3));

                if (Canvas.GetTop(usrCntrl) + usrCntrl.Height > cnvsProject.Height)
                {
                    cnvsProject.Height = Canvas.GetTop(usrCntrl) + usrCntrl.Height;
                }

                //Add project frame to canvas
                cnvsProject.Children.Add(usrCntrl);
                projectControls.Add(usrCntrl);
            }
        }

        private void MainMenu_Loaded(object sender, RoutedEventArgs e)
        {
            //ActualWidth and ActualHeight measured when window is loaded minus border sizes
            cnvsProject.Width = this.ActualWidth;
            cnvsProject.Height = this.ActualHeight;
            scrllVwr.Width = cnvsProject.Width;
            scrllVwr.Height = cnvsProject.Height;

            //Refresh the view
            Refresh();

        }
        private void UsrCntrl_Click(object sender, EventArgs e)
        {
            Project p = (sender as UserControl).Tag as Project;
            ProjectMenu projectMenu = new ProjectMenu(p, controller);
            projectMenu.ShowDialog();
            Refresh();
        }
        private void Quit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Vous allez quitter l'application.\nÊtes-vous sûr de vouloir continuer ?","Attention",MessageBoxButton.OKCancel,MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                Application.Current.Shutdown();
            }
        }
        private void AddProject_Click(object sender, EventArgs e)
        {
            ProjectCreate projectCreate = new ProjectCreate();
            if (projectCreate.ShowDialog() == true)
            {
                string name = projectCreate.tbxName.Text;
                string desc = projectCreate.tbxDesc.Text;
                DateTime date = (DateTime)projectCreate.tbxDate.SelectedDate;
                controller.CreateProject(name, desc, date);

                Refresh();
            }
        }
    }
}
