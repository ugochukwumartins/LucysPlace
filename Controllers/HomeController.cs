using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using lucysPlace.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace lucysPlace.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IConfiguration configuration;
      
        public HomeController(ILogger<HomeController> logger, IConfiguration configurations)
        {
            _logger = logger;
            configuration = configurations;
        }
      
        
        public IActionResult Signup()
        {
            return View();
        }
    
        public IActionResult Registration()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registration(RegistrationPage Reg)
        {
            if (ModelState.IsValid)
            {


                string query = string.Format(" insert into  Registration(Username,Email,Password) values('{0}','{1}','{2}')", Reg.Username, Reg.Email, Reg.Password);
                DataTable table = new DataTable();
                string getconnection = configuration.GetConnectionString("LucysPlaceDb");
                SqlDataReader readers;

                using (SqlConnection conect = new SqlConnection(getconnection))
                {
                    conect.Open();
                    using (SqlCommand command = new SqlCommand(query, conect))
                    {
                        readers = command.ExecuteReader();
                        table.Load(readers);
                        readers.Close();
                        conect.Close();
                    }
                }
            }
            // return new JsonResult("succesfull added");
            return View("Signup");

        }
    }
}
