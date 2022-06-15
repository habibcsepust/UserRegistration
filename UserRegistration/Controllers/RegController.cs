using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UserRegistration.Models;

namespace UserRegistration.Controllers
{
    public class RegController : Controller
    {
        string connectionString = @"Server = DESKTOP-G004QAU; Database = UserRegitration;
                Integrated Security = true; TrustServerCertificate=True";



        private IHostingEnvironment _ihe;

        public RegController(IHostingEnvironment ihe)
        {
            ihe = ihe;
        }




        public IActionResult Create()

        {
            Registration userRegistration = new Registration
            {
                countrylist = LoadCountry(),
                cityist = LoadCity()
            };
            return View(userRegistration);
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



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Registration userRegistration, IFormFile userImg)
        {
            if (ModelState.IsValid)
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                //string query = "SELECT * FROM TblUsers where Id = " + userRegistration.Id + "";


                string maxSqlQuery = "SELECT MAX(Id) FROM TblUsers";
                SqlCommand sqlCommand = new SqlCommand(maxSqlQuery, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                double maxId;

                DataTable dataTable = new DataTable();
                int isFill = sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    maxId = int.Parse(dataTable.Rows[0][0].ToString());
                }
                else
                {
                    maxId = 0;
                }

                double tmpMaxId = maxId;

                if (userRegistration.Gender == "male")
                {
                    if (maxId % 2 == 0)
                    {
                        if (tmpMaxId == maxId) {
                            maxId = maxId + 2;
                        }
                        
                    }
                    else
                    {
                        maxId = maxId + 1;
                    }
                }
                else if (userRegistration.Gender == "female")
                {
                    if (maxId % 2 == 0)
                    {
                        maxId = maxId + 1;
                    }
                    else
                    {
                        if (tmpMaxId == maxId)
                        {
                            maxId = maxId + 1;
                        }
                    }
                }
                else
                {
                    bool isPrime = true;
                    double checkInitial = maxId+1;
                    maxId = maxId + 100;
                    for (double i = checkInitial; i <= maxId; i++)
                    {
                        for (double j = 2; j <= maxId; j++)
                        {
                            if (i != j && i % j == 0)
                            {
                                isPrime = false;
                                break;
                            }
                        }
                        if (isPrime)
                        {
                            if (tmpMaxId == maxId)
                            {
                                maxId = maxId + 1;
                            }
                            else 
                            {
                                maxId = i;
                            }
                        }
                        isPrime = true;
                    }
                }

                maxId = Convert.ToDouble(maxId.ToString().PadLeft(4, '0'));

                userRegistration.Id = Convert.ToInt32(maxId);
                

                //outputValue = number.ToString().PadLeft(4, '0');

                //if (maxId == userRegistration.Id)
                //{
                //    ViewBag.registered = "Already registered user..";
                //    return View(userRegistration);
                //}

                if (userImg != null && userImg.Length > 0)
                {
                    var file = userImg;
                    var uploads = Path.Combine("images", Path.GetFileName(userImg.FileName));
                    await userImg.CopyToAsync(new FileStream(uploads, FileMode.Create));
                    userRegistration.userImg = "images/" + userImg.FileName;
                }

                if (userImg == null)
                {
                    //userRegistration.userImg = "images/notfound.jpg";
                    ViewBag.NoFoundImage = "No Found Image";
                }



                string strInsertSql = "INSERT INTO TblUsers(Id,fName, lName,phoneNo,emailNo,countryName,userCity,userImg, password,Gender)" +
                    "VALUES(" + userRegistration.Id + ",'" + userRegistration.fName + "','" + userRegistration.lName + "','" + userRegistration.phoneNo + "','" + userRegistration.emailNo + "'," + userRegistration.countryName + "," + userRegistration.userCity + "," +
                    "'" + userRegistration.userImg + "','" + userRegistration.password + "','" + userRegistration.Gender + "')";
                SqlCommand sqlCommand3 = new SqlCommand(strInsertSql, sqlConnection);

                int isExecute = sqlCommand3.ExecuteNonQuery();
                if (isExecute > 0)
                {
                    ViewBag.Save = "Product has been Saved Successfully.";
                }
                sqlConnection.Close();

            }
            return RedirectToAction(nameof(Create));
        }
    }
}
