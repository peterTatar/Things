using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web;


namespace DatabaseMenu.Controllers
{
    
    public class ValueController : ApiController
    {
        
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            Models.Person pe = new Models.Person();
            string databeseMessage;
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Temp\DatabaseMenu\DatabaseMenu\App_Data\Database2.mdf;Integrated Security=True"))
            {
                
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Name FROM Szemelyek WHERE Id=" + id.ToString();
                var reader = command.ExecuteReader();
                reader.Read();
                databeseMessage = reader.GetString(0);
                pe.Name = databeseMessage;
                connection.Close();
                
            }
            return "Your database content: " + databeseMessage;
            
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
            
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Temp\DatabaseMenu\DatabaseMenu\App_Data\Database2.mdf;Integrated Security=True"))
            {
                string nev = "'"+value+"'";
                connection.Open();
                string query= "INSERT Into Szemelyek(Name) Values ('"+nev+"')";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();

            }
            
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}