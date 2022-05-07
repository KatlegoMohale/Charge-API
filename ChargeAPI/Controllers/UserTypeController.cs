using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChargeAPI.Models;

namespace ChargeAPI.Controllers
{
    public class UserTypeController : ApiController
    {
        [Route("api/UserType/GetUserTypes")]
        [HttpGet]
        public HttpResponseMessage GetUserTypes()
        {
            string query = @"
                SELECT UserTypeID, UserTypeName, UserTypeDescription
                FROM dbo.UserType
                ";

            DataTable table = new DataTable();
            using(var connection= new SqlConnection(ConfigurationManager.
                ConnectionStrings["ChargeDB"].ConnectionString))

            using(var command= new SqlCommand(query,connection))
            using (var dataAdapter= new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.Text;
                dataAdapter.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        [Route("api/UserType/CreateUserType")]
        [HttpPost]
        public string CreateUserType(UserType usertype)
        {
            try
            {
                string query = @"
                               INSERT INTO dbo.UserType VALUES 
                               (
                                 '" + usertype.UserTypeName + @"'
                                ,'" + usertype.UserTypeDescription + @"'
                               )";

                DataTable table = new DataTable();
                using (var connection = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["ChargeDB"].ConnectionString))

                using (var command = new SqlCommand(query, connection))
                using (var dataAdapter = new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.Text;
                    dataAdapter.Fill(table);
                }
                return "A new user type has been successfully added";

            }
            catch (Exception)
            {

                return "Failed to add a new user type";
            }

        }

        [Route("api/UserType/UpdateUserType")]
        [HttpPut]
        public string UpdateUserType(UserType usertype)
        {
            try
            {
                string query = @"
                               UPDATE dbo.UserType SET
                               UserTypeName='" + usertype.UserTypeName + @"'
                              ,UserTypeDescription='" + usertype.UserTypeDescription + @"'
                               WHERE UserTypeID=" + usertype.UserTypeID + @"
                               ";

                DataTable table = new DataTable();
                using (var connection = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["ChargeDB"].ConnectionString))

                using (var command = new SqlCommand(query, connection))
                using (var dataAdapter = new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.Text;
                    dataAdapter.Fill(table);
                }
                return "A new user type has been successfully updated";

            }
            catch (Exception)
            {

                return "Failed to update the user type";
            }

        }

        [Route("api/UserType/DeleteUserType")]
        [HttpDelete]
        public string DeleteUserType(int id)
        {
            try
            {
                string query = @"
                               DELETE FROM dbo.UserType
                               WHERE UserTypeID=" + id + @"
                               ";

                DataTable table = new DataTable();
                using (var connection = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["ChargeDB"].ConnectionString))

                using (var command = new SqlCommand(query, connection))
                using (var dataAdapter = new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.Text;
                    dataAdapter.Fill(table);
                }
                return "A user type has been successfully deleted";

            }
            catch (Exception)
            {

                return "Failed to delete the user type";
            }

        }

        [Route("api/UserType/getAllUserTypes")]
        [HttpGet]
        public HttpResponseMessage getAllUserTypes()
        {
            string query = @"
                           SELECT UserTypeName 
                           FROM dbo.UserType";

            DataTable table = new DataTable();
            using (var connection = new SqlConnection(ConfigurationManager.
                ConnectionStrings["ChargeDB"].ConnectionString))

            using (var command = new SqlCommand(query, connection))
            using (var dataAdapter = new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.Text;
                dataAdapter.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK,table);

        }

    }
}
