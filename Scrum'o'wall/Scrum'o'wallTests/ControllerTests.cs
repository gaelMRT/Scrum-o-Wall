using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scrum_o_wall;
using Scrum_o_wall.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum_o_wall.Tests
{
    [TestClass()]
    public class ControllerTests
    {
        public static Controller ctrl;

        public static Activity activity;
        public static Checklist checklist;
        public static ChecklistItem checklistItem;
        public static Comment comment;
        public static Classes.File file;
        public static MindMap mindMap;
        public static Node node;
        public static Project project;
        public static Sprint sprint;
        public static State state;
        public static User user;
        public static UserStory userStory;

        [TestInitialize]
        public void TestInitialize()
        {
            DB.DbFileName = @"C:\Users\redwo\OneDrive\Scrum-o-Wall\TestDB.accdb";

            ctrl = new Controller();
        }


        [TestMethod]
        public void ControllerTest()
        {
            ctrl = new Controller();
            Assert.IsNotNull(ctrl);
        }
        [TestMethod]
        public void CreateProjectTest()
        {
            int countBefore = DB.GetProjects().Count;
            int countAfterExpected = countBefore + 1;
            int countAfter;

            ctrl.CreateProject("aName", "aDesc", DateTime.Now);

            countAfter = DB.GetProjects().Count;

            project = ctrl.Projects.Last();
            Assert.AreEqual(countAfterExpected, countAfter);
        }
        [TestMethod]
        public void CreateUserTest()
        {
            int countBefore = DB.GetUsers().Count;
            int countAfterExpected = countBefore + 1;
            int countAfter;

            ctrl.CreateUser("aName");

            countAfter = DB.GetUsers().Count;

            user = ctrl.Users.Last();
            Assert.AreEqual(countAfterExpected, countAfter);
        }
        [TestMethod]
        public void CreateUserStoryTest()
        {
            if (project == null)
            {
                project = ctrl.Projects.Last();
            }
            int countBefore = project.AllUserStories.Count;
            int countAfterExpected = countBefore + 1;
            int countAfter;

            ctrl.CreateUserStory("A description", null, 3, ctrl.Priorities.First(), ctrl.Types.First(), project);

            countAfter = project.AllUserStories.Count;

            userStory = project.AllUserStories.Last();
            Assert.AreEqual(countAfterExpected, countAfter);
        }
        [TestMethod]
        public void CreateActivityTest()
        {
            if (userStory == null)
            {
                userStory = ctrl.Projects.Last().AllUserStories.First();
            }
            int countBefore = userStory.Activities.Count;
            int countAfterExpected = countBefore + 1;
            int countAfter;

            ctrl.CreateActivity("aDescription", userStory);

            countAfter = userStory.Activities.Count;

            activity = userStory.Activities.Last();
            Assert.AreEqual(countAfterExpected, countAfter);
        }
        [TestMethod]
        public void CreateSprintTest()
        {
            if (project == null)
            {
                project = ctrl.Projects.Last();
            }
            int countBefore = project.Sprints.Count;
            int countAfterExpected = countBefore + 1;
            int countAfter;

            ctrl.CreateSprint(DateTime.Now, DateTime.Now + new TimeSpan(7, 0, 0, 0, 0), project);

            countAfter = project.Sprints.Count;

            sprint = project.Sprints.Last();
            Assert.AreEqual(countAfterExpected, countAfter);
        }
        [TestMethod]
        public void CreateFileTest()
        {
            if (userStory == null)
            {
                userStory = ctrl.Projects.Last().AllUserStories.First();
            }
            int countBefore = userStory.Files.Count;
            int countAfterExpected = countBefore + 1;
            int countAfter;

            ctrl.CreateFile("ce n'est pas un vrai nom de fichier", "Ce fichier n'existe pas et n'a jamais existé que ce soit dans le monde réel ou dans l'oblivion le plus total", ctrl.FileTypes.Last(), userStory);

            countAfter = userStory.Files.Count;

            file = userStory.Files.Last();
            Assert.AreEqual(countAfterExpected, countAfter);
        }
        [TestMethod]
        public void CreateStateTest()
        {
            int countBefore = ctrl.States.Count;
            int countAfterExpected = countBefore + 1;
            int countAfter;

            ctrl.CreateState("Nom d'état");

            countAfter = ctrl.States.Count;

            state = ctrl.States.Last();
            Assert.AreEqual(countAfterExpected, countAfter);
        }
        [TestMethod]
        public void CreateCommentTest()
        {
            if (user == null)
            {
                ctrl.Users.Last();
            }
            if (userStory == null)
            {
                userStory = ctrl.Projects.Last().AllUserStories.First();
            }
            int countBefore = userStory.Comments.Count;
            int countAfterExpected = countBefore + 1;
            int countAfter;

            ctrl.CreateComment("Ceci est un commentaire", user, userStory);

            countAfter = userStory.Comments.Count;

            comment = userStory.Comments.Last();
            Assert.AreEqual(countAfterExpected, countAfter);
        }
        [TestMethod]
        public void CreateCheckListTest()
        {
            if (userStory == null)
            {
                userStory = ctrl.Projects.Last().AllUserStories.First();
            }
            int countBefore = userStory.Checklists.Count;
            int countAfterExpected = countBefore + 1;
            int countAfter;

            ctrl.CreateCheckList("a checklist name", userStory);

            countAfter = userStory.Checklists.Count;

            checklist = userStory.Checklists.Last();
            Assert.AreEqual(countAfterExpected, countAfter);
        }
        [TestMethod]
        public void CreateCheckListItemTest()
        {
            if (checklist == null)
            {
                checklist = ctrl.Projects.Last().AllUserStories.Last(u => u.Checklists.Count > 0).Checklists[0];
            }
            int countBefore = checklist.ChecklistItems.Count;
            int countAfterExpected = countBefore + 1;
            int countAfter;

            ctrl.CreateCheckListItem("ceci est un checklist Item", checklist);

            countAfter = checklist.ChecklistItems.Count;

            checklistItem = checklist.ChecklistItems.Last();
            Assert.AreEqual(countAfterExpected, countAfter);
        }
        [TestMethod]
        public void AddUserStoryToSprintTest()
        {
            if (userStory == null)
            {
                userStory = ctrl.Projects.Last().AllUserStories.Last();
            }
            if (sprint == null)
            {
                sprint = ctrl.Projects.Last().Sprints.Last();
            }
            int countBefore = sprint.OrderedUserStories.Count;
            int countAfterExpected = countBefore + 1;
            int countAfter;

            ctrl.AddUserStoryToSprint(userStory, sprint);

            countAfter = sprint.OrderedUserStories.Count;

            Assert.AreEqual(countAfterExpected, countAfter);
        }
        [TestMethod]
        public void AddStateToProjectTest()
        {
            if (state == null)
            {
                state = ctrl.States.Last();
            }
            if (project == null)
            {
                project = ctrl.Projects.Last();
            }
            int countBefore = project.States.Count;
            int countAfterExpected = countBefore + 1;
            int countAfter;

            ctrl.AddStateToProject(state, project);

            countAfter = project.States.Count;

            Assert.AreEqual(countAfterExpected, countAfter);
        }
        [TestMethod]
        public void AddUserToIUsersAssignedTest()
        {
            user = ctrl.Users[0];
            project = ctrl.Projects.Last(p => p.AllUserStories.Count > 0 && p.AllUserStories.Count(u => u.Checklists.Count > 0 && u.Checklists.Count(c => c.ChecklistItems.Count > 0) > 0) > 0);
            userStory = project.AllUserStories.First(u => u.Checklists.Count > 0 && u.Checklists.Count(c => c.ChecklistItems.Count > 0) > 0);
            checklistItem = userStory.Checklists.First().ChecklistItems.First();

            //Test Project
            int countBefore = project.GetUsers().Count;
            int countAfterExpected = countBefore + 1;
            int countAfter;

            ctrl.AddUserToIUsersAssigned(user, project);

            countAfter = project.GetUsers().Count;

            Assert.AreEqual(countAfterExpected, countAfter);

            //Test UserStory
            countBefore = userStory.GetUsers().Count;
            countAfterExpected = countBefore + 1;

            ctrl.AddUserToIUsersAssigned(user, userStory);

            countAfter = userStory.GetUsers().Count;

            Assert.AreEqual(countAfterExpected, countAfter);

            //Test ChecklistItem
            countBefore = checklistItem.GetUsers().Count;
            countAfterExpected = countBefore + 1;

            ctrl.AddUserToIUsersAssigned(user, checklistItem);

            countAfter = checklistItem.GetUsers().Count;

            Assert.AreEqual(countAfterExpected, countAfter);
        }
        [TestMethod]
        public void UserStorySwitchStateTest()
        {
            if (userStory == null)
                userStory = ctrl.Projects.Last().AllUserStories.First();
            if (state == null)
                state = ctrl.States.Last();
            State expected = state;

            ctrl.UserStorySwitchState(userStory, state);

            State end = userStory.State;

            Assert.AreEqual(expected, end);
        }
        [TestMethod]
        public void UpdateUserStoryTest()
        {
            if (userStory == null)
                userStory = ctrl.Projects.Last().AllUserStories.First();


            string afterDesc = "another description";
            DateTime? afterTime = DateTime.Now;
            int afterComplexity = userStory.ComplexityEstimation + 1;
            int afterCompleted = userStory.CompletedComplexity + 2;
            bool afterBlocked = !userStory.Blocked;
            Priority afterPrio = ctrl.Priorities.First(p => p != userStory.Priority);
            Classes.Type afterType = ctrl.Types.First(t => t != userStory.Type);
            State afterState = ctrl.States.First(s => s != userStory.State);

            ctrl.UpdateUserStory(afterDesc, afterTime, afterComplexity, afterCompleted, afterBlocked, afterPrio, afterType, afterState, userStory);

            Assert.AreEqual(afterDesc, userStory.Description);
            Assert.AreEqual(afterTime, userStory.DateLimit);
            Assert.AreEqual(afterComplexity, userStory.ComplexityEstimation);
            Assert.AreEqual(afterCompleted, userStory.CompletedComplexity);
            Assert.AreEqual(afterBlocked, userStory.Blocked);
            Assert.AreEqual(afterPrio, userStory.Priority);
            Assert.AreEqual(afterType, userStory.Type);
            Assert.AreEqual(afterState, userStory.State);
        }
        [TestMethod]
        public void UpdateFileTest()
        {
            if (file == null)
                file = ctrl.Projects.Last().AllUserStories.Last().Files.Last();

            string newFileDesc = "this is a new file description";
            FileType newFileType = ctrl.FileTypes.First(ft => file.FileType != ft);

            ctrl.UpdateFile(newFileDesc, newFileType, file);

            Assert.AreEqual(newFileDesc, file.Description);
            Assert.AreEqual(newFileType, file.FileType);
        }
        [TestMethod]
        public void UpdateCheckListTest()
        {
            if (checklist == null)
            {
                checklist = ctrl.Projects.Last().AllUserStories.Last(u => u.Checklists.Count > 0).Checklists.Last();
            }

            string afterName = "this is a new name";

            ctrl.UpdateCheckList(afterName, checklist.ChecklistItems, checklist);

            Assert.AreEqual(afterName, checklist.Name);
        }
        [TestMethod]
        public void UpdateProjectTest()
        {
            if (project == null)
                project = ctrl.Projects.Last();

            string afterName = "new project name";
            string afterDesc = project.Description + " no u";
            DateTime afterBegin = project.Begin + new TimeSpan(7, 0, 0, 0, 0);

            ctrl.UpdateProject(afterName, afterDesc, afterBegin, project);

            Assert.AreEqual(afterName, project.Name);
            Assert.AreEqual(afterDesc, project.Description);
            Assert.AreEqual(afterBegin, project.Begin);

        }
        [TestMethod]
        public void RemoveStateFromProjectTest()
        {
            if (project == null)
            {
                project = ctrl.Projects.Last();
            }
            if (state == null || !project.States.ContainsValue(state))
            {
                state = project.States.Last().Value;
            }
            while (project.States.Count <= 1)
            {
                State addState = ctrl.States.First(s => !project.States.ContainsValue(s));
                ctrl.AddStateToProject(addState, project);
            }
            int countBefore = project.States.Count;
            int countAfterExpected = countBefore - 1;
            int countAfter;

            ctrl.RemoveStateFromProject(state, project);

            countAfter = project.States.Count;

            Assert.AreEqual(countAfterExpected, countAfter);
        }
        [TestMethod]
        public void RemoveUserFromIUsersAssignedTest()
        {
            if (user == null)
                user = ctrl.Users.Last();
            if (project == null)
                project = ctrl.Projects.Last();
            if (userStory == null)
                userStory = project.AllUserStories.First();
            if (checklistItem == null)
            {
                if (userStory.Checklists.Count == 0)
                {
                    ctrl.CreateCheckList("new Checklist", userStory);
                }
                if (userStory.Checklists.Last().ChecklistItems.Count == 0)
                {
                    ctrl.CreateCheckListItem("new checklistItem", userStory.Checklists.Last());
                }
                checklistItem = userStory.Checklists.Last().ChecklistItems.Last();
            }

            //Test Project
            if (!project.GetUsers().Contains(user))
            {
                ctrl.AddUserToIUsersAssigned(user, project);
            }
            int countBefore = project.GetUsers().Count;
            int countAfterExpected = countBefore - 1;
            int countAfter;

            ctrl.RemoveUserFromIUsersAssigned(user, project);

            countAfter = project.GetUsers().Count;

            Assert.AreEqual(countAfterExpected, countAfter);

            //Test UserStory
            if (!userStory.GetUsers().Contains(user))
            {
                ctrl.AddUserToIUsersAssigned(user, userStory);
            }
            countBefore = userStory.GetUsers().Count;
            countAfterExpected = countBefore - 1;

            ctrl.RemoveUserFromIUsersAssigned(user, userStory);

            countAfter = userStory.GetUsers().Count;

            Assert.AreEqual(countAfterExpected, countAfter);

            //Test ChecklistItem
            if (!checklistItem.GetUsers().Contains(user))
            {
                ctrl.AddUserToIUsersAssigned(user, checklistItem);
            }
            countBefore = checklistItem.GetUsers().Count;
            countAfterExpected = countBefore - 1;

            ctrl.RemoveUserFromIUsersAssigned(user, checklistItem);

            countAfter = checklistItem.GetUsers().Count;

            Assert.AreEqual(countAfterExpected, countAfter);
        }
        [TestMethod]
        public void RemoveUserStoryFromSprintTest()
        {
            if (sprint == null)
            {
                sprint = ctrl.Projects.Last().Sprints.Last();
            }
            if (userStory == null)
            {
                userStory = ctrl.Projects.Last().AllUserStories.Last();
            }
            if (!sprint.OrderedUserStories.ContainsValue(userStory))
            {
                ctrl.AddUserStoryToSprint(userStory, sprint);
            }
            int countBefore = sprint.OrderedUserStories.Count;
            int countAfterExpected = countBefore - 1;
            int countAfter;

            ctrl.RemoveUserStoryFromSprint(userStory, sprint);

            countAfter = sprint.OrderedUserStories.Count;

            Assert.AreEqual(countAfterExpected, countAfter);
        }
    }
}