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

            

<<<<<<< HEAD
            connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\naimur\\OneDrive\\Documents\\logindata.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False"; // Set it privately
=======
            connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\FINAL_PROJECT_Database\\PetHostelDatabase.mdf;Integrated Security=True;Connect Timeout=30";
>>>>>>> 496c5df1989eab9110369a84ef1ca5fe23388f53

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


