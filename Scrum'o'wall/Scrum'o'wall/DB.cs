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
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Scrum_o_wall
{
    public static class DB
    {
        private static OleDbConnection connection;
        private static OleDbConnection GetConnection()
        {
            if(connection is null)
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.Title = "Quel base de données Access utiliser ?";
                opf.DefaultExt = ".accdb|*.accdb";
                opf.Filter = "Fichier Acces (*.accdb)|*.accdb";
                do
                {
                    if(opf.ShowDialog() != true)
                    {
                        Application.Current.Shutdown();
                    }
                }while  (!opf.SafeFileName.Contains(".accdb"));
                connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + opf.FileName+ ";Persist Security Info=False;");
            }
            return connection;
        }

        public static Project CreateProject(string aName, string aDesc, DateTime aDate)
        {
            //Initialize variables
            OleDbCommand cmd;
            int id;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "INSERT INTO TProjects (NameProject,Description,DateBegin) VALUES (?,?,?);";
            cmd.Parameters.Add("NameProject", OleDbType.VarChar, 25);
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
            Project p = new Project(id, aName, aDesc, aDate);
            return p;
        }
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
                valuesPair.Add(new int[] { (int)values[0], (int)values[1],(int)values[2] });
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

        internal static State CreateState(string name)
        {
            throw new NotImplementedException();
        }

        internal static Classes.File CreateFile(string fileName, string description, int idFileType, int idUserStory)
        {
            throw new NotImplementedException();
        }

        internal static User CreateUser(string text)
        {
            throw new NotImplementedException();
        }

        internal static Comment CreateComment(string text, int id)
        {
            throw new NotImplementedException();
        }

        internal static ChecklistItem CreateCheckListItem(string aName, int id)
        {
            throw new NotImplementedException();
        }

        internal static Checklist CreateCheckList(string aName)
        {
            throw new NotImplementedException();
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
            cmd.CommandText = "SELECT * FROM TProjects;";
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
            cmd.CommandText = "SELECT * FROM TSprints;";
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
            cmd.CommandText = "SELECT * FROM TUserStories;";
            cmd.Connection = DB.GetConnection();

            //Read and put entries in a list of objects
            rdr = cmd.ExecuteReader();
            values = new object[10];
            while (rdr.Read())
            {
                rdr.GetValues(values);
                // 0:idUserStory,1:DescriptionUserStory,2:DateLimite,3:ComplexityEstimation,4:CompletedComplexity,5:Blocked,6:ProjectId,7:StateId,8:TypeId,9:PriorityId
                UserStory u = new UserStory((int)values[0], (string)values[1],values[2] as DateTime?, (int)values[3], (int)values[4], (bool)values[5], (int)values[6], (int)values[7], (int)values[8], (int)values[9]);
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
            cmd.CommandText = "SELECT * FROM TUsers;";
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
            cmd.CommandText = "SELECT * FROM TTypes;";
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
            cmd.CommandText = "SELECT * FROM TPriorities;";
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
            cmd.CommandText = "SELECT * FROM TFiles;";
            cmd.Connection = DB.GetConnection();

            //Read and put entries in a list of objects
            rdr = cmd.ExecuteReader();
            values = new object[5];
            while (rdr.Read())
            {
                rdr.GetValues(values);
                // 0:idFile,1:nameFile,2:DescFile,3:IdFileType,4:idUserStory
                Classes.File f = new Classes.File((int)values[0], (string)values[1], (string)values[2], (int)values[3], (int)values[4]);
                files.Add(f);
            }

            //Close database and reader
            rdr.Close();
            GetConnection().Close();

            return files;
        }
        public static List<FileType> GetFileTypes()
        {
            //Declare variables
            OleDbCommand cmd;
            OleDbDataReader rdr;
            object[] values;
            List<FileType> fileTypes = new List<FileType>();

            //Open Database
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();

            //Execute SQL Command
            cmd.CommandText = "SELECT * FROM TFileTypes;";
            cmd.Connection = DB.GetConnection();

            //Read and put entries in a list of objects
            rdr = cmd.ExecuteReader();
            values = new object[2];
            while (rdr.Read())
            {
                rdr.GetValues(values);
                // 0:idFileType,1:nameFileType
                FileType f = new FileType((int)values[0], (string)values[1]);
                fileTypes.Add(f);
            }

            //Close database and reader
            rdr.Close();
            GetConnection().Close();

            return fileTypes;
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
            cmd.CommandText = "SELECT * FROM TActivities;";
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
            cmd.CommandText = "SELECT * FROM TChecklists;";
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
            cmd.CommandText = "SELECT * FROM TChecklistItems;";
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
            cmd.CommandText = "SELECT * FROM TComments;";
            cmd.Connection = DB.GetConnection();

            //Read and put entries in a list of objects
            rdr = cmd.ExecuteReader();
            values = new object[4];
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
            cmd.CommandText = "SELECT * FROM TStates;";
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

    }
}
