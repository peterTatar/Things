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
        public List<string> GetNames() {
            using (SqlConnection connection = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database2.mdf;Integrated Security=True"))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Name FROM Szemelyek";
          
                List<string> names = new List<string>();
                var reader = command.ExecuteReader();
                while (reader.Read()) {
                  string name = reader.GetString(0);
                  names.Add(name);
                }
                return names;
            }
        }

        public ActionResult Index()
        {
            ViewBag.Names = GetNames();
            return View();
        }
    }
}