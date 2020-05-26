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
        public void GetUserStoriesSprintTest()
        {
            Assert.IsNotNull(DB.GetUserStoriesSprint());
        }

        [TestMethod()]
        public void GetProjectStatesTest()
        {
            Assert.IsNotNull(DB.GetProjectStates());
        }

        [TestMethod()]
        public void GetUserProjectTest()
        {
            Assert.IsNotNull(DB.GetUserProject());
        }

        [TestMethod()]
        public void GetUserChecklistItemTest()
        {
            Assert.IsNotNull(DB.GetUserChecklistItem());
        }

        [TestMethod()]
        public void GetUserUserStoryTest()
        {
            Assert.IsNotNull(DB.GetUserUserStory());
        }

        [TestMethod()]
        public void GetProjectsTest()
        {
            Assert.IsNotNull(DB.GetProjects());
        }

        [TestMethod()]
        public void GetSprintsTest()
        {
            Assert.IsNotNull(DB.GetSprints());
        }

        [TestMethod()]
        public void GetUserStoriesTest()
        {
            Assert.IsNotNull(DB.GetUserStories());
        }

        [TestMethod()]
        public void GetUsersTest()
        {
            Assert.IsNotNull(DB.GetUsers());
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

        [TestMethod()]
        public void GetFilesTest()
        {
            Assert.IsNotNull(DB.GetFiles());
        }

        [TestMethod()]
        public void GetActivitiesTest()
        {
            Assert.IsNotNull(DB.GetActivities());
        }

        [TestMethod()]
        public void GetChecklistsTest()
        {
            Assert.IsNotNull(DB.GetChecklists());
        }

        [TestMethod()]
        public void GetChecklistItemsTest()
        {
            Assert.IsNotNull(DB.GetChecklistItems());
        }

        [TestMethod()]
        public void GetCommentsTest()
        {
            Assert.IsNotNull(DB.GetComments());
        }

        [TestMethod()]
        public void GetStatesTest()
        {
            Assert.IsNotNull(DB.GetStates());
        }

        [TestMethod]
        public void CreateDeleteActivity()
        {
            string aDesc = "activity test";
            DateTime eventTime = DateTime.Now;
            UserStory userStory = DB.GetUserStories().Last();

            Activity a = DB.CreateActivity(aDesc, eventTime, userStory);

            Assert.AreEqual(aDesc, a.Description);
            Assert.AreEqual(eventTime, a.DateTime);
            Assert.AreEqual(userStory.Id,a.UserStoryId);

            Assert.IsTrue(DB.DeleteActivity(a));
        }
        [TestMethod]
        public void CreateUpdateDeleteChecklist()
        {
            //Test Create
            string aName = "checlist first name";
            UserStory userStory = DB.GetUserStories().Last();

            Checklist checklist = DB.CreateCheckList(aName, userStory);

            Assert.AreEqual(aName, checklist.Name);
            Assert.AreEqual(userStory.Id, checklist.UserStoryId);

            //Test Update
            string afterName = "checklist second name";

            DB.UpdateCheckList(afterName, checklist);
            checklist = DB.GetChecklists().First(c => c.Id == checklist.Id);

            Assert.AreEqual(afterName, checklist.Name);

            //Test Remove
            Assert.IsTrue(DB.DeleteChecklist(checklist));

        }
        [TestMethod]
        public void CreateUpdateDeleteChecklistItem()
        {
            //Test Create
            string aName = "checlistItem first name";
            Checklist checklist = DB.GetChecklists().Last();

            ChecklistItem checklistItem = DB.CreateCheckListItem(aName, checklist);

            Assert.AreEqual(aName, checklistItem.NameItem);
            Assert.IsFalse(checklistItem.Done);
            Assert.AreEqual(checklist.Id, checklistItem.ChecklistId);

            //Test Update
            string afterName = "checklistItem second name";

            DB.UpdateCheckListItem(afterName,true, checklistItem);
            checklistItem = DB.GetChecklistItems().First(c => c.Id == checklistItem.Id);

            Assert.AreEqual(afterName, checklistItem.NameItem);
            Assert.IsTrue(checklistItem.Done);

            //Test Remove
            Assert.IsTrue(DB.DeleteChecklistItem(checklistItem));
        }
        [TestMethod]
        public void CreateDeleteComment()
        {
            //Test Create
            string aName = "comment first name";
            UserStory userStory = DB.GetUserStories().Last();
            User user = DB.GetUsers().Last();

            Comment comment = DB.CreateComment(aName, userStory,user);

            Assert.AreEqual(aName, comment.Description);
            Assert.AreEqual(userStory.Id, comment.UserStoryId);
            Assert.AreEqual(user.Id, comment.UserId);

            //Test Remove
            Assert.IsTrue(DB.DeleteComment(comment));
        }
        [TestMethod]
        public void CreateUpdateDeleteFile()
        {
            //Test Create
            string aName = "file first name";
            string aDesc = "this is a description";
            UserStory userStory = DB.GetUserStories().Last();

            File file = DB.CreateFile(aName,aDesc,userStory);

            Assert.AreEqual(aName, file.Name);
            Assert.AreEqual(aDesc, file.Description);
            Assert.AreEqual(userStory.Id, file.UserStoryId);

            //Test Update
            string afterDesc = "file second name";

            DB.UpdateFile(afterDesc, file);
            file = DB.GetFiles().First(f => f.Id == file.Id);

            Assert.AreEqual(afterDesc, file.Description);

            //Test Remove
            Assert.IsTrue(DB.DeleteFile(file));
        }
        [TestMethod]
        public void CreateUpdateDeleteProject()
        {
            //Test Create
            string firstName = "the project first Name";
            string firstDesc = "the project first description";
            DateTime firstDate = DateTime.Now;

            Project project = DB.CreateProject(firstName,firstDesc,firstDate);

            Assert.AreEqual(firstName, project.Name);
            Assert.AreEqual(firstDesc, project.Description);
            Assert.AreEqual(firstDate.ToString(), project.Begin.ToString());

            //Test Update
            string secName = "the project sec Name";
            string secDesc = "the project sec description";
            DateTime secDate = DateTime.Now + new TimeSpan(7,0,0,0);

            DB.UpdateProject(secName, secDesc, secDate,project);
            project = DB.GetProjects().First(p => p.Id == project.Id);

            Assert.AreEqual(secName, project.Name);
            Assert.AreEqual(secDesc, project.Description);
            Assert.AreEqual(secDate.ToString(), project.Begin.ToString());

            //Test Remove
            Assert.IsTrue(DB.DeleteProject(project));
        }
        [TestMethod]
        public void CreateUpdateDeleteSprint()
        {
            //Test Create
            DateTime firstBegin = DateTime.Now;
            DateTime firstEnd = firstBegin + new TimeSpan(7, 0, 0, 0);
            Project project = DB.GetProjects().Last();

            Sprint sprint = DB.CreateSprint(firstBegin,firstEnd,project);

            Assert.AreEqual(firstBegin.ToString(), sprint.Begin.ToString());
            Assert.AreEqual(firstEnd.ToString(), sprint.End.ToString());

            //Test Update
            DateTime secBegin = firstEnd;
            DateTime secEnd = secBegin + new TimeSpan(7, 0, 0, 0);

            DB.UpdateSprint(secBegin,secEnd,sprint);
            sprint = DB.GetSprints().First(s => s.Id == sprint.Id);

            Assert.AreEqual(secBegin.ToString(), sprint.Begin.ToString());
            Assert.AreEqual(secEnd.ToString(), sprint.End.ToString());

            //Test Remove
            Assert.IsTrue(DB.DeleteSprint(sprint));
        }
        [TestMethod]
        public void CreateUpdateDeleteState()
        {
            //Test Create
            string firstName = "first state name";

            State state = DB.CreateState(firstName);

            Assert.AreEqual(firstName, state.Name);


            //Test Remove
            Assert.IsTrue(DB.DeleteState(state));
        }
        [TestMethod]
        public void CreateUpdateDeleteUser()
        {
            //Test Create
            string firstName = "first user name";

            User user = DB.CreateUser(firstName);

            Assert.AreEqual(firstName, user.Name);

            //Test Remove
            Assert.IsTrue(DB.DeleteUser(user));
        }

        [TestMethod]
        public void CreateUpdateDeleteUserStoryTest()
        {
            List<Priority> priorities = DB.GetPriorities();
            List<State> states = DB.GetStates();
            List<Classes.Type> types = DB.GetTypes();
            List<Project> projects = DB.GetProjects();

            string firstDesc = "aDesc";
            DateTime? firstDate = DateTime.Now;
            int firstComplexity = 2;
            Priority firstPrio = priorities[0];
            Classes.Type firstType = types[0];
            State firstState = states[0];
            Project firstProj = projects[0];


            UserStory userStory = DB.CreateUserStory(firstDesc,firstDate,firstComplexity,firstPrio,firstType,firstState,firstProj);
            
            Assert.IsNotNull(userStory, "Exception in userStory creation");
            Assert.AreEqual(firstDesc, userStory.Description);
            Assert.AreEqual(firstDate, userStory.DateLimit);
            Assert.AreEqual(firstComplexity, userStory.ComplexityEstimation);
            Assert.AreEqual(firstPrio, userStory.Priority);
            Assert.AreEqual(firstType, userStory.Type);
            Assert.AreEqual(firstState, userStory.State);
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
            State secState = states[1];

            DB.UpdateUserStory(secDesc,secDate,secComplexity,secCompleted,secBlock,secPrio,secState,secType, userStory);

            userStory = DB.GetUserStories().First(u => u.Id == userStory.Id);

            Assert.AreEqual(secDesc, userStory.Description);
            Assert.AreEqual(secDate, userStory.DateLimit);
            Assert.AreEqual(secComplexity, userStory.ComplexityEstimation);
            Assert.AreEqual(secPrio.Id, userStory.PriorityId);
            Assert.AreEqual(secType.Id, userStory.TypeId);
            Assert.AreEqual(secState.Id, userStory.StateId);
            Assert.AreEqual(secBlock, userStory.Blocked);
            Assert.AreEqual(secCompleted, userStory.CompletedComplexity);

            Assert.IsTrue(DB.DeleteUserStory(userStory));
        }

    }
}