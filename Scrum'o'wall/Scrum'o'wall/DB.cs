/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   DB.cs
 * Desc.    :   This file is a singlotron's class to access to the database
 */
using Microsoft.Win32;
using Scrum_o_wall.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace Scrum_o_wall
{
    public static class DB
    {
        public static string DbFileName;
        private static OleDbConnection connection;
        private static OleDbConnection GetConnection()
        {
            if (connection is null && DbFileName == null)
            {
                OpenFileDialog opf = new OpenFileDialog
                {
                    Title = "Quel base de données Access utiliser ?",
                    DefaultExt = ".accdb|*.accdb",
                    Filter = "Fichier Acces (*.accdb)|*.accdb"
                };
                do
                {
                    if (opf.ShowDialog() != true)
                    {
                        Application.Current.Shutdown();
                    }
                } while (!opf.SafeFileName.Contains(".accdb"));
                connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + opf.FileName + ";Persist Security Info=False;");
            }
            else if (connection is null)
            {
                connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + DbFileName + ";Persist Security Info=False;");
            }

            return connection;
        }


        #region UPDATE
        public static void UpdateUserStory(string description, DateTime? selectedDate, int complexity, int completedComplexity, bool blocked, Priority priority, State state, Classes.Type type, UserStory userStory)
        {
            //Initialize variables
            OleDbCommand cmd;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "UPDATE TUserStories SET DescriptionUserStory = ?, DateLimite = ?, ComplexityEstimation = ?, CompletedComplexity = ?,Blocked = ?,IdPriority = ?, IdState = ?, IdType = ? WHERE IdUserStory = ?;";
            cmd.Parameters.Add("DescriptionUserStory", OleDbType.LongVarChar, 65535);
            cmd.Parameters.Add("DateLimite", OleDbType.Date);
            cmd.Parameters.Add("ComplexityEstimation", OleDbType.Integer);
            cmd.Parameters.Add("CompletedComplexity", OleDbType.Integer);
            cmd.Parameters.Add("Blocked", OleDbType.Boolean);
            cmd.Parameters.Add("IdPriority", OleDbType.Integer);
            cmd.Parameters.Add("IdState", OleDbType.Integer);
            cmd.Parameters.Add("IdType", OleDbType.Integer);
            cmd.Parameters.Add("IdUserStory", OleDbType.Integer);
            cmd.Parameters[0].Value = description;
            if (selectedDate == null)
            {
                cmd.Parameters[1].Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters[1].Value = selectedDate;
            }
            cmd.Parameters[2].Value = complexity;
            cmd.Parameters[3].Value = completedComplexity;
            cmd.Parameters[4].Value = blocked;
            cmd.Parameters[5].Value = priority.Id;
            cmd.Parameters[6].Value = state.Id;
            cmd.Parameters[7].Value = type.Id;
            cmd.Parameters[8].Value = userStory.Id;

            //Execute sql statement
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //Close database
            DB.GetConnection().Close();
        }
        public static void UpdateFile(string fileDescription, Classes.File file)
        {

            //Initialize variables
            OleDbCommand cmd;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "UPDATE TFiles SET DescriptionFile = ? WHERE IdFile = ?;";
            cmd.Parameters.Add("DescriptionFile", OleDbType.LongVarChar, 65535);
            cmd.Parameters.Add("IdFile", OleDbType.Integer);
            cmd.Parameters[0].Value = fileDescription;
            cmd.Parameters[1].Value = file.Id;

            //Execute sql statement
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //Close database
            DB.GetConnection().Close();
        }
        public static void UpdateCheckList(string name, Checklist checklist)
        {
            //Initialize variables
            OleDbCommand cmd;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "UPDATE TChecklists SET NameChecklist = ? WHERE IdChecklist = ?;";
            cmd.Parameters.Add("NameChecklist", OleDbType.VarChar, 255);
            cmd.Parameters.Add("IdChecklist", OleDbType.Integer);
            cmd.Parameters[0].Value = name;
            cmd.Parameters[1].Value = checklist.Id;

            //Execute sql statement
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //Close database
            DB.GetConnection().Close();
        }
        public static void UpdateCheckListItem(string nameItem, bool done, ChecklistItem checklistItem)
        {
            //Initialize variables
            OleDbCommand cmd;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "UPDATE TChecklistItems SET NameItem = ?, Done = ? WHERE IdChecklistItem = ?;";
            cmd.Parameters.Add("NameItem", OleDbType.VarChar, 255);
            cmd.Parameters.Add("Done", OleDbType.Boolean);
            cmd.Parameters.Add("IdChecklistItem", OleDbType.Integer);
            cmd.Parameters[0].Value = nameItem;
            cmd.Parameters[1].Value = done;
            cmd.Parameters[2].Value = checklistItem.Id;

            //Execute sql statement
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //Close database
            DB.GetConnection().Close();
        }
        public static void UpdateProject(string name, string description, DateTime dateTime, Project project)
        {
            //Initialize variables
            OleDbCommand cmd;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "UPDATE TProjects SET NameProject = ?,Description = ?, DateBegin = ? WHERE IdProject = ?;";
            cmd.Parameters.Add("NameProject", OleDbType.VarChar, 50);
            cmd.Parameters.Add("Description", OleDbType.LongVarChar, 65535);
            cmd.Parameters.Add("DateBegin", OleDbType.Date);
            cmd.Parameters.Add("IdProject", OleDbType.Integer);
            cmd.Parameters[0].Value = name;
            cmd.Parameters[1].Value = description;
            cmd.Parameters[2].Value = dateTime;
            cmd.Parameters[3].Value = project.Id;

            //Execute sql statement
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //Close database
            DB.GetConnection().Close();
        }
        public static void UpdateSprint(DateTime secBegin, DateTime secEnd, Sprint sprint)
        {
            //Initialize variables
            OleDbCommand cmd;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "UPDATE TSprints SET DateEnd = ?,DateBegin = ? WHERE IdSprint = ?;";
            cmd.Parameters.Add("DateEnd", OleDbType.Date);
            cmd.Parameters.Add("DateBegin", OleDbType.Date);
            cmd.Parameters.Add("IdProject", OleDbType.Integer);
            cmd.Parameters[0].Value = secEnd;
            cmd.Parameters[1].Value = secBegin;
            cmd.Parameters[2].Value = sprint.Id;

            //Execute sql statement
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //Close database
            DB.GetConnection().Close();
        }

        public static void UpdateUser(string text, User user)
        {
            //Initialize variables
            OleDbCommand cmd;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "UPDATE TUsers SET NameUser = ? WHERE IdUser = ?;";
            cmd.Parameters.Add("NameUser", OleDbType.Date);
            cmd.Parameters.Add("IdUser", OleDbType.Integer);
            cmd.Parameters[0].Value = text;
            cmd.Parameters[1].Value = user.Id;

            //Execute sql statement
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //Close database
            DB.GetConnection().Close();
        }

        public static void UpdateState(string text, State state)
        {
            //Initialize variables
            OleDbCommand cmd;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "UPDATE TStates SET NameState = ? WHERE IdState = ?;";
            cmd.Parameters.Add("NameState", OleDbType.Date);
            cmd.Parameters.Add("IdState", OleDbType.Integer);
            cmd.Parameters[0].Value = text;
            cmd.Parameters[1].Value = state.Id;

            //Execute sql statement
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //Close database
            DB.GetConnection().Close();
        }
        #endregion
        #region ADD
        public static Project CreateProject(string aName, string aDesc, DateTime aDate)
        {
            //Initialize variables
            OleDbCommand cmd;
            int id;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "INSERT INTO TProjects (NameProject,Description,DateBegin) VALUES (?,?,?);";
            cmd.Parameters.Add("NameProject", OleDbType.VarChar, 50);
            cmd.Parameters.Add("Description", OleDbType.LongVarChar, 65535);
            cmd.Parameters.Add("DateBegin", OleDbType.Date);
            cmd.Parameters[0].Value = aName;
            cmd.Parameters[1].Value = aDesc;
            cmd.Parameters[2].Value = aDate;

            //Execute sql statement
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //Get last inserted id
            cmd.CommandText = "SELECT @@Identity;";
            id = (int)cmd.ExecuteScalar();

            //Close database
            DB.GetConnection().Close();

            //return created project
            Project project = new Project(id, aName, aDesc, aDate);
            return project;
        }


        public static void AddUserToChecklistItem(User user, ChecklistItem checklistItem)
        {
            //Initialize variables
            OleDbCommand cmd;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "INSERT INTO TUserChecklistItem (IdUser,IdChecklistItem) VALUES (?,?);";
            cmd.Parameters.Add("IdUser", OleDbType.Integer);
            cmd.Parameters.Add("IdProject", OleDbType.Integer);
            cmd.Parameters[0].Value = user.Id;
            cmd.Parameters[1].Value = checklistItem.Id;

            //Execute sql statement
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //Close database
            DB.GetConnection().Close();
        }
        public static void AddUserToUserStory(User user, UserStory userStory)
        {
            //Initialize variables
            OleDbCommand cmd;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "INSERT INTO TUserUserStory(IdUser,IdUserStory) VALUES (?,?);";
            cmd.Parameters.Add("IdUser", OleDbType.Integer);
            cmd.Parameters.Add("IdProject", OleDbType.Integer);
            cmd.Parameters[0].Value = user.Id;
            cmd.Parameters[1].Value = userStory.Id;

            //Execute sql statement
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //Close database
            DB.GetConnection().Close();
        }
        public static void AddUserToProject(User user, Project project)
        {
            //Initialize variables
            OleDbCommand cmd;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "INSERT INTO TUserProject (IdUser,IdProject) VALUES (?,?);";
            cmd.Parameters.Add("IdUser", OleDbType.Integer);
            cmd.Parameters.Add("IdProject", OleDbType.Integer);
            cmd.Parameters[0].Value = user.Id;
            cmd.Parameters[1].Value = project.Id;

            //Execute sql statement
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //Close database
            DB.GetConnection().Close();
        }
        public static void AddUserStoryToSprint(UserStory userStory, Sprint sprint, int order)
        {
            //Initialize variables
            OleDbCommand cmd;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "INSERT INTO TUserStoriesSprint (IdUserStory , IdSprint , OrderUserStory) VALUES (? , ? , ?) ;";

            cmd.Parameters.Add("IdUserStory", OleDbType.Integer);
            cmd.Parameters.Add("IdSprint", OleDbType.Integer);
            cmd.Parameters.Add("OrderUserStory", OleDbType.Integer);

            cmd.Parameters[0].Value = userStory.Id;
            cmd.Parameters[1].Value = sprint.Id;
            cmd.Parameters[2].Value = order;

            //Execute sql statement
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //Close database
            DB.GetConnection().Close();
        }
        public static ChecklistItem CreateCheckListItem(string aName, Checklist checklist)
        {
            //Initialize variables
            OleDbCommand cmd;
            int id;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "INSERT INTO TChecklistItems (NameItem,Done,IdChecklist) VALUES (?,?,?);";
            cmd.Parameters.Add("NameItem", OleDbType.VarChar, 255);
            cmd.Parameters.Add("Done", OleDbType.Boolean);
            cmd.Parameters.Add("IdChecklist", OleDbType.Integer);
            cmd.Parameters[0].Value = aName;
            cmd.Parameters[1].Value = false;
            cmd.Parameters[2].Value = checklist.Id;

            //Execute sql statement
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //Get last inserted id
            cmd.CommandText = "SELECT @@Identity;";
            id = (int)cmd.ExecuteScalar();

            //Close database
            DB.GetConnection().Close();

            //return created project
            ChecklistItem checklistItem = new ChecklistItem(id, aName, false, checklist.Id);
            return checklistItem;
        }
        public static Checklist CreateCheckList(string aName, UserStory userStory)
        {
            //Initialize variables
            OleDbCommand cmd;
            int id;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "INSERT INTO TChecklists (NameChecklist,IdUserStory) VALUES (?,?);";
            cmd.Parameters.Add("NameChecklist", OleDbType.VarChar, 255);
            cmd.Parameters.Add("IdUserStory", OleDbType.Integer);
            cmd.Parameters[0].Value = aName;
            cmd.Parameters[1].Value = userStory.Id;

            //Execute sql statement
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //Get last inserted id
            cmd.CommandText = "SELECT @@Identity;";
            id = (int)cmd.ExecuteScalar();

            //Close database
            DB.GetConnection().Close();

            //return created project
            Checklist checklist = new Checklist(id, aName, userStory.Id);
            return checklist;
        }
        public static Activity CreateActivity(string description, DateTime now, UserStory userStory)
        {
            //Initialize variables
            OleDbCommand cmd;
            int id;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "INSERT INTO TActivities (Description,DateTimeActivity,IdUserStory) VALUES (?,?,?);";
            cmd.Parameters.Add("Description", OleDbType.LongVarChar, 65535);
            cmd.Parameters.Add("DateTimeActivity", OleDbType.Date);
            cmd.Parameters.Add("IdUserStory", OleDbType.Integer);
            cmd.Parameters[0].Value = description;
            cmd.Parameters[1].Value = now;
            cmd.Parameters[2].Value = userStory.Id;

            //Execute sql statement
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //Get last inserted id
            cmd.CommandText = "SELECT @@Identity;";
            id = (int)cmd.ExecuteScalar();

            //Close database
            DB.GetConnection().Close();

            //return created project
            Activity activity = new Activity(id, description, now, userStory.Id);
            return activity;
        }
        public static UserStory CreateUserStory(string description, DateTime? selectedDate, int complexity, Priority priority, Classes.Type type, State state, Project project)
        {
            //Initialize variables
            OleDbCommand cmd;
            int id;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "INSERT INTO TUserStories (DescriptionUserStory,DateLimite,ComplexityEstimation,CompletedComplexity,Blocked,IdProject,IdState,IdType,IdPriority) VALUES (?,?,?,?,?,?,?,?,?);";
            cmd.Parameters.Add("DescriptionUserStory", OleDbType.LongVarChar, 65535);
            cmd.Parameters.Add("DateLimite", OleDbType.Date);
            cmd.Parameters.Add("ComplexityEstimation", OleDbType.Integer);
            cmd.Parameters.Add("CompletedComplexity", OleDbType.Integer);
            cmd.Parameters.Add("Blocked", OleDbType.Boolean);
            cmd.Parameters.Add("IdProject", OleDbType.Integer);
            cmd.Parameters.Add("IdState", OleDbType.Integer);
            cmd.Parameters.Add("IdType", OleDbType.Integer);
            cmd.Parameters.Add("IdPriority", OleDbType.Integer);
            cmd.Parameters[0].Value = description;
            if (selectedDate == null)
            {
                cmd.Parameters[1].Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters[1].Value = selectedDate;
            }
            cmd.Parameters[2].Value = complexity;
            cmd.Parameters[3].Value = 0;
            cmd.Parameters[4].Value = false;
            cmd.Parameters[5].Value = project.Id;
            cmd.Parameters[6].Value = state.Id;
            cmd.Parameters[7].Value = type.Id;
            cmd.Parameters[8].Value = priority.Id;

            //Execute sql statement
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //Get last inserted id
            cmd.CommandText = "SELECT @@Identity;";
            id = (int)cmd.ExecuteScalar();

            //Close database
            DB.GetConnection().Close();

            //return created project
            UserStory userStory = new UserStory(id, description, selectedDate, complexity, 0, false, project.Id, state.Id, type.Id, priority.Id);
            return userStory;
        }
        public static State CreateState(string name)
        {
            //Initialize variables
            OleDbCommand cmd;
            int id;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "INSERT INTO TStates (NameState) VALUES (?);";
            cmd.Parameters.Add("NameState", OleDbType.VarChar, 30);
            cmd.Parameters[0].Value = name;

            //Execute sql statement
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //Get last inserted id
            cmd.CommandText = "SELECT @@Identity;";
            id = (int)cmd.ExecuteScalar();

            //Close database
            DB.GetConnection().Close();

            //return created project
            State state = new State(id, name);
            return state;
        }
        public static Classes.File CreateFile(string fileName, string description,  UserStory userStory)
        {
            //Initialize variables
            OleDbCommand cmd;
            int id;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "INSERT INTO TFiles (NameFile,DescriptionFile,IdUserStory) VALUES (?,?,?);";
            cmd.Parameters.Add("NameState", OleDbType.LongVarChar, 65535);
            cmd.Parameters.Add("DescriptionFile", OleDbType.LongVarChar, 65535);
            cmd.Parameters.Add("IdUserStory", OleDbType.Integer);
            cmd.Parameters[0].Value = fileName;
            cmd.Parameters[1].Value = description;
            cmd.Parameters[2].Value = userStory.Id;

            //Execute sql statement
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //Get last inserted id
            cmd.CommandText = "SELECT @@Identity;";
            id = (int)cmd.ExecuteScalar();

            //Close database
            DB.GetConnection().Close();

            //return created project
            Classes.File file = new Classes.File(id, fileName, description, userStory.Id);
            return file;
        }
        public static User CreateUser(string name)
        {
            //Initialize variables
            OleDbCommand cmd;
            int id;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "INSERT INTO TUsers (NameUser) VALUES (?);";
            cmd.Parameters.Add("NameUser", OleDbType.VarChar, 255);
            cmd.Parameters[0].Value = name;

            //Execute sql statement
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //Get last inserted id
            cmd.CommandText = "SELECT @@Identity;";
            id = (int)cmd.ExecuteScalar();

            //Close database
            DB.GetConnection().Close();

            //return created project
            User user = new User(id, name);
            return user;
        }
        public static Comment CreateComment(string name, UserStory userStory, User user)
        {
            //Initialize variables
            OleDbCommand cmd;
            int id;
            DateTime dateTime = DateTime.Now;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "INSERT INTO TComments (DescriptionComment,CreationDateTime,IdUserStory,IdUser) VALUES (?,?,?,?);";
            cmd.Parameters.Add("DescriptionComment", OleDbType.LongVarChar, 65535);
            cmd.Parameters.Add("DateTime", OleDbType.Date);
            cmd.Parameters.Add("IdUserStory", OleDbType.Integer);
            cmd.Parameters.Add("IdUser", OleDbType.Integer);
            cmd.Parameters[0].Value = name;
            cmd.Parameters[1].Value = dateTime;
            cmd.Parameters[2].Value = userStory.Id;
            cmd.Parameters[3].Value = user.Id;

            //Execute sql statement
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //Get last inserted id
            cmd.CommandText = "SELECT @@Identity;";
            id = (int)cmd.ExecuteScalar();

            //Close database
            DB.GetConnection().Close();

            Comment comment = new Comment(id, name, dateTime, userStory.Id, user.Id);
            return comment;
        }
        public static Sprint CreateSprint(DateTime dateBegin, DateTime dateEnd, Project project)
        {
            //Initialize variables
            OleDbCommand cmd;
            int id;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "INSERT INTO TSprints (DateBegin,DateEnd,IdProject) VALUES (?,?,?);";
            cmd.Parameters.Add("DateBegin", OleDbType.Date);
            cmd.Parameters.Add("DateEnd", OleDbType.Date);
            cmd.Parameters.Add("IdProject", OleDbType.Integer);
            cmd.Parameters[0].Value = dateBegin;
            cmd.Parameters[1].Value = dateEnd;
            cmd.Parameters[2].Value = project.Id;

            //Execute sql statement
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //Get last inserted id
            cmd.CommandText = "SELECT @@Identity;";
            id = (int)cmd.ExecuteScalar();

            //Close database
            DB.GetConnection().Close();

            Sprint sprint = new Sprint(id, dateBegin, dateEnd, project.Id);
            return sprint;

        }
        public static void AddStateToProject(State state, Project project, int order)
        {
            //Initialize variables
            OleDbCommand cmd;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "INSERT INTO TProjectStates (IdProject,IdState,orderState) VALUES (?,?,?) ;";
            cmd.Parameters.Add("IdProject", OleDbType.Integer);
            cmd.Parameters.Add("IdState", OleDbType.Integer);
            cmd.Parameters.Add("orderState", OleDbType.Integer);
            cmd.Parameters[0].Value = project.Id;
            cmd.Parameters[1].Value = state.Id;
            cmd.Parameters[2].Value = order;

            //Execute sql statement
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //Close database
            DB.GetConnection().Close();
        }
        #endregion
        #region REMOVE

        public static bool DeleteActivity(Activity activity)
        {
            //Initialize variables
            OleDbCommand cmd;
            bool result;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "UPDATE TActivities SET deletedFlag = ? WHERE IdActivity = ?;";
            cmd.Parameters.Add("deletedFlag", OleDbType.Boolean);
            cmd.Parameters.Add("IdActivity", OleDbType.Integer);
            cmd.Parameters[0].Value = true;
            cmd.Parameters[1].Value = activity.Id;

            //Execute sql statement
            cmd.Prepare();
            result = cmd.ExecuteNonQuery() == 1;

            //Close database
            DB.GetConnection().Close();
            return result;
        }
        public static bool DeleteChecklistItem(ChecklistItem checklistItem)
        {
            //Initialize variables
            OleDbCommand cmd;
            bool result;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "UPDATE TChecklistItems SET deletedFlag = ? WHERE IdChecklistItem = ?;";
            cmd.Parameters.Add("deletedFlag", OleDbType.Boolean);
            cmd.Parameters.Add("IdChecklistItem", OleDbType.Integer);
            cmd.Parameters[0].Value = true;
            cmd.Parameters[1].Value = checklistItem.Id;

            //Execute sql statement
            cmd.Prepare();
            result = cmd.ExecuteNonQuery() == 1;

            //Close database
            DB.GetConnection().Close();
            return result;
        }
        public static bool DeleteChecklist(Checklist checklist)
        {
            //Initialize variables
            OleDbCommand cmd;
            bool result;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "UPDATE TChecklists SET deletedFlag = ? WHERE IdChecklist = ?;";
            cmd.Parameters.Add("deletedFlag", OleDbType.Boolean);
            cmd.Parameters.Add("IdChecklist", OleDbType.Integer);
            cmd.Parameters[0].Value = true;
            cmd.Parameters[1].Value = checklist.Id;

            //Execute sql statement
            cmd.Prepare();
            result = cmd.ExecuteNonQuery() == 1;

            //Close database
            DB.GetConnection().Close();
            return result;
        }
        public static bool DeleteComment(Comment comment)
        {
            //Initialize variables
            OleDbCommand cmd;
            bool result;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "UPDATE TComments SET deletedFlag = ? WHERE IdComment = ?;";
            cmd.Parameters.Add("deletedFlag", OleDbType.Boolean);
            cmd.Parameters.Add("IdComment", OleDbType.Integer);
            cmd.Parameters[0].Value = true;
            cmd.Parameters[1].Value = comment.Id;

            //Execute sql statement
            cmd.Prepare();
            result = cmd.ExecuteNonQuery() == 1;

            //Close database
            DB.GetConnection().Close();
            return result;
        }
        public static bool DeleteFile(Classes.File File)
        {
            //Initialize variables
            OleDbCommand cmd;
            bool result;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "UPDATE TFiles SET deletedFlag = ? WHERE IdFile = ?;";
            cmd.Parameters.Add("deletedFlag", OleDbType.Boolean);
            cmd.Parameters.Add("IdFile", OleDbType.Integer);
            cmd.Parameters[0].Value = true;
            cmd.Parameters[1].Value = File.Id;

            //Execute sql statement
            cmd.Prepare();
            result = cmd.ExecuteNonQuery() == 1;

            //Close database
            DB.GetConnection().Close();
            return result;
        }
        public static bool DeleteMindmap(MindMap mindmap)
        {
            //Initialize variables
            OleDbCommand cmd;
            bool result;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "UPDATE TMindMaps SET deletedFlag = ? WHERE IdMindMap = ?;";
            cmd.Parameters.Add("deletedFlag", OleDbType.Boolean);
            cmd.Parameters.Add("IdMindMap", OleDbType.Integer);
            cmd.Parameters[0].Value = true;
            cmd.Parameters[1].Value = mindmap.Id;

            //Execute sql statement
            cmd.Prepare();
            result = cmd.ExecuteNonQuery() == 1;

            //Close database
            DB.GetConnection().Close();
            return result;
        }
        public static bool DeleteNode(Node node)
        {
            //Initialize variables
            OleDbCommand cmd;
            bool result;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "UPDATE TNodes SET deletedFlag = ? WHERE IdNode = ?;";
            cmd.Parameters.Add("deletedFlag", OleDbType.Boolean);
            cmd.Parameters.Add("IdNode", OleDbType.Integer);
            cmd.Parameters[0].Value = true;
            cmd.Parameters[1].Value = node.Id;

            //Execute sql statement
            cmd.Prepare();
            result = cmd.ExecuteNonQuery() == 1;

            //Close database
            DB.GetConnection().Close();
            return result;
        }
        public static bool DeleteProject(Project project)
        {
            //Initialize variables
            OleDbCommand cmd;
            bool result;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "UPDATE TProjects SET deletedFlag = ? WHERE IdProject = ?;";
            cmd.Parameters.Add("deletedFlag", OleDbType.Boolean);
            cmd.Parameters.Add("IdProject", OleDbType.Integer);
            cmd.Parameters[0].Value = true;
            cmd.Parameters[1].Value = project.Id;

            //Execute sql statement
            cmd.Prepare();
            result = cmd.ExecuteNonQuery() == 1;

            //Close database
            DB.GetConnection().Close();
            return result;
        }
        public static bool DeleteSprint(Sprint sprint)
        {
            //Initialize variables
            OleDbCommand cmd;
            bool result;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "UPDATE TSprints SET deletedFlag = ? WHERE IdSprint = ?;";
            cmd.Parameters.Add("deletedFlag", OleDbType.Boolean);
            cmd.Parameters.Add("IdSprint", OleDbType.Integer);
            cmd.Parameters[0].Value = true;
            cmd.Parameters[1].Value = sprint.Id;

            //Execute sql statement
            cmd.Prepare();
            result = cmd.ExecuteNonQuery() == 1;

            //Close database
            DB.GetConnection().Close();
            return result;
        }
        public static bool DeleteState(State state)
        {
            //Initialize variables
            OleDbCommand cmd;
            bool result;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "UPDATE TStates SET deletedFlag = ? WHERE IdState = ?;";
            cmd.Parameters.Add("deletedFlag", OleDbType.Boolean);
            cmd.Parameters.Add("IdState", OleDbType.Integer);
            cmd.Parameters[0].Value = true;
            cmd.Parameters[1].Value = state.Id;

            //Execute sql statement
            cmd.Prepare();
            result = cmd.ExecuteNonQuery() == 1;

            //Close database
            DB.GetConnection().Close();
            return result;
        }
        public static bool DeleteUser(User user)
        {
            //Initialize variables
            OleDbCommand cmd;
            bool result;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "UPDATE TUsers SET deletedFlag = ? WHERE IdUser = ?;";
            cmd.Parameters.Add("deletedFlag", OleDbType.Boolean);
            cmd.Parameters.Add("IdUserStory", OleDbType.Integer);
            cmd.Parameters[0].Value = true;
            cmd.Parameters[1].Value = user.Id;

            //Execute sql statement
            cmd.Prepare();
            result = cmd.ExecuteNonQuery() == 1;

            //Close database
            DB.GetConnection().Close();
            return result;
        }
        public static bool DeleteUserStory(UserStory userStory)
        {
            //Initialize variables
            OleDbCommand cmd;
            bool result;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "UPDATE TUserStories SET deletedFlag = ? WHERE IdUserStory = ?;";
            cmd.Parameters.Add("deletedFlag", OleDbType.Boolean);
            cmd.Parameters.Add("IdUserStory", OleDbType.Integer);
            cmd.Parameters[0].Value = true;
            cmd.Parameters[1].Value = userStory.Id;

            //Execute sql statement
            cmd.Prepare();
            result = cmd.ExecuteNonQuery() == 1;

            //Close database
            DB.GetConnection().Close();
            return result;
        }
        public static void RemoveUserFromUserStory(User user, UserStory userStory)
        {
            //Initialize variables
            OleDbCommand cmd;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "DELETE FROM TUserUserStory WHERE IdUser = ? AND IdUserStory = ?;";
            cmd.Parameters.Add("IdUser", OleDbType.Integer);
            cmd.Parameters.Add("IdUserStory", OleDbType.Integer);
            cmd.Parameters[0].Value = user.Id;
            cmd.Parameters[1].Value = userStory.Id;

            //Execute sql statement
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //Close database
            DB.GetConnection().Close();
        }
        public static void RemoveUserFromProject(User user, Project project)
        {
            //Initialize variables
            OleDbCommand cmd;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "DELETE FROM TUserProject WHERE IdUser = ? AND IdProject = ?;";
            cmd.Parameters.Add("IdUser", OleDbType.Integer);
            cmd.Parameters.Add("IdProject", OleDbType.Integer);
            cmd.Parameters[0].Value = user.Id;
            cmd.Parameters[1].Value = project.Id;

            //Execute sql statement
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //Close database
            DB.GetConnection().Close();
        }
        public static void RemoveUserFromChecklistItem(User user, ChecklistItem checklistItem)
        {
            //Initialize variables
            OleDbCommand cmd;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "DELETE FROM TUserChecklistItem WHERE IdUser = ? AND IdChecklistItem = ?;";
            cmd.Parameters.Add("IdUser", OleDbType.Integer);
            cmd.Parameters.Add("IdChecklistItem", OleDbType.Integer);
            cmd.Parameters[0].Value = user.Id;
            cmd.Parameters[1].Value = checklistItem.Id;

            //Execute sql statement
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //Close database
            DB.GetConnection().Close();
        }
        public static void RemoveUserStoryFromSprint(UserStory userStory, Sprint sprint, int order)
        {
            //Initialize variables
            OleDbCommand cmd;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "DELETE FROM TUserStoriesSprint WHERE IdUserStory = ? AND IdSprint = ? AND OrderUserStory = ? ;";

            cmd.Parameters.Add("IdUserStory", OleDbType.Integer);
            cmd.Parameters.Add("IdSprint", OleDbType.Integer);
            cmd.Parameters.Add("OrderUserStory", OleDbType.Integer);

            cmd.Parameters[0].Value = userStory.Id;
            cmd.Parameters[1].Value = sprint.Id;
            cmd.Parameters[2].Value = order;

            //Execute sql statement
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //Close database
            DB.GetConnection().Close();
        }
        public static void RemoveStateFromProject(Project project, int order)
        {
            //Initialize variables
            OleDbCommand cmd;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "DELETE FROM TProjectStates WHERE IdProject = ? AND orderState = ?;";
            cmd.Parameters.Add("IdProject", OleDbType.Integer);
            cmd.Parameters.Add("orderState", OleDbType.Integer);
            cmd.Parameters[0].Value = project.Id;
            cmd.Parameters[1].Value = order;

            //Execute sql statement
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //Close database
            DB.GetConnection().Close();
        }
        #endregion
        #region GET
        public static List<int[]> GetUserStoriesSprint()
        {
            //Declare variables
            OleDbCommand cmd;
            OleDbDataReader rdr;
            object[] values;
            List<int[]> valuesPair = new List<int[]>();

            //Open Database
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();

            //Execute SQL Command
            cmd.CommandText = "SELECT * FROM TUserStoriesSprint;";

            //Read and assign states with project
            rdr = cmd.ExecuteReader();
            values = new object[3];
            while (rdr.Read())
            {
                rdr.GetValues(values);
                // 0:IdUserStory,1:IdSprint,2:Order
                valuesPair.Add(new int[] { (int)values[0], (int)values[1], (int)values[2] });
            }

            //Close database and reader
            rdr.Close();
            DB.GetConnection().Close();

            return valuesPair;
        }
        public static List<int[]> GetProjectStates()
        {
            //Declare variables
            OleDbCommand cmd;
            OleDbDataReader rdr;
            object[] values;
            List<int[]> valuesPair = new List<int[]>();

            //Open Database
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();

            //Execute SQL Command
            cmd.CommandText = "SELECT * FROM TProjectStates;";

            //Read and assign states with project
            rdr = cmd.ExecuteReader();
            values = new object[3];
            while (rdr.Read())
            {
                rdr.GetValues(values);
                // 0:IdProject,1:IdState,2:order
                valuesPair.Add(new int[] { (int)values[0], (int)values[1], (int)values[2] });
            }

            //Close database and reader
            rdr.Close();
            DB.GetConnection().Close();

            return valuesPair;
        }
        public static List<int[]> GetUserProject()
        {
            //Declare variables
            OleDbCommand cmd;
            OleDbDataReader rdr;
            object[] values;
            List<int[]> valuesPair = new List<int[]>();

            //Open Database
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();

            //Execute SQL Command
            cmd.CommandText = "SELECT * FROM TUserProject;";

            //Read and assign states with project
            rdr = cmd.ExecuteReader();
            values = new object[2];
            while (rdr.Read())
            {
                rdr.GetValues(values);
                // 0:IdUser,1:IdProject
                valuesPair.Add(new int[] { (int)values[0], (int)values[1] });
            }

            //Close database and reader
            rdr.Close();
            DB.GetConnection().Close();

            return valuesPair;
        }
        public static List<int[]> GetUserChecklistItem()
        {
            //Declare variables
            OleDbCommand cmd;
            OleDbDataReader rdr;
            object[] values;
            List<int[]> valuesPair = new List<int[]>();

            //Open Database
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();

            //Execute SQL Command
            cmd.CommandText = "SELECT * FROM TUserChecklistItem;";

            //Read and assign states with project
            rdr = cmd.ExecuteReader();
            values = new object[2];
            while (rdr.Read())
            {
                rdr.GetValues(values);
                // 0:IdUser,1:IdChecklistItem
                valuesPair.Add(new int[] { (int)values[0], (int)values[1] });
            }

            //Close database and reader
            rdr.Close();
            DB.GetConnection().Close();

            return valuesPair;
        }
        public static List<int[]> GetUserUserStory()
        {
            //Declare variables
            OleDbCommand cmd;
            OleDbDataReader rdr;
            object[] values;
            List<int[]> valuesPair = new List<int[]>();

            //Open Database
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();

            //Execute SQL Command
            cmd.CommandText = "SELECT * FROM TUserUserStory;";

            //Read and assign states with project
            rdr = cmd.ExecuteReader();
            values = new object[2];
            while (rdr.Read())
            {
                rdr.GetValues(values);
                // 0:IdUser,1:IdUserStory
                valuesPair.Add(new int[] { (int)values[0], (int)values[1] });
            }

            //Close database and reader
            rdr.Close();
            DB.GetConnection().Close();

            return valuesPair;
        }
        public static List<Project> GetProjects()
        {
            //Declare variables
            OleDbCommand cmd;
            OleDbDataReader rdr;
            object[] values;
            List<Project> projects = new List<Project>();

            //Open Database
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();

            //Execute SQL Command
            cmd.CommandText = "SELECT * FROM TProjects WHERE deletedFlag = FALSE;";
            cmd.Connection = DB.GetConnection();

            //Read and put projects in a list
            rdr = cmd.ExecuteReader();
            values = new object[4];
            while (rdr.Read())
            {
                rdr.GetValues(values);
                //0:IdProject,1:NameProject,2:Description,3:DateBegin
                Project p = new Project((int)values[0], (string)values[1], (string)values[2], (DateTime)values[3]);
                projects.Add(p);
            }

            //Close database and reader
            rdr.Close();
            GetConnection().Close();

            return projects;
        }
        public static List<Sprint> GetSprints()
        {
            //Declare variables
            OleDbCommand cmd;
            OleDbDataReader rdr;
            object[] values;
            List<Sprint> sprints = new List<Sprint>();

            //Open Database
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();

            //Execute SQL Command
            cmd.CommandText = "SELECT * FROM TSprints WHERE deletedFlag = FALSE;";
            cmd.Connection = DB.GetConnection();

            //Read and put entries in a list of objects
            rdr = cmd.ExecuteReader();
            values = new object[4];
            while (rdr.Read())
            {
                rdr.GetValues(values);
                // 0:idSprint,1:DateBegin,2:DateEnd
                Sprint s = new Sprint((int)values[0], (DateTime)values[1], (DateTime)values[2], (int)values[3]);
                sprints.Add(s);
            }

            //Close database and reader
            rdr.Close();
            GetConnection().Close();

            return sprints;
        }
        public static List<UserStory> GetUserStories()
        {
            //Declare variables
            OleDbCommand cmd;
            OleDbDataReader rdr;
            object[] values;
            List<UserStory> userStories = new List<UserStory>();

            //Open Database
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();

            //Execute SQL Command
            cmd.CommandText = "SELECT * FROM TUserStories WHERE deletedFlag = FALSE;";
            cmd.Connection = DB.GetConnection();

            //Read and put entries in a list of objects
            rdr = cmd.ExecuteReader();
            values = new object[10];
            while (rdr.Read())
            {
                rdr.GetValues(values);
                // 0:idUserStory,1:DescriptionUserStory,2:DateLimite,3:ComplexityEstimation,4:CompletedComplexity,5:Blocked,6:ProjectId,7:StateId,8:TypeId,9:PriorityId
                UserStory u = new UserStory((int)values[0], (string)values[1], values[2] as DateTime?, (int)values[3], (int)values[4], (bool)values[5], (int)values[6], (int)values[7], (int)values[8], (int)values[9]);
                userStories.Add(u);
            }

            //Close database and reader
            rdr.Close();
            GetConnection().Close();

            return userStories;
        }
        public static List<User> GetUsers()
        {
            //Declare variables
            OleDbCommand cmd;
            OleDbDataReader rdr;
            object[] values;
            List<User> users = new List<User>();

            //Open Database
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();

            //Execute SQL Command
            cmd.CommandText = "SELECT * FROM TUsers WHERE deletedFlag = FALSE;";
            cmd.Connection = DB.GetConnection();

            //Read and put entries in a list of objects
            rdr = cmd.ExecuteReader();
            values = new object[2];
            while (rdr.Read())
            {
                rdr.GetValues(values);
                // 0:idUser,1:NameUser
                User u = new User((int)values[0], (string)values[1]);
                users.Add(u);
            }

            //Close database and reader
            rdr.Close();
            GetConnection().Close();

            return users;
        }
        public static List<Classes.Type> GetTypes()
        {
            //Declare variables
            OleDbCommand cmd;
            OleDbDataReader rdr;
            object[] values;
            List<Classes.Type> types = new List<Classes.Type>();

            //Open Database
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();

            //Execute SQL Command
            cmd.CommandText = "SELECT * FROM TTypes WHERE deletedFlag = FALSE;";
            cmd.Connection = DB.GetConnection();

            //Read and put entries in a list of objects
            rdr = cmd.ExecuteReader();
            values = new object[2];
            while (rdr.Read())
            {
                rdr.GetValues(values);
                // 0:idType,1:NameType
                Classes.Type t = new Classes.Type((int)values[0], (string)values[1]);
                types.Add(t);
            }

            //Close database and reader
            rdr.Close();
            GetConnection().Close();

            return types;
        }
        public static List<Priority> GetPriorities()
        {
            //Declare variables
            OleDbCommand cmd;
            OleDbDataReader rdr;
            object[] values;
            List<Priority> priorities = new List<Priority>();

            //Open Database
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();

            //Execute SQL Command
            cmd.CommandText = "SELECT * FROM TPriorities WHERE deletedFlag = FALSE;";
            cmd.Connection = DB.GetConnection();

            //Read and put entries in a list of objects
            rdr = cmd.ExecuteReader();
            values = new object[2];
            while (rdr.Read())
            {
                rdr.GetValues(values);
                // 0:idPriority,1:NamePriority
                Priority u = new Priority((int)values[0], (string)values[1]);
                priorities.Add(u);
            }

            //Close database and reader
            rdr.Close();
            GetConnection().Close();

            return priorities;
        }
        public static List<Classes.File> GetFiles()
        {
            //Declare variables
            OleDbCommand cmd;
            OleDbDataReader rdr;
            object[] values;
            List<Classes.File> files = new List<Classes.File>();

            //Open Database
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();

            //Execute SQL Command
            cmd.CommandText = "SELECT * FROM TFiles WHERE deletedFlag = FALSE;";
            cmd.Connection = DB.GetConnection();

            //Read and put entries in a list of objects
            rdr = cmd.ExecuteReader();
            values = new object[4];
            while (rdr.Read())
            {
                rdr.GetValues(values);
                // 0:idFile,1:nameFile,2:DescFile,3:idUserStory
                Classes.File f = new Classes.File((int)values[0], (string)values[1], (string)values[2], (int)values[3]);
                files.Add(f);
            }

            //Close database and reader
            rdr.Close();
            GetConnection().Close();

            return files;
        }
        public static List<Activity> GetActivities()
        {
            //Declare variables
            OleDbCommand cmd;
            OleDbDataReader rdr;
            object[] values;
            List<Activity> activities = new List<Activity>();

            //Open Database
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();

            //Execute SQL Command
            cmd.CommandText = "SELECT * FROM TActivities WHERE deletedFlag = FALSE;";
            cmd.Connection = DB.GetConnection();

            //Read and put entries in a list of objects
            rdr = cmd.ExecuteReader();
            values = new object[4];
            while (rdr.Read())
            {
                rdr.GetValues(values);
                // 0:idFileType,1:description,2:DateTimeActivity,3:IdUserStory
                Activity a = new Activity((int)values[0], (string)values[1], (DateTime)values[2], (int)values[3]);
                activities.Add(a);
            }

            //Close database and reader
            rdr.Close();
            GetConnection().Close();

            return activities;
        }
        public static List<Checklist> GetChecklists()
        {
            //Declare variables
            OleDbCommand cmd;
            OleDbDataReader rdr;
            object[] values;
            List<Checklist> checklists = new List<Checklist>();

            //Open Database
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();

            //Execute SQL Command
            cmd.CommandText = "SELECT * FROM TChecklists WHERE deletedFlag = FALSE;";
            cmd.Connection = DB.GetConnection();

            //Read and put entries in a list of objects
            rdr = cmd.ExecuteReader();
            values = new object[3];
            while (rdr.Read())
            {
                rdr.GetValues(values);
                // 0:idChecklist,1:description,2:IdUserStory
                Checklist c = new Checklist((int)values[0], (string)values[1], (int)values[2]);
                checklists.Add(c);
            }

            //Close database and reader
            rdr.Close();
            GetConnection().Close();

            return checklists;
        }
        public static List<ChecklistItem> GetChecklistItems()
        {
            //Declare variables
            OleDbCommand cmd;
            OleDbDataReader rdr;
            object[] values;
            List<ChecklistItem> checklistItems = new List<ChecklistItem>();

            //Open Database
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();

            //Execute SQL Command
            cmd.CommandText = "SELECT * FROM TChecklistItems WHERE deletedFlag = FALSE;";
            cmd.Connection = DB.GetConnection();

            //Read and put entries in a list of objects
            rdr = cmd.ExecuteReader();
            values = new object[4];
            while (rdr.Read())
            {
                rdr.GetValues(values);
                // 0:idChecklistItem,1:nameItem,2:done,3:idChecklist
                ChecklistItem c = new ChecklistItem((int)values[0], (string)values[1], (bool)values[2], (int)values[3]);
                checklistItems.Add(c);
            }

            //Close database and reader
            rdr.Close();
            GetConnection().Close();

            return checklistItems;
        }
        public static List<Comment> GetComments()
        {
            //Declare variables
            OleDbCommand cmd;
            OleDbDataReader rdr;
            object[] values;
            List<Comment> comments = new List<Comment>();

            //Open Database
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();

            //Execute SQL Command
            cmd.CommandText = "SELECT * FROM TComments WHERE deletedFlag = FALSE;";
            cmd.Connection = DB.GetConnection();

            //Read and put entries in a list of objects
            rdr = cmd.ExecuteReader();
            values = new object[5];
            while (rdr.Read())
            {
                rdr.GetValues(values);
                // 0:idComment,1:desc,2:dateTime,3:idUserStory,4:idUser
                Comment c = new Comment((int)values[0], (string)values[1], (DateTime)values[2], (int)values[3], (int)values[4]);
                comments.Add(c);
            }

            //Close database and reader
            rdr.Close();
            GetConnection().Close();

            return comments;
        }
        public static List<State> GetStates()
        {
            //Declare variables
            OleDbCommand cmd;
            OleDbDataReader rdr;
            object[] values;
            List<State> states = new List<State>();

            //Open Database
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();

            //Execute SQL Command
            cmd.CommandText = "SELECT * FROM TStates WHERE deletedFlag = FALSE;";
            cmd.Connection = DB.GetConnection();

            //Read and put entries in a list of objects
            rdr = cmd.ExecuteReader();
            values = new object[2];
            while (rdr.Read())
            {
                rdr.GetValues(values);
                // 0:IdState,1:NameState
                states.Add(new State((int)values[0], (string)values[1]));
            }

            //Close database and reader
            rdr.Close();
            GetConnection().Close();

            return states;

        }
        #endregion

    }
}
