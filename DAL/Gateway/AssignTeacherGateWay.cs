using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using ExamHallManagentSystemApp.DAL.Models;


namespace ExamHallManagentSystemApp.DAL.Gateway
{
    public class AssignTeacherGateWay
    {

        private SqlConnection connection;

        private SqlCommand command;

        private SqlDataReader reader;

        public AssignTeacherGateWay()
        {
            string conString = WebConfigurationManager.ConnectionStrings["ExamHallManegementDBConnectionString"].ConnectionString;
            connection = new SqlConnection(conString);
        }

        public int SaveTeacherInfo(AssignTeacher aAssignTeacher)
        {

            string query = "INSERT INTO  Assign_Teacher VALUES('" + aAssignTeacher.TeacherId + "','" + aAssignTeacher.Building + "','" + aAssignTeacher.Room + "','" + aAssignTeacher.Action + "','" + aAssignTeacher.Date + "')";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public int UpdateHallInfo(int Id, int Teacher)
        {

            string query = "UPDATE ReserveHall SET Teacher='" + Teacher + "' WHERE Id='" + Id + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public bool IsTeacherExsists(int Teacher, string action)
        {

            string query = "SELECT * FROM Assign_Teacher WHERE TeacherId='" + Teacher + "' AND Action='" + action + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            bool IsExsists = reader.HasRows;
            connection.Close();
            return IsExsists;
        }

        public bool IsRoomExsists(DateTime Date)
        {

            string query = "SELECT * FROM ReserveHall WHERE Date='" + Date + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            bool IsExsists = reader.HasRows;
            connection.Close();
            return IsExsists;
        }

        public List<ReserveHall> GetAllHall(DateTime date)
        {

            string query = "SELECT * FROM ReserveHall WHERE Date='" + date + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<ReserveHall> HallList = new List<ReserveHall>();

            while (reader.Read())
            {
                ReserveHall aReserveHall = new ReserveHall();
                aReserveHall.Id = Convert.ToInt32(reader["id"]);
                aReserveHall.Room = Convert.ToInt32(reader["Room"]);

                aReserveHall.Building = Convert.ToInt32(reader["Building"]);
                aReserveHall.AvailableSeat = Convert.ToInt32(reader["AvailableSeat"]);
                aReserveHall.Teacher = Convert.ToInt32(reader["Teacher"]);
                HallList.Add(aReserveHall);

            }
            connection.Close();
            return HallList;
        }



        public List<TeacherInfo> GetAllTeacher()
        {

            string query = "SELECT * FROM TeacherInfo";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<TeacherInfo> TeacherList = new List<TeacherInfo>();

            while (reader.Read())
            {
                TeacherInfo aTeacher = new TeacherInfo();
                aTeacher.Id = Convert.ToInt32(reader["id"]);
                aTeacher.Code = reader["Code"].ToString();



                TeacherList.Add(aTeacher);

            }
            connection.Close();
            return TeacherList;
        }
    }
}