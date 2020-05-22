using Scrum_o_wall.Classes;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace Scrum_o_wall
{
    public class Controller
    {
        private List<Project> projects;
        private List<User> users;

        private List<Classes.Type> types;
        private List<Priority> priorities;
        private List<State> states;

        public List<Project> Projects { get => projects; }
        public List<User> Users { get => users; }
        public List<Classes.Type> Types { get => types; }
        public List<Priority> Priorities { get => priorities; }
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
            allActivities = DB.GetActivities();
            allChecklists = DB.GetChecklists();
            allChecklistItems = DB.GetChecklistItems();
            allPriorities = DB.GetPriorities();
            allComments = DB.GetComments();
            allTypes = DB.GetTypes();


            #region Link State with project
            projectStates = DB.GetProjectStates();
            // 0:IdProject,1:IdState,2:order
            foreach (int[] item in projectStates)
            {
                Project project = allProjects.First(p => p.Id == item[0]);
                State state = allStates.First(s => s.Id == item[1]);
                project.States.Add(item[2], state);
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
                List<Checklist> checklists = allChecklists.Where(c => c.UserStoryId == u.Id).ToList();

                u.State = state;
                u.Priority = priority;
                u.Type = type;
                u.Activities = activities;
                u.Files = files;
                u.Checklists = checklists;
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

            #region Link Checklist with ChecklistItems
            foreach (Checklist chk in allChecklists)
            {
                chk.ChecklistItems = allChecklistItems.Where(c => c.ChecklistId == chk.Id).ToList();
            }
            #endregion

            #region Link user with UserStory
            userUserStories = DB.GetUserUserStory();
            foreach (int[] item in userUserStories)
            {
                // 0:IdUser,1:IdUserStories
                User user = allUsers.First(u => u.Id == item[0]);
                UserStory userStory = allUserStories.First(us => us.Id == item[1]);
                userStory.AddUser(user);
            }
            #endregion
            #region Link user with CheckListItem
            userChecklistItem = DB.GetUserChecklistItem();
            foreach (int[] item in userChecklistItem)
            {
                // 0:IdUser,1:IdChecklistItem
                User user = allUsers.First(u => u.Id == item[0]);
                ChecklistItem checklistItem = allChecklistItems.First(c => c.Id == item[1]);
                checklistItem.AddUser(user);
            }
            #endregion
            #region Link user with Project
            userProjects = DB.GetUserProject();
            foreach (int[] item in userProjects)
            {
                // 0:IdUser,1:IdProject
                User user = allUsers.First(u => u.Id == item[0]);
                Project project = allProjects.First(p => p.Id == item[1]);
                project.AddUser(user);
            }
            #endregion

            projects = allProjects;
            users = allUsers;
            types = allTypes;
            priorities = allPriorities;
            states = allStates;
        }

        #region Remove Methods
        public bool RemoveStateFromProject(State state, Project project)
        {
            int order = -1;
            if(project.States.ContainsValue(state) && project.States.Count > 1)
            {
                foreach (KeyValuePair<int, State> item in project.States)
                {
                    if (item.Value == state)
                    {
                        project.States.Remove(item.Key);
                        order = item.Key;

                        foreach (UserStory userStory in project.AllUserStories.Where(u => u.State.Id == state.Id))
                        {
                            this.UserStorySwitchState(userStory, project.States.First().Value);
                        }

                        break;
                    }
                }
                DB.RemoveStateFromProject(project, order);
                
            }
            else
            {
                return false;
            }
            return true;
        }
        public bool RemoveUserFromIUsersAssigned(User user, IUsersAssigned usersAssigned)
        {
            string typeName = usersAssigned.GetType().Name;
            switch (typeName)
            {
                case "Project":
                    this.RemoveUserFromProject(user, usersAssigned as Project);
                    break;
                case "UserStory":
                    this.RemoveUserFromUserStory(user, usersAssigned as UserStory);
                    this.CreateActivity(String.Format("{0} a été désassigné", user), usersAssigned as UserStory);
                    break;
                case "ChecklistItem":
                    this.RemoveUserFromChecklistItem(user, usersAssigned as ChecklistItem);
                    break;
                default:
                    return false;
            }
            return true;
        }
        private void RemoveUserFromChecklistItem(User user, ChecklistItem checklistItem)
        {
            DB.RemoveUserFromChecklistItem(user, checklistItem);
            checklistItem.RemoveUser(user);
        }
        private void RemoveUserFromUserStory(User user, UserStory userStory)
        {
            DB.RemoveUserFromUserStory(user, userStory);
            this.CreateActivity(String.Format("\"{0}\" a été désassigné", user), userStory);
            userStory.RemoveUser(user);
        }
        private void RemoveUserFromProject(User user, Project project)
        {
            DB.RemoveUserFromProject(user, project);
            project.RemoveUser(user);
        }
        public void RemoveUserStoryFromSprint(UserStory userStory, Sprint sprint)
        {
            if (sprint.OrderedUserStories.ContainsValue(userStory))
            {
                int order = 0;
                while (sprint.OrderedUserStories[order] != userStory)
                {
                    order++;
                }
                this.CreateActivity(String.Format("A été supprimé du sprint \"{0}\"", sprint), userStory);
                sprint.removeUserStoryByOrder(order);
                DB.RemoveUserStoryFromSprint(userStory, sprint, order);
            }
        }
        #endregion

        #region Update Methods
        public void UserStorySwitchState(UserStory userStory, State state)
        {
            if(userStory.State != state)
            {
                this.CreateActivity(String.Format("Passé de l'état \"{0}\" à l'état \"{1}\"", userStory.State, state), userStory);
                DB.UpdateUserStory(userStory.Description, userStory.DateLimit, userStory.ComplexityEstimation, userStory.CompletedComplexity, userStory.Blocked, userStory.Priority, state, userStory.Type, userStory);
                userStory.State = state;
            }
        }
        internal void UpdateCheckListItem(string nameItem, bool done, ChecklistItem item)
        {
            DB.UpdateCheckListItem(nameItem, done, item);
            item.NameItem = nameItem;
            item.Done = done;
        }
        public void UpdateUserStory(string description, DateTime? selectedDate, int complexity, int completedComplexity, bool blocked, Priority aPriority, Classes.Type aType,State aState, UserStory userStory)
        {
            if(userStory.Description != description || 
                userStory.DateLimit != selectedDate || 
                userStory.ComplexityEstimation != complexity || 
                userStory.CompletedComplexity != completedComplexity || 
                userStory.Blocked != blocked || 
                userStory.Priority != aPriority || 
                userStory.Type != aType || 
                userStory.State != aState)
            {
                this.CreateActivity("Les informations ont été mises à jour", userStory);
                DB.UpdateUserStory(description, selectedDate, complexity, completedComplexity, blocked, aPriority, aState, aType, userStory);
                userStory.Description = description;
                userStory.DateLimit = selectedDate;
                userStory.ComplexityEstimation = complexity;
                userStory.CompletedComplexity = completedComplexity;
                userStory.Blocked = blocked;
                userStory.State = aState;
                userStory.Priority = aPriority;
                userStory.Type = aType;
            }
        }
        public void UpdateFile(string fileDescription, Classes.File file)
        {
            DB.UpdateFile(fileDescription, file);
            file.Description = fileDescription;
        }
        public void UpdateCheckList(string name, List<ChecklistItem> items, Checklist checklist)
        {
            DB.UpdateCheckList(name, checklist);
            checklist.Name = name;
            checklist.ChecklistItems.Clear();
            foreach (ChecklistItem item in items)
            {
                if (item.Id == -1)
                {
                    checklist.ChecklistItems.Add(DB.CreateCheckListItem(item.NameItem, checklist));
                }
                else
                {
                    this.UpdateCheckListItem(item.NameItem, item.Done, item);
                    checklist.ChecklistItems.Add(item);
                }
            }
        }
        public void UpdateProject(string name, string description, DateTime dateTime, Project aProject)
        {
            DB.UpdateProject(name, description, dateTime, aProject);
            aProject.Name = name;
            aProject.Description = description;
            aProject.Begin = dateTime;
        }
        #endregion

        #region Creation Methods
        public bool AddUserStoryToSprint(UserStory userStory, Sprint sprint)
        {
            if (!sprint.OrderedUserStories.ContainsValue(userStory))
            {
                int order = 0;
                while (sprint.OrderedUserStories.ContainsKey(order))
                {
                    order++;
                }
                sprint.addUserStory(order, userStory);
                DB.AddUserStoryToSprint(userStory, sprint, order);
                this.CreateActivity(String.Format("A été ajouté au sprint \"{0}\"", sprint), userStory);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AddStateToProject(State state, Project project)
        {
            int i = 0;
            while (project.States.ContainsKey(i))
            {
                i++;
            }
            DB.AddStateToProject(state, project, i);
            project.States.Add(i, state);
        }
        public bool AddUserToIUsersAssigned(User user, IUsersAssigned usersAssigned)
        {

            string typeName = usersAssigned.GetType().Name;
            switch (typeName)
            {
                case "Project":
                    this.AddUserToProject(user, usersAssigned as Project);
                    break;
                case "UserStory":
                    this.AddUserToUserStory(user, usersAssigned as UserStory);
                    break;
                case "ChecklistItem":
                    this.AddUserToChecklistItem(user, usersAssigned as ChecklistItem);
                    break;
                default:
                    return false;
            }
            return true;
        }
        private void AddUserToUserStory(User user, UserStory userStory)
        {
            DB.AddUserToUserStory(user, userStory);
            this.CreateActivity(String.Format("\"{0}\" a été assigné", user), userStory);
            userStory.AddUser(user);
        }
        private void AddUserToChecklistItem(User user, ChecklistItem checklistItem)
        {
            DB.AddUserToChecklistItem(user, checklistItem);
            checklistItem.AddUser(user);
        }
        private void AddUserToProject(User user, Project project)
        {
            DB.AddUserToProject(user, project);
            project.AddUser(user);
        }
        public void CreateActivity(string description, UserStory userStory)
        {
            userStory.Activities.Add(DB.CreateActivity(description, DateTime.Now, userStory));
        }
        public void CreateUserStory(string description, DateTime? selectedDate, int complexity, Priority aPriority, Classes.Type aType, Project aProject)
        {
            UserStory userStory = DB.CreateUserStory(description, selectedDate, complexity, aPriority, aType, aProject.States.First().Value, aProject);
            aProject.AllUserStories.Add(userStory);
            this.CreateActivity("A été créé", userStory);
        }
        public void CreateSprint(DateTime dateBegin, DateTime dateEnd, Project aProject)
        {
            aProject.Sprints.Add(DB.CreateSprint(dateBegin, dateEnd, aProject));
        }
        public void CreateFile(string fileName, string description, UserStory userStory)
        {
            Classes.File file = DB.CreateFile(fileName, description, userStory);
            userStory.Files.Add(file);
            this.CreateActivity(String.Format("\"{0}\" a été lié", file), userStory);
        }
        public void CreateUser(string name)
        {
            users.Add(DB.CreateUser(name));
        }
        public void CreateState(string name)
        {
            states.Add(DB.CreateState(name));
        }
        public void CreateComment(string text, User user, UserStory userStory)
        {
            userStory.Comments.Add(DB.CreateComment(text, userStory, user));
            this.CreateActivity(String.Format("\"{0}\" a commenté", user), userStory);
        }
        public void CreateCheckListItem(string aName, Checklist checklist)
        {
            checklist.ChecklistItems.Add(DB.CreateCheckListItem(aName, checklist));
        }
        public Checklist CreateCheckList(string aName, UserStory aUserStory)
        {
            Checklist checklist = DB.CreateCheckList(aName, aUserStory);
            aUserStory.Checklists.Add(checklist);
            this.CreateActivity(String.Format("La checklist \"{0}\" a été créée", checklist), aUserStory);
            return checklist;
        }
        /// <summary>
        /// Create a project and add it to all projects
        /// </summary>
        /// <param name="aName"></param>
        /// <param name="aDesc"></param>
        /// <param name="aDate"></param>
        public void CreateProject(string aName, string aDesc, DateTime aDate)
        {
            Project project = (DB.CreateProject(aName, aDesc, aDate));
            project.States.Add(0, states[0]);
            project.States.Add(1, states[1]);
            project.States.Add(2, states[2]);

            DB.AddStateToProject(states[0], project, 0);
            DB.AddStateToProject(states[1], project, 1);
            DB.AddStateToProject(states[2], project, 2);

            projects.Add(project);
        } 
        #endregion

    }
}
