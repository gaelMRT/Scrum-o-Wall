using Scrum_o_wall.Classes;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Scrum_o_wall
{
    public class Controller
    {
        private List<Project> projects;
        private List<User> users;

        private List<Classes.Type> types;
        private List<Priority> priorities;
        private List<FileType> fileTypes;
        private List<State> states;

        public List<Project> Projects { get => projects; }
        public List<User> Users { get => users; }
        public List<Classes.Type> Types { get => types; }
        public List<Priority> Priorities { get => priorities; }
        public List<FileType> FileTypes { get => fileTypes; }
        public List<State> States { get => states; }

        public Controller()
        {
            GetDatas();
        }

        /// <summary>
        /// Get All datas and links all objects between them 
        /// </summary>
        /// <returns>a list of project containing all infos</returns>
        private void GetDatas()
        {
            //Initialise variables
            List<Project> allProjects;
            List<UserStory> allUserStories;
            List<Sprint> allSprints;
            List<State> allStates;
            List<User> allUsers;
            List<Classes.File> allFiles;
            List<FileType> allFileTypes;
            List<Activity> allActivities;
            List<Checklist> allChecklists;
            List<ChecklistItem> allChecklistItems;
            List<Priority> allPriorities;
            List<Comment> allComments;
            List<Classes.Type> allTypes;

            List<int[]> projectStates;
            List<int[]> userStoriesSprint;
            List<int[]> userUserStories;
            List<int[]> userChecklistItem;
            List<int[]> userProjects;


            allProjects = DB.GetProjects();
            allSprints = DB.GetSprints();
            allUserStories = DB.GetUserStories();
            allStates = DB.GetStates();
            allUsers = DB.GetUsers();
            allFiles = DB.GetFiles();
            allFileTypes = DB.GetFileTypes();
            allActivities = DB.GetActivities();
            allChecklists = DB.GetChecklists();
            allChecklistItems = DB.GetChecklistItems();
            allPriorities = DB.GetPriorities();
            allComments = DB.GetComments();
            allTypes = DB.GetTypes();


            #region Link State with project
            projectStates = DB.GetProjectStates();
            // 0:IdProject,1:IdState
            foreach (int[] item in projectStates)
            {
                Project project = allProjects.First(p => p.Id == item[0]);
                State state = allStates.First(s => s.Id == item[1]);
                project.States.Add(state);
            }
            #endregion

            #region Link UserStory with other classes
            foreach (UserStory u in allUserStories)
            {
                Project project = allProjects.First(p => p.Id == u.ProjectId);
                State state = allStates.First(s => s.Id == u.StateId);
                Priority priority = allPriorities.First(p => p.Id == u.PriorityId);
                Classes.Type type = allTypes.First(t => t.Id == u.TypeId);
                List<Activity> activities = allActivities.Where(a => a.UserStoryId == u.Id).ToList();
                List<Classes.File> files = allFiles.Where(f => f.UserStoryId == u.Id).ToList();

                u.CurrentState = state;
                u.Priority = priority;
                u.Type = type;
                u.Activities = activities;
                u.Files = files;
                project.AllUserStories.Add(u);
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

            #region Link Sprint with Project
            foreach (Sprint s in allSprints)
            {
                Project project = allProjects.First(p => p.Id == s.ProjectId);
                s.Project = project;
                project.Sprints.Add(s);
            }
            #endregion

            #region Link user with UserStory
            userUserStories = DB.GetUserUserStory();
            foreach (int[] item in userUserStories)
            {
                // 0:IdUser,1:IdUserStories
                User user = allUsers.First(u => u.Id == item[0]);
                UserStory userStory = allUserStories.First(us => us.Id == item[1]);
                userStory.AssignedUsers.Add(user);
            }
            #endregion
            #region Link user with CheckListItem
            userChecklistItem = DB.GetUserChecklistItem();
            foreach (int[] item in userChecklistItem)
            {
                // 0:IdUser,1:IdChecklistItem
                User user = allUsers.First(u => u.Id == item[0]);
                ChecklistItem checklistItem = allChecklistItems.First(c => c.Id == item[1]);
                checklistItem.AssignedUsers.Add(user);
            }
            #endregion
            #region Link user with Project
            userProjects = DB.GetUserProject();
            foreach (int[] item in userProjects)
            {
                // 0:IdUser,1:IdProject
                User user = allUsers.First(u => u.Id == item[0]);
                Project project = allProjects.First(p => p.Id == item[1]);
                project.AssignedUsers.Add(user);
            }
            #endregion

            projects = allProjects;
            users = allUsers;
            types = allTypes;
            priorities = allPriorities;
            fileTypes = allFileTypes;
            states = allStates;
        }

        /// <summary>
        /// Create a project and add it to all projects
        /// </summary>
        /// <param name="aName"></param>
        /// <param name="aDesc"></param>
        /// <param name="aDate"></param>
        public void CreateProject(string aName, string aDesc, DateTime aDate)
        {
            projects.Add(DB.CreateProject(aName, aDesc, aDate));
        }

    }
}
