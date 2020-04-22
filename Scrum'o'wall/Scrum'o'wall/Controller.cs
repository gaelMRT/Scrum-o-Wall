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
        public void GetProjects()
        {
            //Initialise variables
            OleDbCommand cmd;
            OleDbDataReader rdr;
            List<Project> someProjects = new List<Project>();

            //Execute SQL Command
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "SELECT * FROM TProjects;";
            cmd.Connection = DB.GetConnection();

            //Read and put projects in a list
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                object[] values = new object[rdr.FieldCount];
                rdr.GetValues(values);
                Project p = new Project((int)values[0], (string)values[1], (string)values[2], (DateTime)values[3]);
                someProjects.Add(p);
            }
            projects = someProjects;

            //Close database and reader
            rdr.Close();
            DB.GetConnection().Close();
        }

        /// <summary>
        /// Create a project and add it to all projects
        /// </summary>
        /// <param name="aName"></param>
        /// <param name="aDesc"></param>
        /// <param name="aDate"></param>
        public void CreateProject(string aName,string aDesc, DateTime aDate)
        {
            //Initialize variables
            OleDbCommand cmd;
            int id;

            //Open database, build sql statement and prepare
            DB.GetConnection().Open();
            cmd = DB.GetConnection().CreateCommand();
            cmd.CommandText = "INSERT INTO TProjects (NameProject,Description,DateBegin) VALUES (?,?,?);";
            cmd.Parameters.Add("NameProject", OleDbType.VarChar,25);
            cmd.Parameters.Add("Description", OleDbType.LongVarChar,65535);
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
