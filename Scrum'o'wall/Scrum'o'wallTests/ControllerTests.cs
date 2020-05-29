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
        [TestInitialize]
        public void TestInitialize()
        {
            DB.DbFileName = @"C:\Users\redwo\OneDrive\Scrum-o-Wall\TestDB.accdb";

            ctrl = new Controller();
        }


        [TestMethod]
        public void ControllerTest()
        {
            Assert.IsNotNull(ctrl);
        }

        [TestMethod()]
        public void CRDUserStoriesSprintTest()
        {
            ctrl.CreateProject("a name for a project", "a desc for a project", DateTime.Now);
            Project project = ctrl.Projects.Last();

            ctrl.CreateSprint(DateTime.Now, DateTime.Now, project);
            Sprint sprint = project.Sprints[0];

            //if not exists, the database is incorrect
            Priority prio = ctrl.Priorities[0];
            Classes.Type type = ctrl.Types[0];
            ctrl.CreateUserStory("a description", null, 2, prio, type, project);
            UserStory userStory = project.AllUserStories[0];

            Assert.IsTrue(ctrl.AddUserStoryToSprint(userStory, sprint));
            Assert.IsTrue(sprint.OrderedUserStories.ContainsValue(userStory));
            Assert.IsTrue(ctrl.RemoveUserStoryFromSprint(userStory, sprint));

            ctrl.Delete(userStory);
            ctrl.Delete(sprint);
            ctrl.Delete(project);
        }
        [TestMethod()]
        public void CRDProjectStatesTest()
        {
            ctrl.CreateProject("aProjectName", "A Description for my project", DateTime.Now);
            Project project = ctrl.Projects.Last();

            ctrl.CreateState("a new state");
            State state = ctrl.States.Last();


            Assert.IsTrue(ctrl.AddStateToProject(state, project));
            Assert.IsTrue(project.States.ContainsValue(state));
            Assert.IsTrue(ctrl.RemoveStateFromProject(state, project));

            ctrl.Delete(project);
            ctrl.Delete(state);
        }

        [TestMethod()]
        public void CRDUserIUsersAssignedTest()
        {
            ctrl.CreateProject("aProjectName", "A Description for my project", DateTime.Now);
            Project project = ctrl.Projects.Last();

            ctrl.CreateUser("a user name");
            User user = ctrl.Users.Last();

            Assert.IsTrue(ctrl.AddUserToIUsersAssigned(user, project));
            Assert.IsTrue(project.GetUsers().Contains(user));
            Assert.IsTrue(ctrl.RemoveUserFromIUsersAssigned(user, project));


            ctrl.CreateUserStory("aDescription", null, 2, ctrl.Priorities[0], ctrl.Types[0], project);
            UserStory userStory = project.AllUserStories[0];

            Assert.IsTrue(ctrl.AddUserToIUsersAssigned(user, userStory));
            Assert.IsTrue(userStory.GetUsers().Contains(user));
            Assert.IsTrue(ctrl.RemoveUserFromIUsersAssigned(user, userStory));

            Checklist checklist = ctrl.CreateCheckList("a bioutifoul name", userStory);
            ctrl.CreateCheckListItem("a better name", checklist);
            ChecklistItem checklistItem = checklist.ChecklistItems[0];

            Assert.IsTrue(ctrl.AddUserToIUsersAssigned(user, checklistItem));
            Assert.IsTrue(checklistItem.GetUsers().Contains(user));
            Assert.IsTrue(ctrl.RemoveUserFromIUsersAssigned(user, checklistItem));

            ctrl.Delete(user);
            ctrl.Delete(checklistItem);
            ctrl.Delete(checklist);
            ctrl.Delete(userStory);
            ctrl.Delete(project);
        }
        [TestMethod]
        public void CRDActivity()
        {
            ctrl.CreateProject("aProjectName", "A Description for my project", DateTime.Now);
            Project project = ctrl.Projects.Last();
            ctrl.CreateUserStory("aDescription", null, 2, ctrl.Priorities[0], ctrl.Types[0], project);
            UserStory userStory = project.AllUserStories[0];
            string aDesc = "a desc for my activity";

            Assert.IsTrue(ctrl.CreateActivity(aDesc, userStory));
            Activity activity = userStory.Activities.Last();
            Assert.AreEqual(aDesc, activity.Description);
            Assert.IsTrue(ctrl.Delete(activity));
            
            ctrl.Delete(userStory);
            ctrl.Delete(project);
        }

        [TestMethod]
        public void CRUDChecklist()
        {
            //Test Create
            ctrl.CreateProject("aProjectName", "A Description for my project", DateTime.Now);
            Project project = ctrl.Projects.Last();
            ctrl.CreateUserStory("aDescription", null, 2, ctrl.Priorities[0], ctrl.Types[0], project);
            UserStory userStory = project.AllUserStories[0];
            string aName = "a first name";

            Checklist checklist = ctrl.CreateCheckList(aName, userStory);

            Assert.AreEqual(aName, checklist.Name);
            Assert.AreEqual(userStory.Id, checklist.UserStoryId);

            //Test Update
            string afterName = "checklist second name";

            Assert.IsTrue(ctrl.UpdateCheckList(afterName, new List<ChecklistItem>(), checklist));

            Assert.AreEqual(afterName, checklist.Name);

            //Test Remove
            Assert.IsTrue(ctrl.Delete(checklist));

            ctrl.Delete(userStory);
            ctrl.Delete(project);
        }
        [TestMethod]
        public void CRUDChecklistItem()
        {
            //Test Create
            string aName = "checlistItem first name";
            ctrl.CreateProject("aProjectName", "A Description for my project", DateTime.Now);
            Project project = ctrl.Projects.Last();
            ctrl.CreateUserStory("aDescription", null, 2, ctrl.Priorities[0], ctrl.Types[0], project);
            UserStory userStory = project.AllUserStories[0];
            ctrl.CreateCheckList("aCheck", userStory);
            Checklist checklist = userStory.Checklists[0]; 

            Assert.IsTrue(ctrl.CreateCheckListItem(aName, checklist));
            ChecklistItem checklistItem = checklist.ChecklistItems[0];

            Assert.AreEqual(aName, checklistItem.NameItem);
            Assert.IsFalse(checklistItem.Done);
            Assert.AreEqual(checklist, checklistItem.Checklist);

            //Test Update
            string afterName = "checklistItem second name";

            Assert.IsTrue(ctrl.UpdateCheckListItem(afterName, true, checklistItem));

            Assert.AreEqual(afterName, checklistItem.NameItem);
            Assert.IsTrue(checklistItem.Done);

            //Test Remove
            Assert.IsTrue(ctrl.Delete(checklistItem));

            ctrl.Delete(checklist);
            ctrl.Delete(userStory);
            ctrl.Delete(project);
        }
        [TestMethod]
        public void CRDComment()
        {
            //Test Create
            string aName = "comment first name";
            ctrl.CreateProject("aProjectName", "A Description for my project", DateTime.Now);
            Project project = ctrl.Projects.Last();
            ctrl.CreateUserStory("aDescription", null, 2, ctrl.Priorities[0], ctrl.Types[0], project);
            UserStory userStory = project.AllUserStories[0];

            ctrl.CreateUser("a user name");
            User user = ctrl.Users.Last();

            Assert.IsTrue(ctrl.CreateComment(aName, user, userStory));
            Comment comment = userStory.Comments[0];

            Assert.AreEqual(aName, comment.Description);
            Assert.AreEqual(userStory.Id, comment.UserStoryId);
            Assert.AreEqual(user.Id, comment.UserId);

            Assert.IsTrue(ctrl.Delete(comment));

            ctrl.Delete(user);
            ctrl.Delete(userStory);
            ctrl.Delete(project);
        }
        [TestMethod]
        public void CRUDFile()
        {
            //Declare needed variables
            string afterDesc = "file second name";
            string aName = "file first name";
            string aDesc = "this is a description";
            ctrl.CreateProject("aProjectName", "A Description for my project", DateTime.Now);
            Project project = ctrl.Projects.Last();
            ctrl.CreateUserStory("aDescription", null, 2, ctrl.Priorities[0], ctrl.Types[0], project);
            UserStory userStory = project.AllUserStories[0];

            //Test Create
            Assert.IsTrue(ctrl.CreateFile(aName, aDesc, userStory));
            File file = userStory.Files[0];

            Assert.AreEqual(aName, file.Name);
            Assert.AreEqual(aDesc, file.Description);
            Assert.AreEqual(userStory.Id, file.UserStoryId);

            //Test Update
            Assert.IsTrue(ctrl.UpdateFile(afterDesc, file));
            Assert.AreEqual(afterDesc, file.Description);

            //Test Remove
            Assert.IsTrue(ctrl.Delete(file));

            ctrl.Delete(project);
            ctrl.Delete(userStory);
        }
        [TestMethod]
        public void CRUDProject()
        {
            string firstName = "the project first Name";
            string firstDesc = "the project first description";
            DateTime firstDate = DateTime.Now;
            string secName = "the project sec Name";
            string secDesc = "the project sec description";
            DateTime secDate = DateTime.Now + new TimeSpan(7, 0, 0, 0);

            //Test Create
            Assert.IsTrue(ctrl.CreateProject(firstName, firstDesc, firstDate));
            Project project = ctrl.Projects.Last();

            Assert.AreEqual(firstName, project.Name);
            Assert.AreEqual(firstDesc, project.Description);
            Assert.AreEqual(firstDate.ToString(), project.Begin.ToString());

            //Test Update
            Assert.IsTrue(ctrl.UpdateProject(secName, secDesc, secDate, project));

            Assert.AreEqual(secName, project.Name);
            Assert.AreEqual(secDesc, project.Description);
            Assert.AreEqual(secDate.ToString(), project.Begin.ToString());

            //Test Remove
            Assert.IsTrue(ctrl.Delete(project));
        }
        [TestMethod]
        public void CRUDSprint()
        {
            DateTime firstBegin = DateTime.Now;
            DateTime firstEnd = firstBegin + new TimeSpan(7, 0, 0, 0);
            ctrl.CreateProject("aProjectName", "A Description for my project", DateTime.Now);
            Project project = ctrl.Projects.Last();
            DateTime secBegin = firstEnd;
            DateTime secEnd = secBegin + new TimeSpan(7, 0, 0, 0);

            //Test Create
            Assert.IsTrue(ctrl.CreateSprint(firstBegin, firstEnd, project));
            Sprint sprint = project.Sprints[0];

            Assert.AreEqual(firstBegin.ToString(), sprint.Begin.ToString());
            Assert.AreEqual(firstEnd.ToString(), sprint.End.ToString());

            //Test Update

            Assert.IsTrue(ctrl.UpdateSprint(secBegin, secEnd, sprint));

            Assert.AreEqual(secBegin.ToString(), sprint.Begin.ToString());
            Assert.AreEqual(secEnd.ToString(), sprint.End.ToString());

            //Test Remove
            Assert.IsTrue(ctrl.Delete(sprint));
        }
        [TestMethod]
        public void CRUDState()
        {
            //Test Create
            string firstName = "first state name";

            Assert.IsTrue(ctrl.CreateState(firstName));
            State state = ctrl.States.Last();

            Assert.AreEqual(firstName, state.Name);


            //Test Remove
            Assert.IsTrue(ctrl.Delete(state));
        }
        [TestMethod]
        public void CRUDUser()
        {
            //Test Create
            string firstName = "first user name";

            Assert.IsTrue(ctrl.CreateUser(firstName));
            User user = ctrl.Users.Last();

            Assert.AreEqual(firstName, user.Name);

            //Test Remove
            Assert.IsTrue(ctrl.Delete(user));
        }
        [TestMethod]
        public void CRUDUserStoryTest()
        {
            ctrl.CreateProject("aProjectName", "A Description for my project", DateTime.Now);
            Project project = ctrl.Projects.Last();

            string firstDesc = "aDesc";
            DateTime? firstDate = DateTime.Now;
            int firstComplexity = 2;
            Priority firstPrio = ctrl.Priorities[0];
            Classes.Type firstType = ctrl.Types[0];


            Assert.IsTrue(ctrl.CreateUserStory(firstDesc, firstDate, firstComplexity, firstPrio, firstType, project));
            UserStory userStory = project.AllUserStories[0];

            Assert.IsNotNull(userStory, "Exception in userStory creation");
            Assert.AreEqual(firstDesc, userStory.Description);
            Assert.AreEqual(firstDate, userStory.DateLimit);
            Assert.AreEqual(firstComplexity, userStory.ComplexityEstimation);
            Assert.AreEqual(firstPrio, userStory.Priority);
            Assert.AreEqual(firstType, userStory.Type);
            Assert.AreEqual(project, userStory.Project);
            Assert.AreEqual(false, userStory.Blocked);
            Assert.AreEqual(0, userStory.CompletedComplexity);


            string secDesc = "aNewDesc";
            DateTime? secDate = null;
            int secComplexity = 3;
            int secCompleted = 1;
            bool secBlock = true;
            Priority secPrio = ctrl.Priorities[1];
            Classes.Type secType = ctrl.Types[1];
            while (ctrl.States.Count < 2)
            {
                ctrl.CreateState("An additional state name");
            }
            State secState = ctrl.States.Last();

           Assert.IsTrue(ctrl.UpdateUserStory(secDesc, secDate, secComplexity, secCompleted, secBlock, secPrio, secType, secState, userStory));

            Assert.AreEqual(secDesc, userStory.Description);
            Assert.AreEqual(secDate, userStory.DateLimit);
            Assert.AreEqual(secComplexity, userStory.ComplexityEstimation);
            Assert.AreEqual(secPrio, userStory.Priority);
            Assert.AreEqual(secType, userStory.Type);
            Assert.AreEqual(secState, userStory.State);
            Assert.AreEqual(secBlock, userStory.Blocked);
            Assert.AreEqual(secCompleted, userStory.CompletedComplexity);

            Assert.IsTrue(ctrl.Delete(userStory));

            ctrl.Delete(project);
        }


    }
}