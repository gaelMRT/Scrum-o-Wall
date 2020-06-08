/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   MindmapMenu.xaml.cs
 * Desc.    :   This file contains the logic in the MindmapMenu view
 */
using Scrum_o_wall.Classes;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Scrum_o_wall.Views
{
    /// <summary>
    /// Logique d'interaction pour MindmapMenu.xaml
    /// </summary>
    public partial class MindmapMenu : Window
    {
        private readonly MindMap mindMap;
        private readonly Controller controller;
        private readonly List<UserControl> nodeControls = new List<UserControl>();
        public MindmapMenu(MindMap aMindMap, Controller aController)
        {
            mindMap = aMindMap;
            controller = aController;

            InitializeComponent();

            Loaded += MindmapMenu_Loaded;

        }
        private void MindmapMenu_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        public void Refresh()
        {
            foreach (UserControl nodeControl in nodeControls)
            {
                grdMindMap.Children.Remove(nodeControl);
            }
            grdMindMap.ColumnDefinitions.Clear();
            grdMindMap.RowDefinitions.Clear();
            nodeControls.Clear();
            DrawNode(mindMap.Root);

        }
        private int DrawNode(Node node, int level = 0)
        {
            TextBlock content = new TextBlock
            {
                Text = node.ToString(),
                TextWrapping = TextWrapping.Wrap
            };
            UserControl nodeControl = new UserControl
            {
                Content = content,
                Tag = node,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(1),
                Background = Brushes.LightGray,
                Margin = new Thickness(3),
                Cursor = Cursors.Hand,
                MinHeight = 50
            };
            nodeControl.MouseDoubleClick += NodeControl_Click;
            nodeControl.TouchUp += NodeControl_Click;

            grdMindMap.Children.Add(nodeControl);
            nodeControls.Add(nodeControl);

            grdMindMap.RowDefinitions.Add(new RowDefinition());

            Grid.SetRow(nodeControl, grdMindMap.RowDefinitions.Count - 1);

            int maxlvl = (level == 0 ? 1 : level);
            foreach (Node n in node.Childrens)
            {
                int nodeMaxLvl = DrawNode(n, level + 1);
                maxlvl = (maxlvl < nodeMaxLvl ? nodeMaxLvl : maxlvl);
            }

            while (grdMindMap.ColumnDefinitions.Count <= level)
            {
                grdMindMap.ColumnDefinitions.Add(new ColumnDefinition());
            }
            Grid.SetColumn(nodeControl, level);

            return maxlvl + 1;
        }

        private void NodeControl_Click(object sender, EventArgs e)
        {
            Node node = (sender as UserControl).Tag as Node;
            if (node.Previous == null)
            {
                MessageBox.Show("Pour changer l'intitulé de ce noeud, modifiez le mindmap", "Information", MessageBoxButton.OK);
            }
            else
            {
                NodeEdit nodeEdit = new NodeEdit(node);
                if (nodeEdit.ShowDialog() == true)
                {
                    if (nodeEdit.Deleted)
                    {
                        controller.Delete(node);
                    }
                    else
                    {
                        string name = nodeEdit.tbxName.Text.Trim();
                        Node previous = nodeEdit.cbxPrevious.SelectedItem as Node;
                        controller.UpdateNode(name,previous, node);
                    }
                    Refresh();
                }
            }
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            MindmapEdit mindMapEdit = new MindmapEdit(mindMap);
            if (mindMapEdit.ShowDialog() == true)
            {
                if (mindMapEdit.Deleted)
                {
                    controller.Delete(mindMap);
                    DialogResult = false;
                    Close();
                }
                else
                {
                    string name = mindMapEdit.tbxName.Text.Trim();
                    controller.UpdateMindMap(name, mindMap);
                }
                Refresh();
            }
        }

        private void CreateNode_Click(object sender, EventArgs e)
        {
            NodeCreate nodeCreate = new NodeCreate(mindMap);
            if (nodeCreate.ShowDialog() == true)
            {
                string name = nodeCreate.tbxName.Text.Trim();
                Node previous = nodeCreate.cbxPrevious.SelectedItem as Node;
                controller.CreateNode(name, previous, mindMap);
                Refresh();
            }
        }

    }
}
