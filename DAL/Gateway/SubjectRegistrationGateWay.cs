using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using ExamHallManagentSystemApp.DAL.Models;

namespace ExamHallManagentSystemApp.DAL.Gateway
{
    public class SubjectRegistrationGateWay
    {
         private SqlConnection connection;

        private SqlCommand command;

        private SqlDataReader reader;

        public SubjectRegistrationGateWay()
        {
            string conString = WebConfigurationManager.ConnectionStrings["ExamHallManegementDBConnectionString"].ConnectionString;
            connection = new SqlConnection(conString);
        }


        public int SaveSubjectRegistration(SubjectRegistration aSubjectRegistration)
        {

            string query = "INSERT INTO SubjectTaken VALUES('" + aSubjectRegistration.Student + "','" + aSubjectRegistration.Course + "')";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }
        public List<Course> GetAllCourse()
        {

            string query = "SELECT * FROM Course";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<Course> CourseList = new List<Course>();

            while (reader.Read())
            {
                Course aCourse = new Course();
                aCourse.Id = Convert.ToInt32(reader["id"]);
                aCourse.CourseId = reader["CourseId"].ToString();

                aCourse.CourseName = reader["CourseName"].ToString();
                aCourse.Credit = Convert.ToInt32(reader["Credit"]);

                CourseList.Add(aCourse);

            }
            connection.Close();
            return CourseList;
        }
    }
}