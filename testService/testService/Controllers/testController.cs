using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Data;

namespace testService.Controllers
{
    public class testController : ApiController
    {
        [Route("api/test/getString")]
        public string getString()
        {
            return "Hello world";
        }

        [Route("api/test/getData")]
        public void getData()
        {
            DataTable dta = new DataTable();
            SqlConnection connection = null;
            try
            {
                using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
                {
                    connection.Open();
                    string a = "npm";
                    string query = "INSERT INTO testTable (title)";
                    query += " VALUES (@title)";

                    SqlCommand myCommand = new SqlCommand(query, connection);
                    myCommand.Parameters.AddWithValue("@Title", a);
                    myCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
