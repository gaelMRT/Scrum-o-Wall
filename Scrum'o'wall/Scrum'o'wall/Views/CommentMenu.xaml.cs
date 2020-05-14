﻿using Scrum_o_wall.Classes;
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
    /// Logique d'interaction pour CommentMenu.xaml
    /// </summary>
    public partial class CommentMenu : Window
    {
        UserStory userStory;
        Controller controller;
        public CommentMenu(UserStory aUserStory, Controller aController)
        {
            userStory = aUserStory;
            controller = aController;

            InitializeComponent();

            Refresh();
        }

        public void Refresh()
        {
            lstComments.Items.Clear();
            foreach (Comment comment in userStory.Comments)
            {
                lstComments.Items.Add(comment);
            }
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddComment_Click(object sender, RoutedEventArgs e)
        {
            AddComment();
        }
        
        private void AddComment()
        {
            CommentCreate commentCreate = new CommentCreate(userStory.GetUsers());
            if (userStory.GetUsers().Count == 0)
            {
                MessageBox.Show("Aucun utilisateur assigné", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }else if (commentCreate.ShowDialog() == true)
            {
                controller.CreateComment(commentCreate.tbxContent.Text, userStory);
                Refresh();
            }
        }

        private void btnCancel_TouchDown(object sender, TouchEventArgs e)
        {
            this.Close();
        }

        private void btnAddComment_TouchDown(object sender, TouchEventArgs e)
        {
            AddComment();
        }
    }
}
