using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scrum_o_wall;
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
        [TestMethod()]
        public void ControllerTest()
        {
            DB.DbFileName = @"C:\Users\redwo\OneDrive\Scrum-o-Wall\TestDB.accdb";
            ctrl = new Controller();
            Assert.IsNotNull(ctrl);
        }


        [TestMethod()]
        public void CreateProjectTest()
        {
            int countBefore = DB.GetProjects().Count;
            int countAfterExpected = countBefore + 1;
            int countAfter;

            ctrl.CreateProject("aName", "aDesc", DateTime.Now);

            countAfter = DB.GetProjects().Count;

            Assert.AreEqual(countAfterExpected, countAfter);
        }
        [TestMethod()]
        public void CreateUserTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddUserStoryToSprintTest()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void AddStateToProjectTest()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void AddUserToIUsersAssignedTest()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void CreateActivityTest()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void CreateUserStoryTest()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void CreateSprintTest()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void CreateFileTest()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void CreateStateTest()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void CreateCommentTest()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void CreateCheckListItemTest()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void CreateCheckListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UserStorySwitchStateTest()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void UpdateUserStoryTest()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void UpdateFileTest()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void UpdateCheckListTest()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void UpdateProjectTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveStateFromProjectTest()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void RemoveUserFromIUsersAssignedTest()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void RemoveUserStoryFromSprintTest()
        {
            Assert.Fail();
        }
    }
}