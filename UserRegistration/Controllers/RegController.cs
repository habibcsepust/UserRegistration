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
using UserRegistration.Repository;

namespace UserRegistration.Controllers
{
    public class RegController : Controller
    {
        string connectionString = @"Server = DESKTOP-G004QAU; Database = UserRegitration;
                Integrated Security = true; TrustServerCertificate=True";


        private IHostingEnvironment Environment;
        //private IHostingEnvironment _ihe;

        //public RegController(IHostingEnvironment ihe)
        //{
        //    ihe = ihe;
        //}

        CheckDataValidityRepo _checkData = new CheckDataValidityRepo();

        public RegController(IHostingEnvironment _environment)
        {
            Environment = _environment;
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
            try
            {
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
            catch {
                return countries;
            }

            
        }

        public List<City> LoadCity()
        {
            List<City> cities = new List<City>();
            try
            {
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
            catch {
                return cities;
            }
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Registration userRegistration, IFormFile userImg, IFormFile userCV)
        {

            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                //string query = "SELECT * FROM TblUsers where Id = " + userRegistration.Id + "";


                string maxSqlQuery = "SELECT MAX(Id) FROM TblUsers";
                SqlCommand sqlCommand = new SqlCommand(maxSqlQuery, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                double maxId;

                //DataTable dataTable = new DataTable();
                //int isFill = sqlDataAdapter.Fill(dataTable);


                //var checkType = sqlCommand.ExecuteScalar().GetType();
                string numrows = Convert.ToString(sqlCommand.ExecuteScalar());
                if (numrows != "")
                {
                    maxId = Convert.ToInt32(sqlCommand.ExecuteScalar());
                }
                else
                {
                    maxId = 1;
                }

                //if (dataTable.Rows.Count > 0)
                //{
                //    maxId = int.Parse(dataTable.Rows[0][0].ToString());
                //}
                //else
                //{
                //    maxId = 1;
                //}

                double tmpMaxId = maxId;

                if (userRegistration.Gender == "male")
                {
                    if (maxId % 2 == 0)
                    {
                        if (tmpMaxId == maxId)
                        {
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
                    double checkInitial = maxId + 1;
                    maxId = maxId + 5;
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


                //if (maxId == userRegistration.Id)
                //{
                //    ViewBag.registered = "Already registered user..";
                //    return View(userRegistration);
                //}


                string wwwPath = this.Environment.WebRootPath;
                string contentPath = this.Environment.ContentRootPath;


                if (userImg != null && userImg.Length > 0)
                {
                    var file = userImg;
                    //var uploads = Path.Combine("images", Path.GetFileName(userImg.FileName));
                    var uploads = Path.Combine(wwwPath + "/files", Path.GetFileName(userImg.FileName));
                    await userImg.CopyToAsync(new FileStream(uploads, FileMode.Create));
                    userRegistration.userImg = "files/" + userImg.FileName;
                }

                if (userCV != null && userCV.Length > 0)
                {
                    var file = userCV;
                    var uploads = Path.Combine(wwwPath + "/files", Path.GetFileName(userCV.FileName));
                    await userCV.CopyToAsync(new FileStream(uploads, FileMode.Create));
                    userRegistration.userCV = "files/" + userCV.FileName;
                }

                if (userCV == null)
                {
                    //userRegistration.userImg = "images/notfound.jpg";
                    ViewBag.NoFoundImage = "No Found CV";
                }


                bool isExistDuplicatePhone = _checkData.IsExistDuplicatePhone(userRegistration.phoneNo);
                if (isExistDuplicatePhone)
                {
                    TempData["existDuplicate"] = "Phone number Already Exist..";
                    return RedirectToAction("UserList", "Home");
                }
                else
                {
                    TempData["existDuplicate"] = "";
                }

                bool isExistDuplicateEmail = _checkData.IsExistDuplicateMail(userRegistration.emailNo);
                if (isExistDuplicateEmail)
                {
                    TempData["existDuplicate"] = "Email Already Exist..";
                    return RedirectToAction("UserList", "Home");
                }
                else
                {
                    TempData["existDuplicate"] = "";
                }


                string strInsertSql = "INSERT INTO TblUsers(Id,fName, lName,phoneNo,emailNo,userCity,userImg, userCV, password,dob,Gender)" +
                        "VALUES(" + userRegistration.Id + ",'" + userRegistration.fName + "','" + userRegistration.lName + "','" + userRegistration.phoneNo + "','" + userRegistration.emailNo + "'," + userRegistration.userCity + "," +
                        "'" + userRegistration.userImg + "','" + userRegistration.userCV + "','" + userRegistration.password + "','" + userRegistration.dob + "','" + userRegistration.Gender + "')";
                SqlCommand sqlCommand3 = new SqlCommand(strInsertSql, sqlConnection);

                int isExecute = sqlCommand3.ExecuteNonQuery();
                if (isExecute > 0)
                {
                    TempData["save"] = "Product has been Saved Successfully.";
                }
                sqlConnection.Close();

                return RedirectToAction("UserList", "Home");
            }
            catch {
                return RedirectToAction("UserList", "Home");
            }
           
        }



        public async Task<IActionResult> Download(string filename)
        {
            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot", filename);

            var memory = new MemoryStream();


            try
            {
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }

            }
            catch (IOException ioex)
            {

            }
            catch (Exception ex)
            {

            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }


        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }


        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }


        


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRecord(Registration userRegistration, IFormFile userImg, IFormFile userCV)
        {

            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
    
                string wwwPath = this.Environment.WebRootPath;
                string contentPath = this.Environment.ContentRootPath;

                if (userImg != null && userImg.Length > 0)
                {
                    var file = userImg;
                    //var uploads = Path.Combine("images", Path.GetFileName(userImg.FileName));
                    var uploads = Path.Combine(wwwPath + "/files", Path.GetFileName(userImg.FileName));
                    await userImg.CopyToAsync(new FileStream(uploads, FileMode.Create));
                    userRegistration.userImg = "files/" + userImg.FileName;
                }
                else
                {
                    string getImageFileName = _checkData.GetImageFileName(userRegistration.Id);
                    userRegistration.userImg = getImageFileName;
                }

                if (userCV != null && userCV.Length > 0)
                {
                    var file = userCV;
                    var uploads = Path.Combine(wwwPath + "/files", Path.GetFileName(userCV.FileName));
                    await userCV.CopyToAsync(new FileStream(uploads, FileMode.Create));
                    userRegistration.userCV = "files/" + userCV.FileName;
                }
                else
                {
                    string getCVFileName = _checkData.GetCVFileName(userRegistration.Id);
                    userRegistration.userCV = getCVFileName;
                }

                if (userCV == null)
                {
                    //userRegistration.userImg = "images/notfound.jpg";
                    ViewBag.NoFoundImage = "No Found CV";
                }

                string strInsertSql = "UPDATE TblCity SET CountryId = "+ userRegistration .countryName
                    + " WHERE CountryId = "+userRegistration.countryName + "";
                string updateSql = "UPDATE TblUsers SET fName = '"+userRegistration.fName+"', lName = '"+userRegistration.lName+"', phoneNo = '"+userRegistration.phoneNo+"',emailNo = '"+userRegistration.emailNo+"', userCity = "+userRegistration.userCity + ",userImg = '"+userRegistration.userImg+"',userCV = '"+userRegistration.userCV+"',password = '"+userRegistration.password+"', dob = '"+userRegistration.dob+"',Gender = '"+userRegistration.Gender+"' WHERE Id = " + userRegistration.Id + "";

                SqlCommand sqlCommand = new SqlCommand(strInsertSql, sqlConnection);
                int isExecute = sqlCommand.ExecuteNonQuery();
                if (isExecute > 0)
                {
                    SqlCommand sqlCommand1 = new SqlCommand(updateSql, sqlConnection);
                    int executeUpdateQuery = sqlCommand1.ExecuteNonQuery();
                    if (executeUpdateQuery > 0) {
                        TempData["save"] = "Product has been Updatesd Successfully.";
                    }
                }
                sqlConnection.Close();

                return RedirectToAction("UserList", "Home");
            }
            catch
            {
                return RedirectToAction("UserList", "Home");
            }

        }

    }
}
