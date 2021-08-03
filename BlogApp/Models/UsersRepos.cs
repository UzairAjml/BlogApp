using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models
{
    public class UsersRepos
    {


        public static List<Users> users = new List<Users>();  // A list of Type User is Created

        
        // This Function gets data from DB and stores it in User type List
        public static int Users()
        {
            users.Clear();
            try
            {
                string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string query = $"select * from users";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Users u = new Users();

                    u.Id = (int)dr.GetValue(0);
                    u.RegisterUsername = (string)dr.GetValue(1);
                    u.RegisterEmail = (string)dr.GetValue(2);
                    u.RegisterPassword = (string)dr.GetValue(3);

                    users.Add(u);

                }
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }


        }
    }
}
