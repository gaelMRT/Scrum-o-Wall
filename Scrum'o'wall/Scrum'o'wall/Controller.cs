using Scrum_o_wall.Classes;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Scrum_o_wall
{
    public class Controller
    {
        private List<Project> projects;

        public List<Project> Projects { get => projects;}

        public Controller()
        {
            projects = GetDatas();
        }

        /// <summary>
        /// Get All datas and links all objects between them 
        /// </summary>
        /// <returns>a list of project containing all infos</returns>
        private List<Project> GetDatas()
        {
            //Initialise variables
            List<Project> allProjects;
            List<UserStory> allUserStories;
            List<Sprint> allSprints;

            Dictionary<int, string> allStates;
            List<int[]> projectStates;
            List<int[]> userStoriesSprint;


            allProjects = DB.GetProjects();
            allSprints = DB.GetSprints();
            allUserStories = DB.GetUserStories();
            allStates = DB.GetStates();


            #region Link State with project
            projectStates = DB.GetProjectStates();
            // 0:IdProject,1:IdState
            foreach (int[] item in projectStates)
            {
                Project project = allProjects.First(p => p.Id == item[0]);
                project.addState(item[1],allStates[item[1]]);
            }
            #endregion

            #region Link State with UserStory
            foreach (UserStory u in allUserStories)
            {
                u.CurrentState = allStates[u.StateId];
            }
            #endregion

            #region Link UserStory with Sprint
            userStoriesSprint = DB.GetUserStoriesSprint();
            // 0:IdUserStory,1:IdSprint,2:Order
            foreach (int[] item in userStoriesSprint)
            {
                UserStory userStory = allUserStories.First(u => u.Id == item[0]);
                Sprint sprint = allSprints.First(s => s.Id == item[1]);
                sprint.addUserStory(item[2], userStory);
            }
            #endregion

            #region Link UserStory with Project
            foreach (UserStory u in allUserStories)
            {
                Project project = allProjects.First(p => p.Id == u.ProjectId);
                project.addUserStory(u);
            }
            #endregion

            #region Link Sprint with Project
            foreach (Sprint s in allSprints)
            {
                Project project = allProjects.First(p => p.Id == s.ProjectId);
                s.Project = project;
                project.addSprint(s);
            }
            #endregion

            return allProjects;
        }

        /// <summary>
        /// Create a project and add it to all projects
        /// </summary>
        /// <param name="aName"></param>
        /// <param name="aDesc"></param>
        /// <param name="aDate"></param>
        public void CreateProject(string aName, string aDesc, DateTime aDate)
        {
            projects.Add(DB.CreateProject(aName,aDesc,aDate));
        }

    }
}
