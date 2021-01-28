using Respawn;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static String con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D\DB\Database1.mdf;Integrated Security=True;Connect Timeout=500";

        private static Checkpoint checkpoint = new Checkpoint();

        static SqlConnectionStringBuilder cn = new SqlConnectionStringBuilder(con);


        static void Main(string[] args)
        {
            

            checkpoint.Reset(cn.ToString());

            user();

            Console.ReadKey();
        }
    
        public static void user()
        {
            using (SqlConnection openCon = new SqlConnection(con))
            {
                using (SqlCommand command = new SqlCommand("SELECT * from tbl_user", openCon))
                {

                    openCon.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader.GetString(reader.GetOrdinal("name")));


                    }
                }
            }
        }
        
    }
}
