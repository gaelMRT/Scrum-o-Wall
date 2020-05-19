using Scrum_o_wall;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scrum_o_wall.Classes;
using System.Reflection;

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
        public void GetFileTypesTest()
        {
            Assert.IsNotNull(DB.GetFileTypes());
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

        }
        [TestMethod]
        public void CreateUpdateDeleteChecklistItem()
        {

        }
        [TestMethod]
        public void CreateUpdateDeleteComment()
        {

        }
        [TestMethod]
        public void CreateUpdateDeleteFile()
        {

        }
        [TestMethod]
        public void CreateUpdateDeleteMindmap()
        {

        }
        [TestMethod]
        public void CreateUpdateDeleteNode()
        {

        }
        [TestMethod]
        public void CreateUpdateDeleteProject()
        {

        }
        [TestMethod]
        public void CreateUpdateDeleteSprint()
        {

        }
        [TestMethod]
        public void CreateUpdateDeleteState()
        {

        }
        [TestMethod]
        public void CreateUpdateDeleteUser()
        {

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