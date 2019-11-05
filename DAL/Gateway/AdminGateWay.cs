using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using ExamHallManagentSystemApp.DAL.Models;

namespace ExamHallManagentSystemApp.DAL.Gateway
{
    public class AdminGateWay
    {
       private SqlConnection connection;

        private SqlCommand command;

        private SqlDataReader reader;

        public AdminGateWay()
        {
            string conString = WebConfigurationManager.ConnectionStrings["ExamHallManegementDBConnectionString"].ConnectionString;
            connection = new SqlConnection(conString);
        }

        public int SaveAdmin(AdminInfo aAdminInfo)
        {

            string query = "INSERT INTO AdminInfo VALUES('" + aAdminInfo.Code + "','"+aAdminInfo.Name+"','"+aAdminInfo.Password+"')";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public bool IsAdminExsists(string Code)
        {

            string query = "SELECT * FROM AdminInfo WHERE Code='" + Code + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            bool IsExsists = reader.HasRows;
            connection.Close();
            return IsExsists;
        }


        public AdminInfo GetAdmin(string Code)
        {

            string query = "SELECT * FROM AdminInfo WHERE Code='" + Code + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();

            AdminInfo aAdminInfo = new AdminInfo();
            while (reader.Read())
            {

                aAdminInfo.Id = Convert.ToInt32(reader["Id"]);
                aAdminInfo.Name = reader["Name"].ToString();

                aAdminInfo.Code = reader["Code"].ToString();
                aAdminInfo.Password = reader["Password"].ToString();



            }
            connection.Close();
            return aAdminInfo;
        }
    }
}