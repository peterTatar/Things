using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseMenu.Controllers
{
    public class FirstPageController : Controller
    {
        // GET: FirstPage
        public void DataRequest(int id) {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Temp\DatabaseMenu\DatabaseMenu\App_Data\Database2.mdf;Integrated Security=True"))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Name FROM Szemelyek WHERE Id="+id.ToString();
                var reader = command.ExecuteReader();
                reader.Read();
                string databeseMessage = reader.GetString(0);
                ViewBag.ThisCanBeEverything = "Your database content: " + databeseMessage;
            }
        }
        public ActionResult Index()
        {
            DataRequest(3);
            return View();
        }
    }
}