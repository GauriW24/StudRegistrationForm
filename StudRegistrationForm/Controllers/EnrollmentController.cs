using StudRegistrationForm.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace StudRegistrationForm.Controllers
{
    public class EnrollmentController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(StudentReg s)
        {
            if (ModelState.IsValid)
            {
                //StudentReg sr = new StudentReg();
                SqlConnection con;
                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;

                    using (con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("studentInfo..SP_EnrollDetail", con))
                        {
                            cmd.Parameters.Clear();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@name", s.name);
                            cmd.Parameters.AddWithValue("@email", s.email);
                            cmd.Parameters.AddWithValue("@MobileNo", s.mobno);
                            cmd.Parameters.AddWithValue("@status", "Insert");

                            con.Open();
                            int result= cmd.ExecuteNonQuery();
                            cmd.Dispose();
                            con.Close();
                            
                            return RedirectToAction("Index"); // Redirect to the same action to clear the form

                        }
                    }
                }
                catch (Exception ex)
                {
                    ViewData["error"] = ex;
                }

                return View(s);

            }
            return View();
        }
        

    }
}

