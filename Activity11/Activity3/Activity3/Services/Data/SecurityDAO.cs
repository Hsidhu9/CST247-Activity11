using Activity3.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Activity3.Services.Data
{
    public class SecurityDAO
    {
        //connection string that connects to local database, integrated security auto passes windows credentials
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;initial catalog=Test ;Integrated Security=True;";
        public bool FindByUser(UserModel user)
        {

            // SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["connString"].ConnectionString);

            //SQL conn uses connectionString to initialize DB connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            { 
                //SQL query to cross check input from view which is passed in by FindByUser method to see if there is any data that matches in the DB 
                string query = "SELECT * FROM [Users] WHERE USERNAME ='"+ user.Username +"' AND PASSWORD ='" + user.Password +"'";
                string oldquery = "SELECT * FROM [Users]";
                //this initializes the sql query with the connection
                SqlCommand sql = new SqlCommand(query, conn); //WHERE USERNAME = @User  AND PASSWORD = @Pass", conn);
                //executes
                conn.Open();
                //read input by rows
                SqlDataReader read = sql.ExecuteReader();
                //if a row is returned, we know it's a match: login success / else no match and login fail
                if (read.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}