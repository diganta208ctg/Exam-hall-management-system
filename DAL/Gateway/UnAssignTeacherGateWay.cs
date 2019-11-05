using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using ExamHallManagentSystemApp.DAL.Models;

namespace ExamHallManagentSystemApp.DAL.Gateway
{
    public class UnAssignTeacherGateWay
    {

         private SqlConnection connection;

        private SqlCommand command;

        private SqlDataReader reader;

        public UnAssignTeacherGateWay()
        {
            string conString = WebConfigurationManager.ConnectionStrings["ExamHallManegementDBConnectionString"].ConnectionString;
            connection = new SqlConnection(conString);
        }
        public int UpdateTeacherInfo(int Id, string action)
        {

            string query = "UPDATE Assign_Teacher SET Action='" + action + "' WHERE Id='" + Id + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public bool IsTeacherExsists(string action)
        {

            string query = "SELECT * FROM Assign_Teacher WHERE Action='" + action + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            bool IsExsists = reader.HasRows;
            connection.Close();
            return IsExsists;
        }
        public List<AssignTeacher> GetAllTeacher(string Action)
        {

            string query = "SELECT * FROM Assign_Teacher WHERE Action='" + Action + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<AssignTeacher> TeacherList = new List<AssignTeacher>();

            while (reader.Read())
            {
                AssignTeacher aTeacherInfo = new AssignTeacher();
                aTeacherInfo.Id = Convert.ToInt32(reader["id"]);


                TeacherList.Add(aTeacherInfo);

            }
            connection.Close();
            return TeacherList;
        }

    }
}