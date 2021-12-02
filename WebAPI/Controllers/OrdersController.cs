using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class OrdersController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"select OrderID,OrderNo,CustomerID,PMethod,GTotal from Orders";
            DataTable table = new DataTable();
            using (var con = new MySqlConnection(ConfigurationManager.
                ConnectionStrings["GadgetsAppDB"].ConnectionString))
            using (var cmd = new MySqlCommand(query, con))
            using (var da = new MySqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public string Post(Orders emp)
        {
            try
            {
                string query = @"
                    insert into Orders values
                    (
                    '" + emp.OrderID + @"'
                    ,'" + emp.OrderNo + @"'
                    ,'" + emp.CustomerID + @"'
                    ,'" + emp.PMethod + @"'
                    ,'" + emp.GTotal + @"'
                    )
                    ";

                DataTable table = new DataTable();
                using (var con = new MySqlConnection(ConfigurationManager.
                    ConnectionStrings["GadgetsAppDB"].ConnectionString))
                using (var cmd = new MySqlCommand(query, con))
                using (var da = new MySqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Added Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Add!!";
            }
        }
        public string Delete(int id)
        {
            try
            {
                string query = @"
                    delete from Orders
                    where OrderID=" + id + @"
                    ";

                DataTable table = new DataTable();
                using (var con = new MySqlConnection(ConfigurationManager.
                    ConnectionStrings["GadgetsAppDB"].ConnectionString))
                using (var cmd = new MySqlCommand(query, con))
                using (var da = new MySqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Delete!!";
            }
        }
    }
}
