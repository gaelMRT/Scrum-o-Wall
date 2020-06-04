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
    /// Logique d'interaction pour MindmapMenu.xaml
    /// </summary>
    public partial class MindmapMenu : Window
    {
        MindMap mindMap;
        Controller controller;
        List<UserControl> nodeControls = new List<UserControl>();
        public MindmapMenu(MindMap aMindMap, Controller aController)
        {
            mindMap = aMindMap;
            controller = aController;

            InitializeComponent();

            this.Loaded += MindmapMenu_Loaded;
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
            TextBlock content = new TextBlock();
            content.Text = node.ToString();
            content.TextWrapping = TextWrapping.Wrap;
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
                        controller.UpdateNode(nodeEdit.tbxName.Text.Trim(), nodeEdit.cbxPrevious.SelectedItem as Node, node);
                    }
                    Refresh();
                }
            }
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = null;
            this.Close();
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            MindmapEdit mindMapEdit = new MindmapEdit(mindMap);
            if (mindMapEdit.ShowDialog() == true)
            {
                if (mindMapEdit.Deleted)
                {
                    controller.Delete(mindMap);
                    this.DialogResult = false;
                    this.Close();
                }
                else
                {
                    controller.UpdateMindMap(mindMapEdit.tbxName.Text.Trim(), mindMap);
                }
                Refresh();
            }
        }

        private void CreateNode_Click(object sender, EventArgs e)
        {
            NodeCreate nodeCreate = new NodeCreate(mindMap);
            if (nodeCreate.ShowDialog() == true)
            {
                controller.CreateNode(nodeCreate.tbxName.Text.Trim(), nodeCreate.cbxPrevious.SelectedItem as Node, mindMap);
                Refresh();
            }
        }

    }
}
