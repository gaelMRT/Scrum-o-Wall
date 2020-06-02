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
        public MindmapMenu(MindMap aMindMap, Controller aController)
        {
            mindMap = aMindMap;
            controller = aController;

            InitializeComponent();

            Refresh();
        }
        public void Refresh()
        {

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
            NodeCreate nodeCreate = new NodeCreate();
            if(nodeCreate.ShowDialog() == true)
            {
                controller.CreateNode(nodeCreate.tbxName.Text, nodeCreate.cbxPrevious.SelectedItem as Node, mindMap);
                Refresh();
            }
        }

    }
}
