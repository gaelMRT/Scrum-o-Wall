/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   BurndownChart.xaml.cs
 * Desc.    :   This file contains the logic in the BurndownChart view
 */
using Scrum_o_wall.Classes;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace Scrum_o_wall.Views
{
    /// <summary>
    /// Logique d'interaction pour BurndownChart.xaml
    /// </summary>
    public partial class BurndownChart : Window
    {
        private readonly Sprint sprint;
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

            int totalComplexity = 0;
            int completedComplexity = 0;

            foreach (KeyValuePair<int, UserStory> keyValuePair in sprint.OrderedUserStories)
            {
                totalComplexity += keyValuePair.Value.ComplexityEstimation;
                completedComplexity += keyValuePair.Value.CompletedComplexity;
            }

            lblComplexityMax.Content = totalComplexity.ToString();
            double x2Line = elapsedDays / totalDays * (ActualWidth - brdrGraphic.Margin.Left - brdrGraphic.Margin.Right) + brdrGraphic.Margin.Left;
            double y2Line = completedComplexity / (double)totalComplexity * (ActualHeight - brdrGraphic.Margin.Bottom - brdrGraphic.Margin.Top) + brdrGraphic.Margin.Top;

            PointCollection linePoints = new PointCollection
            {
                new Point(brdrGraphic.Margin.Left, brdrGraphic.Margin.Top),
                new Point(x2Line, y2Line)
            };

            lnIdeal.X2 = ActualWidth - brdrGraphic.Margin.Right;
            lnIdeal.Y2 = ActualHeight - brdrGraphic.Margin.Bottom;

            lnCurrent.Points = linePoints;

        }
        private void Quit_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
