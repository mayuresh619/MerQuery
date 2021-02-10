using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Portfolio()
        {
            return View();
        }


        public JsonResult GetPortfolio()
        {
            DataTable dt = new DataTable();
            IList<PortfolioResponse> response;
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]))
            {
                string query = "GetAllPortfolio";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                dt.Load(dr);
            }

            if(dt.Rows.Count>0)
            {
                response = dt.AsEnumerable().Select(rows => new PortfolioResponse
                {
                    PortfolioID = rows.Field<int>("PortfolioID"),
                    PortfolioName = rows.Field<string>("PortfolioName"),
                    PortfolioLink = rows.Field<string>("PortfolioLink"),
                    PortfolioType = rows.Field<string>("PortfolioType"),
                    ImageName = rows.Field<string>("ImageName"),
                    ImagePath = rows.Field<string>("ImagePath"),
                }).ToList();
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }


    }
}