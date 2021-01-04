using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using lucysPlace.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace lucysPlace.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class LoginController : ControllerBase
    {
        private readonly IConfiguration configuration;
        public LoginController(IConfiguration configurations)
        {
             configuration= configurations;
        }
        [HttpGet]
        public JsonResult GetLonginDetail()
        {
            string query = @" select loginId,Username,password  from dbo.Login";
            DataTable table = new DataTable();
            string getconnection = configuration.GetConnectionString("LucysPlaceDb");
            SqlDataReader readers ;

            using(SqlConnection conect= new SqlConnection(getconnection))
            {
                conect.Open();
                using(SqlCommand command = new SqlCommand(query, conect))
                {
                    readers = command.ExecuteReader();
                    table.Load(readers);
                    readers.Close();
                    conect.Close();
                }
            }

            return new JsonResult(table);


        }
        [HttpGet("{Id}")]
        public JsonResult GetLbyId(int Id)
        {
            string query = @" select loginId,Username,password  from dbo.Login where loginId= '" + Id + @"'";
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

            return new JsonResult(table);


        }
        [HttpPost]
        public JsonResult Post(Login login)
        {
            string query = string.Format(" insert into  dbo.Login(Username,password) values('{0}','{1}')",login.Username, login.Password);
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

            return new JsonResult("succesfull added");

        }
    
        [HttpPut("{Id}")]
        public JsonResult Put(Login login)
        {
           
            string query = string.Format(" update  dbo.Login set Username='"+login.Username+"',password='"+login.Password+"'  where loginId= '"+login.Id+ @"' ");
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

            return new JsonResult("succesfull updated");

        }
        [HttpDelete("{Id}")]
        public JsonResult delete(int Id)
        {

            string query = string.Format(" delete from dbo.Login   where loginId= '" +Id+ @"' ");
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

            return new JsonResult("succesfull deleted");

        }
    }
}
