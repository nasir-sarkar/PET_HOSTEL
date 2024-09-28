using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PET_HOSTEL
{
    public class PetHostelDataAccess
    {
        public static string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\ABU JAFAR SISTY\Documents\pet hostel.mdf"";Integrated Security=True;Connect Timeout=30;Encrypt=False";

        //This returns the connection string  
        private static string _connectionString = string.Empty;

        public static string ConnectionString
        {
            get
            {
                if (_connectionString == string.Empty)
                {
                    _connectionString = CONNECTION_STRING;
                }

                return _connectionString;
            }
        }


        public PetHostelDataAccess(string databaseFileName)
        {
            // AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory+@"\..\..");
            var rootPath = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", "");
            _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='" + rootPath + databaseFileName + @"';Integrated Security=True;Connect Timeout=30";
            //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="C:\Users\ABU JAFAR SISTY\Documents\pet hostel.mdf";Integrated Security=True;Connect Timeout=30;Encrypt=True
            //ConfigurationSettings.AppSettings["ConnectionString"];

        }

        /// <summary>
        /// This is the method to get the command
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public SqlCommand GetCommand(string sql)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand sqlCmd = new SqlCommand(sql, conn);
            return sqlCmd;
        }

        /// <summary>
        /// Execute the command and return the data table
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public DataTable ExecuteCommand(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            cmd.Connection.Open();
            dt.Load(cmd.ExecuteReader());
            cmd.Connection.Close();
            return dt;
        }

        public DataTable ExecuteCommand(string sql, SqlParameterCollection sqlParameters)
        {
            DataTable dt = new DataTable();
            var cmd = GetCommand(sql);
            foreach (var parameter in sqlParameters)
            {
                cmd.Parameters.Add(parameter);
            }
            cmd.Connection.Open();
            dt.Load(cmd.ExecuteReader());
            cmd.Connection.Close();
            return dt;
        }
        /// <summary>
        /// This is the method to execute the sql and return the data table
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable Execute(string sql)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = GetCommand(sql);

            cmd.Connection.Open();
            dt.Load(cmd.ExecuteReader());
            cmd.Connection.Close();
            return dt;
        }
        /// <summary>
        /// This is the method to execute the sql and return the data table
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql)
        {
            SqlCommand cmd = GetCommand(sql);
            int result = 0;

            cmd.Connection.Open();
            result = cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            return result;
        }

        public int ExecuteNonQueryCommand(SqlCommand cmd)
        {
            int result = 0;

            cmd.Connection.Open();
            result = cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            return result;
        }

        public T ExecuteScalar<T>(string commandText, params SqlParameter[] parameters)
        {
            var command = GetCommand(commandText);
            foreach (var p in parameters)
            {
                command.Parameters.Add(p);
            }
            var result = command.ExecuteScalar();
            return (T)Convert.ChangeType(result, typeof(T));
        }


    }
}
