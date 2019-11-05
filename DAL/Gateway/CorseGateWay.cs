using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using ExamHallManagentSystemApp.DAL.Models;

namespace ExamHallManagentSystemApp.DAL.Gateway
{
    public class CorseGateWay
    {

         private SqlConnection connection;

        private SqlCommand command;

        private SqlDataReader reader;

        public CorseGateWay()
        {
            string conString = WebConfigurationManager.ConnectionStrings["ExamHallManegementDBConnectionString"].ConnectionString;
            connection = new SqlConnection(conString);
        }

        public int SaveCourse(Course aCourse)
        {

            string query = "INSERT INTO Course VALUES('" + aCourse.CourseId + "','" + aCourse.CourseName + "','" + aCourse.Credit + "')";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public bool IsCourseExsists(string Code)
        {

            string query = "SELECT * FROM Course WHERE CourseId='" + Code + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            bool IsExsists = reader.HasRows;
            connection.Close();
            return IsExsists;
        }


    }
}