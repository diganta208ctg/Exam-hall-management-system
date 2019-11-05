using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using ExamHallManagentSystemApp.DAL.Models;

namespace ExamHallManagentSystemApp.DAL.Gateway
{
    public class TeacherGateWay
    {

         private SqlConnection connection;

        private SqlCommand command;

        private SqlDataReader reader;

        public TeacherGateWay()
        {
            string conString = WebConfigurationManager.ConnectionStrings["ExamHallManegementDBConnectionString"].ConnectionString;
            connection = new SqlConnection(conString);
        }

        public List<DepartmentInfo> GetAllDepartment()
        {

            string query = "SELECT * FROM DepartmentInfo";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<DepartmentInfo> DepartmentList = new List<DepartmentInfo>();

            while (reader.Read())
            {
                DepartmentInfo aDepartmentInfo = new DepartmentInfo();
                aDepartmentInfo.Id = Convert.ToInt32(reader["id"]);
                aDepartmentInfo.Name = reader["Name"].ToString();
                aDepartmentInfo.Code = reader["Code"].ToString();

                DepartmentList.Add(aDepartmentInfo);

            }
            connection.Close();
            return DepartmentList;
        }

        public int SaveTeacher(TeacherInfo aTeacherInfo)
        {

            string query = "INSERT INTO TeacherInfo VALUES('" + aTeacherInfo.Code + "','" + aTeacherInfo.Department + "','" + aTeacherInfo.Password + "')";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }


        public bool IsTeacherExsists(string Code)
        {

            string query = "SELECT * FROM TeacherInfo WHERE Code='" + Code + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            bool IsExsists = reader.HasRows;
            connection.Close();
            return IsExsists;
        }


        public TeacherInfo GetTeacher(string TeacherId)
        {

            string query = "SELECT * FROM TeacherInfo WHERE Code='" + TeacherId + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();

            TeacherInfo aTeacherInfo = new TeacherInfo();
            while (reader.Read())
            {

                aTeacherInfo.Id = Convert.ToInt32(reader["Id"]);
                aTeacherInfo.Code = reader["Code"].ToString();


                aTeacherInfo.Password = reader["Password"].ToString();
            }
            connection.Close();
            return aTeacherInfo;
        }
    }
}