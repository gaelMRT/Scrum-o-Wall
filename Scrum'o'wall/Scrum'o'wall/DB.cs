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
        public static UserStory CreateUserStory(string text, int complexity, double timeInDays, Project project)
        {
            //Initialize variables
            OleDbCommand cmd;
            int id;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "INSERT INTO TUserStories (,Description,DateBegin) VALUES (?,?,?);";
            cmd.Parameters.Add("NameProject", OleDbType.VarChar, 25);
            cmd.Parameters.Add("Description", OleDbType.LongVarChar, 65535);
            cmd.Parameters.Add("DateBegin", OleDbType.Date);
            cmd.Parameters[0].Value = text;
            cmd.Parameters[1].Value = complexity;
            cmd.Parameters[2].Value = timeInDays;

            //Execute sql statement
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //Get last inserted id
            cmd.CommandText = "SELECT @@Identity;";
            id = (int)cmd.ExecuteScalar();

            //Close database
            DB.GetConnection().Close();

            //return created project
            UserStory u = new UserStory();
            return u;
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
            values = new object[2];
            while (rdr.Read())
            {
                rdr.GetValues(values);
                // 0:IdProject,1:IdState
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
            values = new object[6];
            while (rdr.Read())
            {
                rdr.GetValues(values);
                // 0:idUserStory,1:DescriptionUserStory,2:TimeEstimation,3:ComplexityEstimation,4:IdProject,5:IdState
                UserStory u = new UserStory((int)values[0], (string)values[1], (float)values[2], (int)values[3], (int)values[4], (int)values[5]);
                userStories.Add(u);
            }

            //Close database and reader
            rdr.Close();
            GetConnection().Close();

            return userStories;
        }
        public static Dictionary<int,string> GetStates()
        {
            //Declare variables
            OleDbCommand cmd;
            OleDbDataReader rdr;
            object[] values;
            Dictionary<int, string> states = new Dictionary<int, string>();

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
                states.Add((int)values[0], (string)values[1]);
            }

            //Close database and reader
            rdr.Close();
            GetConnection().Close();

            return states;

        }
    }
}
