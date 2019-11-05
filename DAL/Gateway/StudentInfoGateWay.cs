using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using ExamHallManagentSystemApp.DAL.Models;


namespace ExamHallManagentSystemApp.DAL.Gateway
{
    public class StudentInfoGateWay
    {

         private SqlConnection connection;

        private SqlCommand command;

        private SqlDataReader reader;

        public StudentInfoGateWay()
        {
            string conString = WebConfigurationManager.ConnectionStrings["ExamHallManegementDBConnectionString"].ConnectionString;
            connection = new SqlConnection(conString);
        }

        public int SaveStudent(StudentInfo aStudentInfo)
        {

            string query = "INSERT INTO StudentInfo VALUES('" + aStudentInfo.StudentId + "','" + aStudentInfo.Name + "','" + aStudentInfo.Password + "')";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }


        public bool IsStudentExsists(string studentId)
        {

            string query = "SELECT * FROM StudentInfo WHERE StudentId='" + studentId + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            bool IsExsists = reader.HasRows;
            connection.Close();
            return IsExsists;
        }



        public StudentInfo GetStudent(string studentId)
        {

            string query = "SELECT * FROM StudentInfo WHERE StudentId='" + studentId + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();

            StudentInfo aStudentInfo = new StudentInfo();
            while (reader.Read())
            {
              
                aStudentInfo.Id = Convert.ToInt32(reader["Id"]);
                aStudentInfo.Name = reader["Name"].ToString();

                aStudentInfo.StudentId = reader["StudentId"].ToString();
                aStudentInfo.Password = reader["Password"].ToString();

              

            }
            connection.Close();
            return aStudentInfo;
        }
    }
}