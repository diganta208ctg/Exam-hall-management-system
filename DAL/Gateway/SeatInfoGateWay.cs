using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using ExamHallManagentSystemApp.DAL.Models;

namespace ExamHallManagentSystemApp.DAL.Gateway
{
    public class SeatInfoGateWay
    {
        private SqlConnection connection;

        private SqlCommand command;

        private SqlDataReader reader;

        public SeatInfoGateWay()
        {
            string conString = WebConfigurationManager.ConnectionStrings["ExamHallManegementDBConnectionString"].ConnectionString;
            connection = new SqlConnection(conString);
        }

        public int SaveSeatInfo(SeatInfo aSeatInfo)
        {

            string query = "INSERT INTO SeatPlan VALUES('" + aSeatInfo.Student + "','" + aSeatInfo.Course + "','" + aSeatInfo.Room + "','" + aSeatInfo.Building + "','" + aSeatInfo.Date + "','" + aSeatInfo.Action + "')";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }


        public int UpdateHallInfo(int Id, int AvailableSeat)
        {

            string query = "UPDATE ReserveHall SET AvailableSeat='" + AvailableSeat + "' WHERE Id='" + Id + "'";
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


        public bool IsStudentExsists(SubjectRegistration aStudent, string action)
        {

            string query = "SELECT * FROM SeatPlan WHERE Student='" + aStudent.Student + "' AND Action='" + action + "' AND Course='" + aStudent.Course + "'";
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

            string query = "SELECT * FROM ReserveHall WHERE Date='"+date+"'";
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

                HallList.Add(aReserveHall);

            }
            connection.Close();
            return HallList;
        }

        public List<SubjectRegistration> GetAllStudentBySubject(int subjectId)
        {

            string query = "SELECT * FROM SubjectTaken WHERE Course='" + subjectId + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<SubjectRegistration> StudentList = new List<SubjectRegistration>();

            while (reader.Read())
            {
                SubjectRegistration aStudent = new SubjectRegistration();
                aStudent.Id = Convert.ToInt32(reader["id"]);
                aStudent.Student = Convert.ToInt32(reader["Student"]);

                aStudent.Course = Convert.ToInt32(reader["Course"]);


                StudentList.Add(aStudent);

            }
            connection.Close();
            return StudentList;
        }
    }
}