using Scrum_o_wall.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Logique d'interaction pour StateMenu.xaml
    /// </summary>
    public partial class StateMenu : Window
    {
        Project project;
        Controller controller;
        public StateMenu(Project aProject,Controller aController)
        {
            project = aProject;
            controller = aController;

            InitializeComponent();

            Refresh();
        }
        private void Refresh()
        {
            if(lstAssignedStates.Items.Count == 0)
            {
                foreach (KeyValuePair<int,State> keyValuePair  in project.States)
                {
                    lstAssignedStates.Items.Add(keyValuePair.Value);
                }
            }
            lstPossibleStates.Items.Clear();
            foreach (State state in controller.States.Where(s=> !lstAssignedStates.Items.Contains(s)))
            {
                lstPossibleStates.Items.Add(state);
            }
        }
        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGoLeft_Click(object sender, RoutedEventArgs e)
        {
            State state = lstAssignedStates.SelectedItem as State;
            if(state != null)
            {
                lstAssignedStates.Items.Remove(state);
                lstPossibleStates.Items.Add(state);
            }
        }

        private void btnGoRight_Click(object sender, RoutedEventArgs e)
        {
            State state = lstPossibleStates.SelectedItem as State;
            if(state != null)
            {
                lstPossibleStates.Items.Remove(state);
                lstAssignedStates.Items.Add(state);
            }
        }

        private void Save()
        {
            List<State> toRemove = new List<State>();
            List<State> toAdd = new List<State>();
            foreach (State state in controller.States)
            {
                if (lstAssignedStates.Items.Contains(state) && !project.States.ContainsValue(state))
                {
                    toAdd.Add(state);
                }
                else if (lstPossibleStates.Items.Contains(state) && project.States.ContainsValue(state))
                {
                    toRemove.Add(state);
                }
            }
            foreach (State state in toAdd)
            {
                controller.AddStateToProject(state,project);
            }
            foreach (State state in toRemove)
            {
                controller.RemoveStateFromProject(state, project);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Save();            
        }

        private void btnAddState_Click(object sender, RoutedEventArgs e)
        {
            StateCreate stateCreate = new StateCreate();
            if(stateCreate.ShowDialog() == true)
            {
                controller.CreateState(stateCreate.tbxStateName.Text);
                Refresh();
            }
        }

        private void btnAddState_TouchDown(object sender, TouchEventArgs e)
        {
            StateCreate stateCreate = new StateCreate();
            if (stateCreate.ShowDialog() == true)
            {
                controller.CreateState(stateCreate.tbxStateName.Text);
                Refresh();
            }
        }

        private void btnGoLeft_TouchDown(object sender, TouchEventArgs e)
        {
            State state = lstAssignedStates.SelectedItem as State;
            if (state != null)
            {
                lstAssignedStates.Items.Remove(state);
                lstPossibleStates.Items.Add(state);
            }
        }

        private void btnGoRight_TouchDown(object sender, TouchEventArgs e)
        {
            State state = lstPossibleStates.SelectedItem as State;
            if (state != null)
            {
                lstPossibleStates.Items.Remove(state);
                lstAssignedStates.Items.Add(state);
            }
        }

        private void btnSave_TouchDown(object sender, TouchEventArgs e)
        {
            Save();
        }
    }
}
