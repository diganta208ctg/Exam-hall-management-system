using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using ExamHallManagentSystemApp.DAL.Models;
using ExamHallManagentSystemApp.DAL.Models.ViewModel;

namespace ExamHallManagentSystemApp.DAL.Gateway
{
    public class GetStudentSeatInfoGateWay
    {

        
         private SqlConnection connection;

        private SqlCommand command;

        private SqlDataReader reader;

        public GetStudentSeatInfoGateWay()
        {
            string conString = WebConfigurationManager.ConnectionStrings["ExamHallManegementDBConnectionString"].ConnectionString;
            connection = new SqlConnection(conString);
        }


        public List<CourseViewModel> GetAllCourseByStudentId(int Student)
        {

            string query = "SELECT SubjectTaken.Course,Course.CourseId FROM SubjectTaken INNER JOIN Course ON SubjectTaken.Course=Course.Id WHERE Student='" + Student + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<CourseViewModel> CourseList = new List<CourseViewModel>();

            while (reader.Read())
            {
                CourseViewModel aCourseViewModel = new CourseViewModel();
                aCourseViewModel.Id = Convert.ToInt32(reader["Course"]);
                aCourseViewModel.CourseCode = reader["CourseId"].ToString();

                CourseList.Add(aCourseViewModel);

            }
            connection.Close();
            return CourseList;
        }


          public StudentInfoViewModel GetSeatInfoByStudentId(int Student,int Course ,string action)
        {
            string query = "SELECT StudentInfo.StudentId,StudentInfo.Name AS StudentName,RoomInfo.Code AS RoomCode,BuildingInfo.Name AS BuildingName FROM SeatPlan INNER JOIN StudentInfo ON SeatPlan.Student=StudentInfo.Id INNER JOIN BuildingInfo On SeatPlan.Building=BuildingInfo.Id INNER JOIN RoomInfo On SeatPlan.Room=RoomInfo.Id WHERE Student='" + Student + "' AND Course='" + Course + "' AND Action='" + action + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            StudentInfoViewModel aStudentInfoViewModel = new StudentInfoViewModel();

            if (reader.Read())
            {
               
                aStudentInfoViewModel.StudentId = reader["StudentId"].ToString();
                aStudentInfoViewModel.StudentName = reader["StudentName"].ToString();
                aStudentInfoViewModel.RoomCode = reader["RoomCode"].ToString();
                aStudentInfoViewModel.BuildingName = reader["BuildingName"].ToString();
               
              
            }
            connection.Close();
            return aStudentInfoViewModel;
        }
    }
}