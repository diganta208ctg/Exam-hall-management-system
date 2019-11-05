using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using ExamHallManagentSystemApp.DAL.Models;

namespace ExamHallManagentSystemApp.DAL.Gateway
{
    public class ReserveHallGateWay
    {

        
         private SqlConnection connection;

        private SqlCommand command;

        private SqlDataReader reader;

        public ReserveHallGateWay()
        {
            string conString = WebConfigurationManager.ConnectionStrings["ExamHallManegementDBConnectionString"].ConnectionString;
            connection = new SqlConnection(conString);
        }

        public int GetRoom(ReserveHall aReserveHall)
        {

            string query = "INSERT INTO ReserveHall VALUES('" + aReserveHall.Room + "','" + aReserveHall.Building + "','" + aReserveHall.AvailableSeat + "','" + aReserveHall.Teacher + "','" + aReserveHall.Date + "')";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }


        public bool IsDateExsists(DateTime Date)
        {

            string query = "SELECT * FROM ReserveHall WHERE Date='" + Date + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            bool IsExsists = reader.HasRows;
            connection.Close();
            return IsExsists;
        }
        public List<RoomInfo> GetAllRoom()
        {

            string query = "SELECT * FROM RoomInfo";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<RoomInfo> roomList = new List<RoomInfo>();

            while (reader.Read())
            {
                RoomInfo aRoomInfo = new RoomInfo();
                aRoomInfo.Id = Convert.ToInt32(reader["id"]);
                aRoomInfo.Code = reader["Code"].ToString();
                aRoomInfo.Building = Convert.ToInt32(reader["Building"]);
                aRoomInfo.Seat = Convert.ToInt32(reader["Seat"]);

                roomList.Add(aRoomInfo);

            }
            connection.Close();
            return roomList;
        }
    }
}