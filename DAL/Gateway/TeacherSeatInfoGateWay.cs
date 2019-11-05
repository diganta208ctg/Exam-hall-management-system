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
    public class TeacherSeatInfoGateWay
    {

          private SqlConnection connection;

        private SqlCommand command;

        private SqlDataReader reader;

        public TeacherSeatInfoGateWay()
        {
            string conString = WebConfigurationManager.ConnectionStrings["ExamHallManegementDBConnectionString"].ConnectionString;
            connection = new SqlConnection(conString);
        }


        public TeacherInfoViewModel GetTeacherSeatInfoById(int Teacher, DateTime Date)
        {
            string query = "SELECT TeacherInfo.Code as TeacherId,BuildingInfo.Name as BuildingName,RoomInfo.Code as RoomCode FROM Assign_Teacher  INNER JOIN TeacherInfo   ON Assign_Teacher.TeacherId=TeacherInfo.Id INNER JOIN BuildingInfo ON Assign_Teacher.Building=BuildingInfo.Id INNER JOIN RoomInfo On Assign_Teacher.Room=RoomInfo.Id WHERE TeacherId='" + Teacher + "' AND Date='"+Date+"'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            TeacherInfoViewModel aTeacherInfoViewModel = new TeacherInfoViewModel();

            if (reader.Read())
            {

                aTeacherInfoViewModel.Code = reader["Code"].ToString();
                aTeacherInfoViewModel.BuildingName = reader["BuildingName"].ToString();
                aTeacherInfoViewModel.RoomCode = reader["RoomCode"].ToString();
            


            }
            connection.Close();
            return aTeacherInfoViewModel;
        }
    }
}