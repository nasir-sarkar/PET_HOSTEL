using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using System.Data;

using System.Data.SqlClient;

namespace PET_HOSTEL

{

    public class DataAccess

    {

        private string connectionString;

       

        public DataAccess()
        {

            connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\naimur\\OneDrive\\Documents\\AddAccess.mdf;Integrated Security=True;Connect Timeout=30";
        
        }

      

        public string GetConnectionString()

        {

            return connectionString;

        }
        public void ConnectToDatabase()

        {

            using (SqlConnection con = new SqlConnection(connectionString))

            {

                con.Open();
 

            }

        }

    }


}


