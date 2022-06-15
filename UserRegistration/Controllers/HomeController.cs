using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UserRegistration.Models;

namespace UserRegistration.Controllers
{
    public class HomeController : Controller
    {


        string connectionString = @"Server = DESKTOP-G004QAU; Database = UserRegitration;
                Integrated Security = true; TrustServerCertificate=True";

        public static string strEmail { get; set; }



        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult UserList()
        {
            List<RegistrationViewModel> registrationViewModels = new List<RegistrationViewModel>();
            RegistrationViewModel registrationViewModel = new RegistrationViewModel();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            var sqlquery = "SELECT top 10 CONCAT(fName,+' '+lName) as name,tu.phoneNo as phone, tu.emailNo as email, tc.cityName as city, tblc.countryName as country from TblUsers tu left join TblCity tc ON tu.userCity = tc.Id left join TblCountry tblc ON  tu.countryName = tblc.Id where tu.emailNo = '" + strEmail + "'";

            SqlCommand sqlCommand = new SqlCommand(sqlquery, sqlConnection);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                
                registrationViewModel.name = sqlDataReader["name"].ToString();
                registrationViewModel.phone = sqlDataReader["phone"].ToString();
                registrationViewModel.email = sqlDataReader["email"].ToString();
                registrationViewModel.city = sqlDataReader["city"].ToString();
                registrationViewModel.country = sqlDataReader["country"].ToString();

                registrationViewModels.Add(registrationViewModel);
            }
            sqlConnection.Close();
            return View(registrationViewModel);
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Registration registration)
        {
            //var username = registration.emailNo;
            //var pass = registration.password;


            var username = "admin@admin.com";
            var pass = "@123@";


            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            var sql = "select * from TblUsers  where emailNo = '" + username + "' and password = '" + pass + "'";
            SqlCommand sqlCommand1 = new SqlCommand(sql, sqlConnection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand1);
            DataTable dataTable = new DataTable();
            int isFill = sqlDataAdapter.Fill(dataTable);

            if (isFill > 0)
            {
                strEmail = username;
                ViewBag.registered = "Signed In";
                return RedirectToAction(nameof(UserList));
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
