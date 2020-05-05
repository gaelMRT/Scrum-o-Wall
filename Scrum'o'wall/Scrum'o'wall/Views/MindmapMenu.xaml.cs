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
        public MindmapMenu(MindMap aMindMap)
        {
            mindMap = aMindMap;

            InitializeComponent();

            Refresh();
        }
        public void Refresh()
        {

        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
