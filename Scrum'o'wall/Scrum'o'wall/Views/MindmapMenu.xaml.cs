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
            cnvsMindMap.Width = cnvsMindMap.ActualWidth;
            cnvsMindMap.Height = cnvsMindMap.ActualHeight;
            Refresh();
        }

        public void Refresh()
        {
            foreach (UserControl nodeControl in nodeControls)
            {
                cnvsMindMap.Children.Remove(nodeControl);
            }
            nodeControls.Clear();
            DrawNode(mindMap.Root);
            
        }
        private int DrawNode(Node node, int level = 0)
        {

            UserControl nodeControl = new UserControl();
            nodeControl.Content = node.ToString();
            nodeControl.Tag = node;
            nodeControl.BorderBrush = Brushes.Black;
            nodeControl.BorderThickness = new Thickness(1);
            nodeControl.Background = Brushes.LightGray;
            nodeControl.Cursor = Cursors.Hand;
            nodeControl.MouseDoubleClick += NodeControl_Click;
            nodeControl.TouchUp += NodeControl_Click;

            nodeControl.Height = 50;

            cnvsMindMap.Children.Add(nodeControl);
            nodeControls.Add(nodeControl);

            Canvas.SetTop(nodeControl, nodeControls.Count * (nodeControl.Height + 5));

            int maxlvl = (level == 0 ? 1 : level);
            foreach (Node n in node.Childrens)
            {
                maxlvl = DrawNode(n, level + 1);
            }

            Console.WriteLine(level);

            nodeControl.Width = 200;
            Canvas.SetLeft(nodeControl, (200 + 10) * level);


            return maxlvl;
        }

        private void NodeControl_Click(object sender, EventArgs e)
        {
            Node node = (sender as UserControl).Tag as Node;
            NodeEdit nodeEdit = new NodeEdit(node);
            if (nodeEdit.ShowDialog() == true)
            {
                if (nodeEdit.Deleted)
                {
                    controller.Delete(node);
                }
                else
                {
                    controller.UpdateNode(nodeEdit.tbxName.Text, nodeEdit.cbxPrevious.SelectedItem as Node, node);
                }
                Refresh();
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
                    controller.UpdateMindMap(mindMapEdit.tbxName.Text, mindMap);
                }
                Refresh();
            }
        }

        private void CreateNode_Click(object sender, EventArgs e)
        {
            NodeCreate nodeCreate = new NodeCreate(mindMap);
            if (nodeCreate.ShowDialog() == true)
            {
                controller.CreateNode(nodeCreate.tbxName.Text, nodeCreate.cbxPrevious.SelectedItem as Node, mindMap);
                Refresh();
            }
        }

    }
}
