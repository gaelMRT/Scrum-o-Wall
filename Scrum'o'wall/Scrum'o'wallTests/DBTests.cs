using Scrum_o_wall;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scrum_o_wall.Classes;
using System.Reflection;
using System.Security.AccessControl;

namespace Scrum_o_wall.Tests
{
    [TestClass()]
    public class DBTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            DB.DbFileName = @"C:\Users\redwo\OneDrive\Scrum-o-Wall\TestDB.accdb";
        }

        [TestMethod()]
        public void CRDUserStoriesSprintTest()
        {
            Project project = DB.CreateProject("aname", "adesc", DateTime.Now);

            //Create UserStory
            UserStory userStory;
            List<Priority> priorities = DB.GetPriorities();
            List<State> states = DB.GetStates();
            List<Classes.Type> types = DB.GetTypes();
            if (states.Count == 0)
            {
                DB.CreateState("AStateName");
                states = DB.GetStates();
            }
            userStory = DB.CreateUserStory("aDescription", null, 2, priorities[0], types[0], states[0], project);

            //Create Sprint
            Sprint sprint;
            sprint = DB.CreateSprint(DateTime.Now, DateTime.Now, project);
            int order = 0;

            //Link,test,unlink
            Assert.IsTrue(DB.AddUserStoryToSprint(userStory, sprint, order));
            Assert.IsNotNull(DB.GetUserStoriesSprint());
            Assert.IsTrue(DB.RemoveUserStoryFromSprint(userStory, sprint, order));

            DB.Delete(project);
            DB.Delete(userStory);
            DB.Delete(sprint);
        }
        [TestMethod()]
        public void CRDProjectStatesTest()
        {
            Project project = DB.CreateProject("aProjectName", "A Description for my project", DateTime.Now);
            State state = DB.CreateState("a new state");
            int order = 0;

            Assert.IsTrue(DB.AddStateToProject(state, project, order));
            Assert.IsNotNull(DB.GetProjectStates());
            Assert.IsTrue(DB.RemoveStateFromProject(project, order));

            DB.Delete(project);
            DB.Delete(state);
        }

        [TestMethod()]
        public void CRDUserProjectTest()
        {
            Project project = DB.CreateProject("aname", "adesc", DateTime.Now);
            User user = DB.CreateUser("a user name");

            Assert.IsTrue(DB.AddUserToProject(user, project));
            Assert.IsNotNull(DB.GetUserProject());
            Assert.IsTrue(DB.RemoveUserFromProject(user, project));

            DB.Delete(user);
            DB.Delete(project);
        }

        [TestMethod()]
        public void CRDUserChecklistItemTest()
        {
            //CreateChecklistItem
            List<Priority> priorities = DB.GetPriorities();
            List<State> states = DB.GetStates();
            List<Classes.Type> types = DB.GetTypes();
            List<Project> projects = DB.GetProjects();
            if (states.Count == 0)
            {
                DB.CreateState("AStateName");
                states = DB.GetStates();
            }
            if (projects.Count == 0)
            {
                DB.CreateProject("aProjectName", "A Description for my project", DateTime.Now);
                projects = DB.GetProjects();
            }
            UserStory userStory = DB.CreateUserStory("aDescription", null, 2, priorities[0], types[0], states[0], projects[0]);
            Checklist checklist = DB.CreateCheckList("a bioutifoul name", userStory);
            ChecklistItem checklistItem = DB.CreateCheckListItem("a better name", checklist);

            //CreateUser
            User user = DB.CreateUser("a user name");

            Assert.IsTrue(DB.AddUserToChecklistItem(user, checklistItem));
            Assert.IsNotNull(DB.GetUserChecklistItem());
            Assert.IsTrue(DB.RemoveUserFromChecklistItem(user, checklistItem));

            DB.Delete(user);
            DB.Delete(userStory);
            DB.Delete(checklistItem);
            DB.Delete(checklist);
        }
        [TestMethod()]
        public void CRDUserUserStoryTest()
        {
            //Create User Story
            List<Priority> priorities = DB.GetPriorities();
            List<State> states = DB.GetStates();
            List<Classes.Type> types = DB.GetTypes();
            List<Project> projects = DB.GetProjects();
            if (states.Count == 0)
            {
                DB.CreateState("AStateName");
                states = DB.GetStates();
            }
            if (projects.Count == 0)
            {
                DB.CreateProject("aProjectName", "A Description for my project", DateTime.Now);
                projects = DB.GetProjects();
            }
            UserStory userStory = DB.CreateUserStory("aDescription", null, 2, priorities[0], types[0], states[0], projects[0]);

            //Create User
            User user = DB.CreateUser("a user name");

            Assert.IsTrue(DB.AddUserToUserStory(user, userStory));
            Assert.IsNotNull(DB.GetUserUserStory());
            Assert.IsTrue(DB.RemoveUserFromUserStory(user, userStory));

            DB.Delete(userStory);
            DB.Delete(user);
        }
        [TestMethod()]
        public void GetTypesTest()
        {
            Assert.IsNotNull(DB.GetTypes());
        }
        [TestMethod()]
        public void GetPrioritiesTest()
        {
            Assert.IsNotNull(DB.GetPriorities());
        }
        [TestMethod]
        public void CRDActivity()
        {
            string aDesc = "activity test";
            DateTime eventTime = DateTime.Now;
            List<UserStory> userStories = DB.GetUserStories();
            UserStory userStory;
            if (userStories.Count == 0)
            {
                List<Priority> priorities = DB.GetPriorities();
                List<State> states = DB.GetStates();
                List<Classes.Type> types = DB.GetTypes();
                List<Project> projects = DB.GetProjects();
                if (states.Count == 0)
                {
                    DB.CreateState("AStateName");
                    states = DB.GetStates();
                }
                if (projects.Count == 0)
                {
                    DB.CreateProject("aProjectName", "A Description for my project", DateTime.Now);
                    projects = DB.GetProjects();
                }


                userStory = DB.CreateUserStory("aDescription", null, 2, priorities[0], types[0], states[0], projects[0]);
            }
            else
            {
                userStory = userStories.Last();
            }


            Activity a = DB.CreateActivity(aDesc, eventTime, userStory);

            Assert.AreEqual(aDesc, a.Description);
            Assert.AreEqual(eventTime, a.DateTime);
            Assert.AreEqual(userStory.Id, a.UserStoryId);

            Assert.IsNotNull(DB.GetActivities());

            Assert.IsTrue(DB.Delete(a));
        }
        [TestMethod]
        public void CRUDChecklist()
        {
            //Test Create
            string aName = "checlist first name";
            List<UserStory> userStories = DB.GetUserStories();
            UserStory userStory;
            if (userStories.Count == 0)
            {
                List<Priority> priorities = DB.GetPriorities();
                List<State> states = DB.GetStates();
                List<Classes.Type> types = DB.GetTypes();
                List<Project> projects = DB.GetProjects();
                if (states.Count == 0)
                {
                    DB.CreateState("AStateName");
                    states = DB.GetStates();
                }
                if (projects.Count == 0)
                {
                    DB.CreateProject("aProjectName", "A Description for my project", DateTime.Now);
                    projects = DB.GetProjects();
                }


                userStory = DB.CreateUserStory("aDescription", null, 2, priorities[0], types[0], states[0], projects[0]);
            }
            else
            {
                userStory = userStories.Last();
            }


            Checklist checklist = DB.CreateCheckList(aName, userStory);

            Assert.AreEqual(aName, checklist.Name);
            Assert.AreEqual(userStory.Id, checklist.UserStoryId);

            //Test Update
            string afterName = "checklist second name";

            DB.UpdateCheckList(afterName, checklist);
            checklist = DB.GetChecklists().First(c => c.Id == checklist.Id);

            Assert.AreEqual(afterName, checklist.Name);

            //Test Remove
            Assert.IsTrue(DB.Delete(checklist));

        }
        [TestMethod]
        public void CRUDChecklistItem()
        {
            //Test Create
            string aName = "checlistItem first name";
            List<Checklist> checklists = DB.GetChecklists();
            Checklist checklist;
            if (checklists.Count == 0)
            {
                List<UserStory> userStories = DB.GetUserStories();
                UserStory userStory;
                if (userStories.Count == 0)
                {
                    List<Priority> priorities = DB.GetPriorities();
                    List<State> states = DB.GetStates();
                    List<Classes.Type> types = DB.GetTypes();
                    List<Project> projects = DB.GetProjects();
                    if (states.Count == 0)
                    {
                        DB.CreateState("AStateName");
                        states = DB.GetStates();
                    }
                    if (projects.Count == 0)
                    {
                        DB.CreateProject("aProjectName", "A Description for my project", DateTime.Now);
                        projects = DB.GetProjects();
                    }


                    userStory = DB.CreateUserStory("aDescription", null, 2, priorities[0], types[0], states[0], projects[0]);
                }
                else
                {
                    userStory = userStories.Last();
                }

                checklist = DB.CreateCheckList("the name of a checklist", userStory);

            }
            else
            {
                checklist = checklists[0];
            }
            ChecklistItem checklistItem = DB.CreateCheckListItem(aName, checklist);

            Assert.AreEqual(aName, checklistItem.NameItem);
            Assert.IsFalse(checklistItem.Done);
            Assert.AreEqual(checklist.Id, checklistItem.ChecklistId);

            //Test Update
            string afterName = "checklistItem second name";

            DB.UpdateCheckListItem(afterName, true, checklistItem);
            checklistItem = DB.GetChecklistItems().First(c => c.Id == checklistItem.Id);

            Assert.AreEqual(afterName, checklistItem.NameItem);
            Assert.IsTrue(checklistItem.Done);

            //Test Remove
            Assert.IsTrue(DB.Delete(checklistItem));
        }
        [TestMethod]
        public void CRDComment()
        {
            //Test Create
            string aName = "comment first name";
            List<UserStory> userStories = DB.GetUserStories();
            UserStory userStory;
            if (userStories.Count == 0)
            {
                List<Priority> priorities = DB.GetPriorities();
                List<State> states = DB.GetStates();
                List<Classes.Type> types = DB.GetTypes();
                List<Project> projects = DB.GetProjects();
                if (states.Count == 0)
                {
                    DB.CreateState("AStateName");
                    states = DB.GetStates();
                }
                if (projects.Count == 0)
                {
                    DB.CreateProject("aProjectName", "A Description for my project", DateTime.Now);
                    projects = DB.GetProjects();
                }


                userStory = DB.CreateUserStory("aDescription", null, 2, priorities[0], types[0], states[0], projects[0]);
            }
            else
            {
                userStory = userStories.Last();
            }

            User user = DB.GetUsers().Last();

            Comment comment = DB.CreateComment(aName, userStory, user);

            Assert.AreEqual(aName, comment.Description);
            Assert.AreEqual(userStory.Id, comment.UserStoryId);
            Assert.AreEqual(user.Id, comment.UserId);

            Assert.IsNotNull(DB.GetComments());

            //Test Remove
            Assert.IsTrue(DB.Delete(comment));
        }
        [TestMethod]
        public void CRUDFile()
        {
            //Test Create
            string aName = "file first name";
            string aDesc = "this is a description";
            List<UserStory> userStories = DB.GetUserStories();
            UserStory userStory;
            if (userStories.Count == 0)
            {
                List<Priority> priorities = DB.GetPriorities();
                List<State> states = DB.GetStates();
                List<Classes.Type> types = DB.GetTypes();
                List<Project> projects = DB.GetProjects();
                if (states.Count == 0)
                {
                    DB.CreateState("AStateName");
                    states = DB.GetStates();
                }
                if (projects.Count == 0)
                {
                    DB.CreateProject("aProjectName", "A Description for my project", DateTime.Now);
                    projects = DB.GetProjects();
                }


                userStory = DB.CreateUserStory("aDescription", null, 2, priorities[0], types[0], states[0], projects[0]);
            }
            else
            {
                userStory = userStories.Last();
            }

            File file = DB.CreateFile(aName, aDesc, userStory);

            Assert.AreEqual(aName, file.Name);
            Assert.AreEqual(aDesc, file.Description);
            Assert.AreEqual(userStory.Id, file.UserStoryId);

            //Test Update
            string afterDesc = "file second name";

            DB.UpdateFile(afterDesc, file);
            file = DB.GetFiles().First(f => f.Id == file.Id);

            Assert.AreEqual(afterDesc, file.Description);

            //Test Remove
            Assert.IsTrue(DB.Delete(file));
        }
        [TestMethod]
        public void CRUDProject()
        {
            //Test Create
            string firstName = "the project first Name";
            string firstDesc = "the project first description";
            DateTime firstDate = DateTime.Now;

            Project project = DB.CreateProject(firstName, firstDesc, firstDate);

            Assert.AreEqual(firstName, project.Name);
            Assert.AreEqual(firstDesc, project.Description);
            Assert.AreEqual(firstDate.ToString(), project.Begin.ToString());

            //Test Update
            string secName = "the project sec Name";
            string secDesc = "the project sec description";
            DateTime secDate = DateTime.Now + new TimeSpan(7, 0, 0, 0);

            DB.UpdateProject(secName, secDesc, secDate, project);
            project = DB.GetProjects().First(p => p.Id == project.Id);

            Assert.AreEqual(secName, project.Name);
            Assert.AreEqual(secDesc, project.Description);
            Assert.AreEqual(secDate.ToString(), project.Begin.ToString());

            //Test Remove
            Assert.IsTrue(DB.Delete(project));
        }
        [TestMethod]
        public void CRUDSprint()
        {
            //Test Create
            DateTime firstBegin = DateTime.Now;
            DateTime firstEnd = firstBegin + new TimeSpan(7, 0, 0, 0);
            Project project = DB.GetProjects().Last();

            Sprint sprint = DB.CreateSprint(firstBegin, firstEnd, project);

            Assert.AreEqual(firstBegin.ToString(), sprint.Begin.ToString());
            Assert.AreEqual(firstEnd.ToString(), sprint.End.ToString());

            //Test Update
            DateTime secBegin = firstEnd;
            DateTime secEnd = secBegin + new TimeSpan(7, 0, 0, 0);

            DB.UpdateSprint(secBegin, secEnd, sprint);
            sprint = DB.GetSprints().First(s => s.Id == sprint.Id);

            Assert.AreEqual(secBegin.ToString(), sprint.Begin.ToString());
            Assert.AreEqual(secEnd.ToString(), sprint.End.ToString());

            //Test Remove
            Assert.IsTrue(DB.Delete(sprint));
        }
        [TestMethod]
        public void CRUDState()
        {
            //Test Create
            string firstName = "first state name";

            State state = DB.CreateState(firstName);

            Assert.AreEqual(firstName, state.Name);


            //Test Remove
            Assert.IsTrue(DB.Delete(state));
        }
        [TestMethod]
        public void CRUDUser()
        {
            //Test Create
            string firstName = "first user name";

            User user = DB.CreateUser(firstName);

            Assert.AreEqual(firstName, user.Name);

            //Test Remove
            Assert.IsTrue(DB.Delete(user));
        }
        [TestMethod]
        public void CRUDUserStoryTest()
        {
            List<Priority> priorities = DB.GetPriorities();
            List<State> states = DB.GetStates();
            List<Classes.Type> types = DB.GetTypes();
            List<Project> projects = DB.GetProjects();
            if (states.Count == 0)
            {
                DB.CreateState("AStateName");
                states = DB.GetStates();
            }
            if (projects.Count == 0)
            {
                DB.CreateProject("aProjectName", "A Description for my project", DateTime.Now);
                projects = DB.GetProjects();
            }

            string firstDesc = "aDesc";
            DateTime? firstDate = DateTime.Now;
            int firstComplexity = 2;
            Priority firstPrio = priorities[0];
            Classes.Type firstType = types[0];
            State firstState = states[0];
            Project firstProj = projects[0];


            UserStory userStory = DB.CreateUserStory(firstDesc, firstDate, firstComplexity, firstPrio, firstType, firstState, firstProj);

            Assert.IsNotNull(userStory, "Exception in userStory creation");
            Assert.AreEqual(firstDesc, userStory.Description);
            Assert.AreEqual(firstDate, userStory.DateLimit);
            Assert.AreEqual(firstComplexity, userStory.ComplexityEstimation);
            Assert.AreEqual(firstPrio.Id, userStory.PriorityId);
            Assert.AreEqual(firstType.Id, userStory.TypeId);
            Assert.AreEqual(firstState.Id, userStory.StateId);
            Assert.AreEqual(firstProj.Id, userStory.ProjectId);
            Assert.AreEqual(false, userStory.Blocked);
            Assert.AreEqual(0, userStory.CompletedComplexity);


            string secDesc = "aNewDesc";
            DateTime? secDate = null;
            int secComplexity = 3;
            int secCompleted = 1;
            bool secBlock = true;
            Priority secPrio = priorities[1];
            Classes.Type secType = types[1];
            while (states.Count < 2)
            {
                DB.CreateState("An additional state name");
                states = DB.GetStates();
            }
            State secState = states[1];

            DB.UpdateUserStory(secDesc, secDate, secComplexity, secCompleted, secBlock, secPrio, secState, secType, userStory);

            userStory = DB.GetUserStories().First(u => u.Id == userStory.Id);

            Assert.AreEqual(secDesc, userStory.Description);
            Assert.AreEqual(secDate, userStory.DateLimit);
            Assert.AreEqual(secComplexity, userStory.ComplexityEstimation);
            Assert.AreEqual(secPrio.Id, userStory.PriorityId);
            Assert.AreEqual(secType.Id, userStory.TypeId);
            Assert.AreEqual(secState.Id, userStory.StateId);
            Assert.AreEqual(secBlock, userStory.Blocked);
            Assert.AreEqual(secCompleted, userStory.CompletedComplexity);

            Assert.IsTrue(DB.Delete(userStory));
        }

        [TestMethod]
        public void CRUDMindMap()
        {
            Project project;

            List<Project> projects = DB.GetProjects();
            if (projects.Count == 0)
            {
                project = DB.CreateProject("a Project", "A desc of a project", DateTime.Now);
            }
            else
            {
                project = projects[0];
            }

            string firstName = "a mindmap first name";
            string secondName = "a mindmap second name";

            //Verify creation 
            MindMap mindMap = DB.CreateMindmap(firstName, project);
            Assert.IsNotNull(mindMap);
            Assert.AreEqual(firstName, mindMap.Name);
            Assert.AreEqual(project.Id,mindMap.ProjectId);

            //Verify update
            Assert.IsTrue(DB.UpdateMindMap(secondName, mindMap));

            //Verify delete
            Assert.IsTrue(DB.Delete(mindMap));

            DB.Delete(project);
        }
        [TestMethod]
        public void CRUDNode()
        {
            Project project;
            MindMap mindmap;

            List<Project> projects = DB.GetProjects();
            if(projects.Count == 0)
            {
                project = DB.CreateProject("a Project", "A desc of a project", DateTime.Now);
            }
            else
            {
                project = projects[0];
            }
            List<MindMap> mindMaps = DB.GetMindMaps().Where(m => m.ProjectId == project.Id).ToList();
            if (mindMaps.Count == 0)
            {
                mindmap = DB.CreateMindmap("a mindmap name", project);
            }
            else
            {
                mindmap = mindMaps[0];
            }

            string firstName = "a node first name";
            string firstName2 = "a second node first name";
            string secondName = "a node second name";
            string secondName2 = "a second node second name";

            //Verify creation with and without previous
            Node node = DB.CreateNode(firstName, null, mindmap);

            Assert.IsNotNull(node);
            Assert.IsNull(node.PreviousId);
            Assert.AreEqual(firstName, node.Name);
            Assert.AreEqual(mindmap.Id, node.MindmapId);

            Node node2 = DB.CreateNode(firstName2, node, mindmap);

            Assert.IsNotNull(node2);
            Assert.AreEqual(node.Id, node2.PreviousId);
            Assert.AreEqual(firstName2, node2.Name);
            Assert.AreEqual(mindmap.Id, node2.MindmapId);

            //Verify updates with and without previous
            Assert.IsFalse(DB.UpdateNode(secondName, node2, node),"cannot change previous to root");
            Assert.IsTrue(DB.UpdateNode(secondName, null, node));
            Assert.IsFalse(DB.UpdateNode(secondName2, null, node2),"cannot change node to root");
            Assert.IsTrue(DB.UpdateNode(secondName2, node, node2));


            //Verify delete
            Assert.IsFalse(DB.Delete(node),"cannot delete root");
            Assert.IsTrue(DB.Delete(node2));

            DB.Delete(mindmap);
            DB.Delete(project);
        }
    }
}