using Scrum_o_wall.Classes;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
            List<Node> allNodes;
            List<MindMap> allMindMaps;

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
            allNodes = DB.GetNodes();
            allMindMaps = DB.GetMindMaps();


            #region Link State with project
            projectStates = DB.GetProjectStates();
            // 0:IdProject,1:IdState,2:order
            foreach (int[] item in projectStates)
            {
                List<Project> project = allProjects.Where(p => p.Id == item[0]).ToList();
                List<State> state = allStates.Where(s => s.Id == item[1]).ToList();

                if (project.Count == 1 && state.Count == 1)
                {
                    project[0].States.Add(item[2], state[0]);
                }

            }
            #endregion

            #region Link UserStory with other classes
            foreach (UserStory u in allUserStories)
            {
                List<Project> project = allProjects.Where(p => p.Id == u.ProjectId).ToList();
                List<State> state = allStates.Where(s => s.Id == u.StateId).ToList();
                List<Priority> priority = allPriorities.Where(p => p.Id == u.PriorityId).ToList();
                List<Classes.Type> type = allTypes.Where(t => t.Id == u.TypeId).ToList();

                List<Activity> activities = allActivities.Where(a => a.UserStoryId == u.Id).ToList();
                List<Classes.File> files = allFiles.Where(f => f.UserStoryId == u.Id).ToList();
                List<Checklist> checklists = allChecklists.Where(c => c.UserStoryId == u.Id).ToList();

                if (state.Count == 1)
                {
                    u.State = state[0];
                }
                if (priority.Count == 1)
                {
                    u.Priority = priority[0];
                }
                if (type.Count == 1)
                {
                    u.Type = type[0];
                }
                if (project.Count == 1)
                {
                    project[0].AllUserStories.Add(u);
                    u.Project = project[0];
                }
                u.Activities = activities;
                foreach (Activity a in activities)
                {
                    a.UserStory = u;
                }
                u.Checklists = checklists;
                foreach (Checklist c in checklists)
                {
                    c.UserStory = u;
                }

                u.Files = files;
                foreach (Classes.File f in files)
                {
                    f.UserStory = u;
                }
            }
            #endregion

            #region Link UserStory with Sprint
            userStoriesSprint = DB.GetUserStoriesSprint();
            // 0:IdUserStory,1:IdSprint,2:Order
            foreach (int[] item in userStoriesSprint)
            {
                List<UserStory> userStory = allUserStories.Where(u => u.Id == item[0]).ToList();
                List<Sprint> sprint = allSprints.Where(s => s.Id == item[1]).ToList();
                if (userStory.Count == 1 && sprint.Count == 1)
                {
                    sprint[0].addUserStory(item[2], userStory[0]);
                }
            }
            #endregion

            #region Link Sprint with Project
            foreach (Sprint s in allSprints)
            {
                List<Project> project = allProjects.Where(p => p.Id == s.ProjectId).ToList();
                if (project.Count == 1)
                {
                    s.Project = project[0];
                    project[0].Sprints.Add(s);
                }
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
                List<User> user = allUsers.Where(u => u.Id == item[0]).ToList();
                List<UserStory> userStory = allUserStories.Where(us => us.Id == item[1]).ToList();
                if (userStory.Count == 1 && user.Count == 1)
                {
                    userStory[0].AddUser(user[0]);
                }
            }
            #endregion
            #region Link user with CheckListItem
            userChecklistItem = DB.GetUserChecklistItem();
            foreach (int[] item in userChecklistItem)
            {
                // 0:IdUser,1:IdChecklistItem
                List<User> user = allUsers.Where(u => u.Id == item[0]).ToList();
                List<ChecklistItem> checklistItem = allChecklistItems.Where(c => c.Id == item[1]).ToList();
                if (checklistItem.Count == 1 && user.Count == 1)
                {
                    checklistItem[0].AddUser(user[0]);
                }
            }
            #endregion
            #region Link user with Project
            userProjects = DB.GetUserProject();
            foreach (int[] item in userProjects)
            {
                // 0:IdUser,1:IdProject
                List<User> user = allUsers.Where(u => u.Id == item[0]).ToList();
                List<Project> project = allProjects.Where(p => p.Id == item[1]).ToList();
                if (project.Count == 1 && user.Count == 1)
                {
                    project[0].AddUser(user[0]);
                }
            }
            #endregion

            #region Link Node with Nodes and mindmaps
            foreach (Node node in allNodes)
            {
                //verify if root node or not
                if(node.PreviousId == null)
                {
                    List<MindMap> mindMaps = allMindMaps.Where(m => m.Id == node.MindmapId).ToList();
                    if (mindMaps.Count == 1)
                    {
                        node.MindMap = mindMaps[0];
                        mindMaps[0].Root = node;
                    }
                }
                else
                {
                    List<Node> nodes = allNodes.Where(n => n.Id == node.PreviousId).ToList();
                    if (nodes.Count == 1)
                    {
                        node.Previous = nodes[0];
                    }
                }

                List<Node> childrens = allNodes.Where(n => n.PreviousId == node.Id).ToList();
                node.Childrens = childrens;

            }
            #endregion

            #region Link MindMaps with projects
            foreach (MindMap mindMap in allMindMaps)
            {
                List<Project> projects = allProjects.Where(p => p.Id == mindMap.ProjectId).ToList();
                if(projects.Count == 1)
                {
                    mindMap.Project = projects[0];
                    projects[0].MindMaps.Add(mindMap);
                }
            }
            #endregion

            projects = allProjects;
            users = allUsers;
            types = allTypes;
            priorities = allPriorities;
            states = allStates;
        }



        #region Remove Methods


        public bool Delete(Project project)
        {
            bool result = DB.Delete(project);
            projects.Remove(project);
            return result;
        }
        public bool Delete(Checklist checklist)
        {
            bool result = DB.Delete(checklist);
            checklist.UserStory.Checklists.Remove(checklist);
            return result;
        }
        public bool Delete(User user)
        {
            bool result = DB.Delete(user);
            users.Remove(user);
            return result;
        }
        public bool Delete(State state)
        {
            List<Project> removingState = projects.Where(p => p.States.ContainsValue(state)).ToList();
            foreach (Project project in removingState)
            {
                this.RemoveStateFromProject(state, project);
            }
            bool result = DB.Delete(state);
            return result;
        }
        public bool Delete(Sprint sprint)
        {
            sprint.Project.Sprints.Remove(sprint);
            bool result = DB.Delete(sprint);
            return result;
        }
        public bool Delete(ChecklistItem checklistItem)
        {
            checklistItem.Checklist.ChecklistItems.Remove(checklistItem);
            bool result = DB.Delete(checklistItem);
            return result;
        }
        public bool Delete(UserStory userStory)
        {
            List<Sprint> sprintRemoveUserStory = userStory.Project.Sprints.Where(s => s.OrderedUserStories.ContainsValue(userStory)).ToList();
            foreach (Sprint sprint in sprintRemoveUserStory)
            {
                this.RemoveUserStoryFromSprint(userStory, sprint);
            }
            userStory.Project.AllUserStories.Remove(userStory);
            bool result = DB.Delete(userStory);
            return result;
        }
        public bool Delete(Comment comment)
        {
            bool result = DB.Delete(comment);
            return result;
        }
        public bool Delete(Activity activity)
        {
            bool result = DB.Delete(activity);
            return result;
        }
        public bool Delete(Classes.File file)
        {
            bool result = DB.Delete(file);
            file.UserStory.Files.Remove(file);
            return result;
        }
        public bool RemoveStateFromProject(State state, Project project)
        {
            int order = -1;
            if (project.States.ContainsValue(state) && project.States.Count > 1)
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
        private bool RemoveUserFromChecklistItem(User user, ChecklistItem checklistItem)
        {
            bool result = DB.RemoveUserFromChecklistItem(user, checklistItem);
            checklistItem.RemoveUser(user);
            return result;
        }
        private bool RemoveUserFromUserStory(User user, UserStory userStory)
        {
            bool result = DB.RemoveUserFromUserStory(user, userStory);
            this.CreateActivity(String.Format("\"{0}\" a été désassigné", user), userStory);
            userStory.RemoveUser(user);
            return result;
        }
        private bool RemoveUserFromProject(User user, Project project)
        {
            bool result = DB.RemoveUserFromProject(user, project);
            project.RemoveUser(user);
            return result;
        }
        public bool RemoveUserStoryFromSprint(UserStory userStory, Sprint sprint)
        {
            bool result = false;
            if (sprint.OrderedUserStories.ContainsValue(userStory))
            {
                int order = 0;
                while (!sprint.OrderedUserStories.ContainsKey(order) || sprint.OrderedUserStories[order] != userStory)
                {
                    order++;
                }
                this.CreateActivity(String.Format("A été supprimé du sprint \"{0}\"", sprint), userStory);
                sprint.removeUserStoryByOrder(order);
                result = DB.RemoveUserStoryFromSprint(userStory, sprint, order);
            }
            return result;
        }
        public bool Delete(MindMap mindMap)
        {
            bool result = DB.Delete(mindMap);
            mindMap.Project.MindMaps.Remove(mindMap);
            return result;
        }
        public bool Delete(Node node)
        {
            bool result = DB.Delete(node);
            if (!result)
            {
                return result;
            }
            foreach (Node n in node.Childrens)
            {
                n.Previous = node.Previous;
                node.Previous.Childrens.Add(n);
            }
            node.Previous.Childrens.Remove(node);
            return result;
        }

        #endregion

        #region Update Methods
        public bool UserStorySwitchState(UserStory userStory, State state)
        {
            bool result = false;
            if (userStory.State != state)
            {
                this.CreateActivity(String.Format("Passé de l'état \"{0}\" à l'état \"{1}\"", userStory.State, state), userStory);
                result = DB.UpdateUserStory(userStory.Description, userStory.DateLimit, userStory.ComplexityEstimation, userStory.CompletedComplexity, userStory.Blocked, userStory.Priority, state, userStory.Type, userStory);
                userStory.State = state;
            }
            return result;
        }
        public bool UpdateCheckListItem(string nameItem, bool done, ChecklistItem item)
        {
            bool result = DB.UpdateCheckListItem(nameItem, done, item);
            item.NameItem = nameItem;
            item.Done = done;
            return result;
        }
        public bool UpdateUserStory(string description, DateTime? selectedDate, int complexity, int completedComplexity, bool blocked, Priority aPriority, Classes.Type aType, State aState, UserStory userStory)
        {
            bool result = false;
            if (userStory.Description != description ||
                userStory.DateLimit != selectedDate ||
                userStory.ComplexityEstimation != complexity ||
                userStory.CompletedComplexity != completedComplexity ||
                userStory.Blocked != blocked ||
                userStory.Priority != aPriority ||
                userStory.Type != aType ||
                userStory.State != aState)
            {
                this.CreateActivity("Les informations ont été mises à jour", userStory);
                result = DB.UpdateUserStory(description, selectedDate, complexity, completedComplexity, blocked, aPriority, aState, aType, userStory);
                userStory.Description = description;
                userStory.DateLimit = selectedDate;
                userStory.ComplexityEstimation = complexity;
                userStory.CompletedComplexity = completedComplexity;
                userStory.Blocked = blocked;
                userStory.State = aState;
                userStory.Priority = aPriority;
                userStory.Type = aType;
            }
            return result;
        }
        public bool UpdateFile(string fileDescription, Classes.File file)
        {
            bool result = DB.UpdateFile(fileDescription, file);
            file.Description = fileDescription;
            return result;
        }
        public bool UpdateCheckList(string name, List<ChecklistItem> items, Checklist checklist)
        {
            bool result = DB.UpdateCheckList(name, checklist);
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
            return result;
        }
        public bool UpdateProject(string name, string description, DateTime dateTime, Project aProject)
        {
            bool result = DB.UpdateProject(name, description, dateTime, aProject);
            aProject.Name = name;
            aProject.Description = description;
            aProject.Begin = dateTime;
            return result;
        }
        public bool UpdateState(string text, State state)
        {
            bool result = DB.UpdateState(text, state);
            state.Name = text;
            return result;
        }
        public bool UpdateSprint(DateTime begin, DateTime end, Sprint sprint)
        {
            bool result = DB.UpdateSprint(begin, end, sprint);
            sprint.Begin = begin;
            sprint.End = end;
            return result;
        }
        public bool UpdateUser(string text, User user)
        {
            bool result = DB.UpdateUser(text, user);
            user.Name = text;
            return result;
        }
        public bool UpdateMindMap(string text, MindMap mindMap)
        {
            bool result = DB.UpdateMindMap(text, mindMap);
            mindMap.Name = text;
            return result;
        }
        public bool UpdateNode(string text,Node previous, Node node)
        {
            bool result = DB.UpdateNode(text, previous,node);
            if (!result)
            {
                return result;
            }

            if (node.Previous != previous)
            {
                node.Previous.Childrens.Remove(node);
                node.Previous = previous;
                previous.Childrens.Add(node);
            }
            node.Name = text;

            return result;
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
        public bool AddStateToProject(State state, Project project)
        {
            int i = 0;
            while (project.States.ContainsKey(i))
            {
                i++;
            }
            bool result = DB.AddStateToProject(state, project, i);
            project.States.Add(i, state);
            return result;
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
        private bool AddUserToUserStory(User user, UserStory userStory)
        {
            bool result = DB.AddUserToUserStory(user, userStory);
            this.CreateActivity(String.Format("\"{0}\" a été assigné", user), userStory);
            userStory.AddUser(user);
            return result;
        }
        private bool AddUserToChecklistItem(User user, ChecklistItem checklistItem)
        {
            bool result = DB.AddUserToChecklistItem(user, checklistItem);
            checklistItem.AddUser(user);
            return result;
        }
        private bool AddUserToProject(User user, Project project)
        {
            bool result = DB.AddUserToProject(user, project);
            project.AddUser(user);
            return result;
        }
        public bool CreateActivity(string description, UserStory userStory)
        {
            Activity activity = DB.CreateActivity(description, DateTime.Now, userStory);
            bool result = activity != null;
            userStory.Activities.Add(activity);
            activity.UserStory = userStory;
            return result;
        }
        public bool CreateUserStory(string description, DateTime? selectedDate, int complexity, Priority aPriority, Classes.Type aType, Project aProject)
        {
            UserStory userStory = DB.CreateUserStory(description, selectedDate, complexity, aPriority, aType, aProject.States.First().Value, aProject);
            bool result = userStory != null;

            userStory.Priority = aPriority;
            userStory.Type = aType;
            userStory.State = aProject.States.First().Value;
            userStory.Project = aProject;

            aProject.AllUserStories.Add(userStory);
            this.CreateActivity("A été créé", userStory);
            return result;
        }
        public bool CreateSprint(DateTime dateBegin, DateTime dateEnd, Project aProject)
        {
            Sprint sprint = DB.CreateSprint(dateBegin, dateEnd, aProject);
            bool result = sprint != null;
            sprint.Project = aProject;
            aProject.Sprints.Add(sprint);
            return result;
        }
        public bool CreateFile(string fileName, string description, UserStory userStory)
        {
            Classes.File file = DB.CreateFile(fileName, description, userStory);
            bool result = file != null;
            userStory.Files.Add(file);
            file.UserStory = userStory;
            this.CreateActivity(String.Format("\"{0}\" a été lié", file), userStory);
            return result;
        }
        public bool CreateUser(string name)
        {
            User user = DB.CreateUser(name);
            bool result = user != null;
            users.Add(DB.CreateUser(name));
            return result;
        }
        public bool CreateState(string name)
        {
            State state = DB.CreateState(name);
            bool result = state != null;
            states.Add(DB.CreateState(name));
            return result;
        }
        public bool CreateComment(string text, User user, UserStory userStory)
        {
            Comment comment = DB.CreateComment(text, userStory, user);
            bool result = comment != null;
            comment.UserStory = userStory;
            userStory.Comments.Add(comment);

            this.CreateActivity(String.Format("\"{0}\" a commenté", user), userStory);
            return result;
        }
        public bool CreateCheckListItem(string aName, Checklist checklist)
        {
            ChecklistItem checklistItem = DB.CreateCheckListItem(aName, checklist);
            bool result = checklistItem != null;
            checklistItem.Checklist = checklist;
            checklist.ChecklistItems.Add(checklistItem);
            return result;
        }
        public Checklist CreateCheckList(string aName, UserStory aUserStory)
        {
            Checklist checklist = DB.CreateCheckList(aName, aUserStory);
            aUserStory.Checklists.Add(checklist);
            checklist.UserStory = aUserStory;
            this.CreateActivity(String.Format("La checklist \"{0}\" a été créée", checklist), aUserStory);
            return checklist;
        }
        /// <summary>
        /// Create a project and add it to all projects
        /// </summary>
        /// <param name="aName"></param>
        /// <param name="aDesc"></param>
        /// <param name="aDate"></param>
        public bool CreateProject(string aName, string aDesc, DateTime aDate)
        {
            Project project = DB.CreateProject(aName, aDesc, aDate);

            bool result = project != null;
            if (states.Count < 3)
            {
                this.CreateState("A faire");
                this.CreateState("En cours");
                this.CreateState("Accompli");
            }
            project.States.Add(0, states[0]);
            project.States.Add(1, states[1]);
            project.States.Add(2, states[2]);

            DB.AddStateToProject(states[0], project, 0);
            DB.AddStateToProject(states[1], project, 1);
            DB.AddStateToProject(states[2], project, 2);

            projects.Add(project);
            return result;
        }

        public bool CreateMindMap(string aName, Project project)
        {
            MindMap mindMap = DB.CreateMindmap(aName, project);
            bool result = mindMap != null;
            project.MindMaps.Add(mindMap);
            mindMap.Project = project;
            mindMap.Root = DB.CreateNode(aName, null, mindMap);
            return result;
        }
        public bool CreateNode(string aName, Node previous,MindMap mindMap)
        {
            Node node = DB.CreateNode(aName,previous,mindMap);
            bool result = node != null;
            if (previous != null)
            {
                previous.Childrens.Add(node);
            }
            else
            {
                mindMap.Root = node;
            }
            node.Previous = previous;
            node.MindMap = mindMap;
            return result;
        }
        #endregion

    }
}
