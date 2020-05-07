using Scrum_o_wall.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Logique d'interaction pour BurndownChart.xaml
    /// </summary>
    public partial class BurndownChart : Window
    {
        Sprint sprint;
        public BurndownChart(Sprint aSprint)
        {
            sprint = aSprint;
            InitializeComponent();
            Loaded += BurndownChart_Loaded;

            lblDayBegin.Content = sprint.Begin.ToString("dd.MM");
            lblDayEnd.Content = sprint.End.ToString("dd.MM");

        }

        private void BurndownChart_Loaded(object sender, RoutedEventArgs e)
        {
            double daysSinceBegin = (DateTime.Now - sprint.Begin).TotalDays;
            double totalDays = (sprint.End - sprint.Begin).TotalDays;
            double elapsedDays = Math.Min(totalDays, daysSinceBegin);

            int totalComplexity = 1;
            int completedComplexity = 0;

            foreach (KeyValuePair<int, UserStory> keyValuePair in sprint.OrderedUserStories)
            {
                totalComplexity += keyValuePair.Value.ComplexityEstimation;
                completedComplexity += keyValuePair.Value.CompletedComplexity;
            }

            lblComplexityMax.Content = totalComplexity.ToString();
            double x2Line = elapsedDays / totalDays * (this.ActualWidth - 200) + 130;
            double y2Line = completedComplexity / totalComplexity * (this.ActualHeight - 140) + 70;

            PointCollection linePoints = new PointCollection();
            linePoints.Add(new Point(120, 70));
            linePoints.Add(new Point(x2Line, y2Line));

            lnIdeal.X2 = ActualWidth - 70;
            lnIdeal.Y2 = ActualHeight - 70;

            lnCurrent.Points = linePoints;

        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
