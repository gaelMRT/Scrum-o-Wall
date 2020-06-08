/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   CommentMenu.xaml.cs
 * Desc.    :   This file contains the logic in the CommentMenu view
 */
using Scrum_o_wall.Classes;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Scrum_o_wall.Views
{
    /// <summary>
    /// Logique d'interaction pour CommentMenu.xaml
    /// </summary>
    public partial class CommentMenu : Window
    {
        private readonly UserStory userStory;
        private readonly Controller controller;
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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnAddComment_Click(object sender, EventArgs e)
        {
            CommentCreate commentCreate = new CommentCreate(userStory.GetUsers());
            if (userStory.GetUsers().Count == 0)
            {
                MessageBox.Show("Aucun utilisateur assigné", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (commentCreate.ShowDialog() == true)
            {
                string content = commentCreate.tbxContent.Text.Trim();
                User user = commentCreate.cbxAuthor.SelectedItem as User;
                controller.CreateComment(content, user, userStory);
                Refresh();
            }
        }

        private void LstComments_MouseDoubleClick(object sender, EventArgs e)
        {
            ListBox lbx = sender as ListBox;
            if (lbx.SelectedItem != null)
            {
                Comment comment = lbx.SelectedItem as Comment;
                MessageBox.Show(string.Format("Auteur : {0}\nDate : {1}\n{2}", comment.User, comment.DateTime, comment.Description), "Contenu du commentaire", MessageBoxButton.OK);
            }
        }
    }
}
