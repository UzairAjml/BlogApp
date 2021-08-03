using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models
{
    public class BlogRepos
    {


        public static List<Blog> blog = new List<Blog>(); // Creates LIst Of Type Blog
        
        
        // It gets Data from Blog and stores it in List
        public static int GetPosts()
        {
            

            try
            {
                string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Blog;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string query = $"select * from post";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Blog b = new Blog();

                    b.Id = (int)dr.GetValue(0);
                    b.Title = (string)dr.GetValue(1);
                    b.Context = (string)dr.GetValue(2);
                    int r= (int)dr.GetValue(3);
                    if ( r!= 0)
                    {
                        b.refrence = r;
                    }
                    else
                    {
                        b.refrence = 0;
                    }
                    blog.Add(b);

                }
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }


        }

        // To clean the List
        public static void Clean()
        {
            blog.Clear();
        }



    }
}
