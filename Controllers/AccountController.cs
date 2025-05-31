using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MyMVCApplication.Models;
using System.Data.SqlClient;

namespace MyMVCApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly string _connectionString = "data source=.;database=JOVANNIE;integrated security=SSPI;";

        /*[HttpPost]
        public IActionResult Login(Account model)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Login WHERE username = @Name AND password = @Password", con))
                    {
                        cmd.Parameters.AddWithValue("@Name", model.Name);
                        cmd.Parameters.AddWithValue("@Password", model.Password);

                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            return RedirectToAction("Home", "Index");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Invalid email or password.");
                        }
                    }
                }
            }
            return View(model);
        }*/



        /* [HttpGet]
         public IActionResult Login()
        {
            return View(); // Render the login page for GET requests
        }

        [HttpPost]
        public IActionResult Login(Account model)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Login WHERE username = @Name AND password = @Password", con))
                    {
                        cmd.Parameters.AddWithValue("@Name", model.Name);
                        cmd.Parameters.AddWithValue("@Password", model.Password);

                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Invalid email or password.");
                        }
                    }
                }
            }
            return View(model); // Return the view with errors if validation fails
        }*/

        [HttpGet]
        public IActionResult Login()
        {
            return View(); // Render the login page for GET requests
        }

        [HttpPost]
        public IActionResult Login(Account model)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();

                    // Updated SQL query for better handling
                    string query = "SELECT COUNT(1) FROM dbo.Account " +
                                   "WHERE LOWER(Name) = LOWER(@Name) AND password = @Password";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", model.Name ?? string.Empty);
                        cmd.Parameters.AddWithValue("@Password", model.Password ?? string.Empty);

                        // Check if a valid match exists
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count == 1)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Invalid email or password.");
                        }
                    }
                }
            }

            return View(model); // Return the view with validation errors
        }


    }
}
