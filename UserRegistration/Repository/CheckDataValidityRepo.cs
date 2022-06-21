using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using UserRegistration.Models;

namespace UserRegistration.Repository
{
    public class CheckDataValidityRepo
    {

        string connectionString = @"Server = DESKTOP-G004QAU; Database = UserRegitration;
                Integrated Security = true; TrustServerCertificate=True";


        public bool IsExistDuplicateMail(string email)
        {
            bool ExistDuplicate = false;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string query = "select * from TblUsers where emailNo =  '" + email + "'";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            int isFill = sqlDataAdapter.Fill(dataTable);

            if (isFill > 0)
            {
                ExistDuplicate = true;
            }
            return ExistDuplicate;
        }

        public bool IsExistDuplicatePhone(string phone)
        {
            bool ExistDuplicate = false;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string query = "select * from TblUsers where phoneNo =  '" + phone + "'";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            int isFill = sqlDataAdapter.Fill(dataTable);

            if (isFill > 0)
            {
                ExistDuplicate = true;
            }
            return ExistDuplicate;
        }

    }
}
