using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UserRegistration.Models;
using UserRegistration.Repository;

namespace UserRegistration.Controllers
{
    public class HomeController : Controller
    {

        private IHostingEnvironment Environment;
        //private IHostingEnvironment _ihe;

        //public RegController(IHostingEnvironment ihe)
        //{
        //    ihe = ihe;
        //}

        CheckDataValidityRepo _checkData = new CheckDataValidityRepo();
        public static string intId { get; set; }

        //public HomeController(IHostingEnvironment _environment)
        //{
        //    Environment = _environment;
        //}


        string connectionString = @"Server = DESKTOP-G004QAU; Database = UserRegitration;
                Integrated Security = true; TrustServerCertificate=True";

        public static string strEmail { get; set; }



        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [HttpPost]
        public JsonResult GetCityByCountry(int? countryId)
        //public List<City> GetCityByCountry(int? countryId)
        {
            List<City> cities = new List<City>();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string query = "SELECT Id, cityName, CountryId FROM TblCity where CountryId=" + countryId+"";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                City city = new City();
                city.Id = Convert.ToInt32(sqlDataReader["Id"]);
                city.cityName = sqlDataReader["cityName"].ToString();


                cities.Add(city);
                
            }
            sqlConnection.Close();

            return Json(cities);
            //return cities;
        }


        [HttpPost]
        public JsonResult Edit(int id)
        {
            RegistrationViewModel registrationViewModel = new RegistrationViewModel();
            try
            {
                //intId = id.ToString();
                //return RedirectToAction("UserList", "Home");
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                var sqlquery = "select tuser.Id as id, CONCAT(fName,+' '+lName) as name,tuser.fName as fName,tuser.lName as lName,tuser.phoneNo as phone,tuser.Gender as gender, tuser.emailNo as email, tuser.dob as dob,tuser.password as password,tuser.userImg as Image,tuser.userCV as CV, tcountry.countryName as country,tcountry.Id as countryId, tcity.cityName as city,tcity.Id as cityId from TblUsers tuser left join TblCity tcity on tuser.userCity = tcity.Id left join TblCountry tcountry on tcountry.Id = tcity.CountryId WHERE tuser.Id=" + id+"";

                SqlCommand sqlCommand = new SqlCommand(sqlquery, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
               
                while (sqlDataReader.Read())
                {
                    registrationViewModel.Id = Convert.ToInt32(sqlDataReader["id"].ToString());
                    registrationViewModel.fName = sqlDataReader["fName"].ToString();
                    registrationViewModel.lName = sqlDataReader["lName"].ToString();
                    registrationViewModel.dob = Convert.ToDateTime(sqlDataReader["dob"].ToString());
                    registrationViewModel.name = sqlDataReader["name"].ToString();
                    registrationViewModel.phone = sqlDataReader["phone"].ToString();
                    registrationViewModel.email = sqlDataReader["email"].ToString();
                    registrationViewModel.password = sqlDataReader["password"].ToString();
                    registrationViewModel.gender = sqlDataReader["gender"].ToString();
                    registrationViewModel.city = sqlDataReader["city"].ToString();
                    registrationViewModel.country = sqlDataReader["country"].ToString();
                    registrationViewModel.cityId = Convert.ToInt32(sqlDataReader["cityId"].ToString());
                    registrationViewModel.countryId = Convert.ToInt32(sqlDataReader["countryId"].ToString());
                    registrationViewModel.userImg = sqlDataReader["Image"].ToString();
                    registrationViewModel.userCV = sqlDataReader["CV"].ToString();
                }
                sqlConnection.Close();
               
            }
            catch (Exception ex)
            {
            }

            return Json(registrationViewModel);
        }


        public IActionResult UserList()
        {
            List<RegistrationViewModel> registrationViewModels = new List<RegistrationViewModel>();
            try
            {
                int id;
                string strSql = "";
                if (intId != null)
                {
                    id = Convert.ToInt32(intId);
                    strSql = "where tuser.Id = " + id + "";
                }
                else
                {
                    strSql = "";
                }
                
                //RegistrationViewModel registrationViewModel = new RegistrationViewModel();
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                //var sqlquery = "SELECT top 10 CONCAT(fName,+' '+lName) as name,tu.phoneNo as phone, tu.emailNo as email, tu.dob as dob, tu.userImg as Image, tu.userCV as CV, tc.cityName as city, tblc.countryName as country from TblUsers tu left join TblCity tc ON tu.userCity = tc.Id left join TblCountry tblc ON  tu.countryName = tblc.Id where tu.emailNo = '" + strEmail + "'";

                var sqlquery = "select tuser.Id as id, CONCAT(fName,+' '+lName) as name,tuser.fName as fName,tuser.lName as lName,tuser.phoneNo as phone,tuser.Gender as gender, tuser.emailNo as email, tuser.dob as dob,tuser.userImg as Image,tuser.userCV as CV, tcountry.countryName as country, tcity.cityName as city from TblUsers tuser left join TblCity tcity on tuser.userCity = tcity.Id left join TblCountry tcountry on tcountry.Id = tcity.CountryId order by tuser.Id DESC";

                SqlCommand sqlCommand = new SqlCommand(sqlquery, sqlConnection);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    RegistrationViewModel registrationViewModel = new RegistrationViewModel();

                    DateTime dob = Convert.ToDateTime(sqlDataReader["dob"].ToString());

                    DateTime Now = DateTime.Now;
                    int Years = new DateTime(DateTime.Now.Subtract(dob).Ticks).Year - 1;
                    DateTime PastYearDate = dob.AddYears(Years);
                    int Months = 0;
                    for (int i = 1; i <= 12; i++)
                    {
                        if (PastYearDate.AddMonths(i) == Now)
                        {
                            Months = i;
                            break;
                        }
                        else if (PastYearDate.AddMonths(i) >= Now)
                        {
                            Months = i - 1;
                            break;
                        }
                    }
                    int Days = Now.Subtract(PastYearDate.AddMonths(Months)).Days;
                    //int Hours = Now.Subtract(PastYearDate).Hours;
                    //int Minutes = Now.Subtract(PastYearDate).Minutes;
                    //int Seconds = Now.Subtract(PastYearDate).Seconds;


                    
                    registrationViewModel.Id = Convert.ToInt32(sqlDataReader["id"].ToString());
                    registrationViewModel.fName = sqlDataReader["fName"].ToString();
                    registrationViewModel.lName = sqlDataReader["lName"].ToString();
                    registrationViewModel.dob = dob;
                    registrationViewModel.name = sqlDataReader["name"].ToString();
                    registrationViewModel.phone = sqlDataReader["phone"].ToString();
                    registrationViewModel.email = sqlDataReader["email"].ToString();
                    registrationViewModel.gender = sqlDataReader["gender"].ToString();
                    registrationViewModel.city = sqlDataReader["city"].ToString();
                    registrationViewModel.country = sqlDataReader["country"].ToString();
                    registrationViewModel.Year = Years;
                    registrationViewModel.Month = Months;
                    registrationViewModel.Day = Days;
                    registrationViewModel.userImg = sqlDataReader["Image"].ToString();
                    registrationViewModel.userCV = sqlDataReader["CV"].ToString();

                    registrationViewModels.Add(registrationViewModel);
                }
                sqlConnection.Close();
                //return View(registrationViewModel);
            }
            catch (Exception ex){ 
            }
            ViewBag.registrationData = "";
            
            ViewBag.registrationData = registrationViewModels;
            ViewBag.Total = registrationViewModels.Count();

            Registration userRegistration = new Registration
            {
                countrylist = LoadCountry(),
                cityist = LoadCity()
            };
            return View(userRegistration);
            
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














        public List<Country> LoadCountry()
        {
            List<Country> countries = new List<Country>();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string query = "SELECT * FROM TblCountry";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Country country = new Country();
                country.Id = Convert.ToInt32(sqlDataReader["Id"]);
                country.countryName = sqlDataReader["countryName"].ToString();

                countries.Add(country);
            }
            sqlConnection.Close();

            return countries;
        }

        public List<City> LoadCity()
        {
            List<City> cities = new List<City>();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string query = "SELECT * FROM TblCity";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                City city = new City();
                city.Id = Convert.ToInt32(sqlDataReader["Id"]);
                city.cityName = sqlDataReader["cityName"].ToString();

                cities.Add(city);
            }
            sqlConnection.Close();

            return cities;
        }


    }
}
