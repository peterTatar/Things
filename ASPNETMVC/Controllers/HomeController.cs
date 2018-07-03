using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNETMVC.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult About()
    {
      using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=r:\Temp\Peti\ASPNETMVC\ASPNETMVC\App_Data\Database1.mdf;Integrated Security=True")) {
        connection.Open();

        SqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT Message FROM AboutMessages WHERE Id = 2";

        var reader = command.ExecuteReader();
        reader.Read();
        string databaseMessage = reader.GetString(0);
      
        ViewBag.Message = "Your application description page. " + databaseMessage;
      }
      
      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
  }
}