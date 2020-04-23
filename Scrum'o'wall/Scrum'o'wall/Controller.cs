using Scrum_o_wall.Classes;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Scrum_o_wall
{
    public class Controller
    {
        public List<Project> projects;

        public Controller()
        {
            GetDatas();
        }
        public void GetDatas()
        {
            //Initialise variables
            OleDbCommand cmd;
            OleDbDataReader rdr;
            object[] values;
            List<Project> allProjects = new List<Project>();
            List<UserStory> allUserStories = new List<UserStory>();
            List<Sprint> allSprints = new List<Sprint>();
            Dictionary<int, string> allStates = new Dictionary<int, string>();

            //Open Database
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();

            #region Projects
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
                allProjects.Add(p);
            }

            //Close database and reader
            rdr.Close();
            #endregion
            #region Sprints
            //Execute SQL Command
            cmd.CommandText = "SELECT * FROM TSprints;";

            //Read and put entries in a list of objects
            rdr = cmd.ExecuteReader();
            values = new object[3];
            while (rdr.Read())
            {
                rdr.GetValues(values);
                // 0:idSprint,1:DateBegin,2:DateEnd
                Sprint s = new Sprint((int)values[0], (DateTime)values[1], (DateTime)values[0]);
                allSprints.Add(s);
            }

            //Close database and reader
            rdr.Close();

            #endregion
            #region UserStories
            //Execute SQL Command
            cmd.CommandText = "SELECT * FROM TUserStories;";

            //Read and put entries in a list of objects
            rdr = cmd.ExecuteReader();
            values = new object[6];
            while (rdr.Read())
            {
                rdr.GetValues(values);
                // 0:idUserStory,1:DescriptionUserStory,2:TimeEstimation,3:ComplexityEstimation,4:IdProject,5:IdState
                UserStory u = new UserStory((int)values[0], (string)values[1], (float)values[2], (int)values[3], (int)values[4], (int)values[5]);
                allUserStories.Add(u);
            }

            //Close database and reader
            rdr.Close();

            #endregion
            #region States
            //Execute SQL Command
            cmd.CommandText = "SELECT * FROM TStates;";

            //Read and put entries in a list of objects
            rdr = cmd.ExecuteReader();
            values = new object[2];
            while (rdr.Read())
            {
                rdr.GetValues(values);
                // 0:IdState,1:NameState
                allStates.Add((int)values[0], (string)values[1]);
            }

            //Close database and reader
            rdr.Close();

            #endregion

            #region Link State with project

            //Execute SQL Command
            cmd.CommandText = "SELECT * FROM TProjectStates;";

            //Read and assign states with project
            rdr = cmd.ExecuteReader();
            values = new object[2];
            while (rdr.Read())
            {
                rdr.GetValues(values);
                // 0:IdProject,1:IdState
                allProjects.First(p => p.Id == (int)values[0]).addState(allStates[(int)values[1]]);
            }

            //Close database and reader
            rdr.Close();
            #endregion

            #region Link UserStory with Sprint

            //Execute SQL Command
            cmd.CommandText = "SELECT * FROM TUserStoriesSprint;";

            //Read and assign states with project
            rdr = cmd.ExecuteReader();
            values = new object[3];
            while (rdr.Read())
            {
                rdr.GetValues(values);
                // 0:IdUserStory,1:IdSprint,2:Order
                allSprints.First(s => s.Id == (int)values[1]).addUserStory(allUserStories.First(u => u.Id == (int)values[0]));
            }

            //Close database and reader
            rdr.Close();
            #endregion

            #region Link UserStory with Project
            foreach (UserStory u in allUserStories)
            {
                allProjects.First(p => p.Id == u.ProjectId).addUserStory(u);
            }
            #endregion

            projects = allProjects;
            DB.GetConnection().Close();
        }

        /// <summary>
        /// Create a project and add it to all projects
        /// </summary>
        /// <param name="aName"></param>
        /// <param name="aDesc"></param>
        /// <param name="aDate"></param>
        public void CreateProject(string aName, string aDesc, DateTime aDate)
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

            //Add created project to list of all projects
            Project p = new Project(id, aName, aDesc, aDate);
            projects.Add(p);

        }
    }
}
