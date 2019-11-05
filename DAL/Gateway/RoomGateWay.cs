using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using ExamHallManagentSystemApp.DAL.Models;

namespace ExamHallManagentSystemApp.DAL.Gateway
{
    public class RoomGateWay
    {

        private SqlConnection connection;

        private SqlCommand command;

        private SqlDataReader reader;

        public RoomGateWay()
        {
            string conString = WebConfigurationManager.ConnectionStrings["ExamHallManegementDBConnectionString"].ConnectionString;
            connection = new SqlConnection(conString);
        }

        public int SaveRoom(RoomInfo aRoomInfo)
        {

            string query = "INSERT INTO RoomInfo VALUES('" + aRoomInfo.Code + "','" + aRoomInfo.Building+ "','" +aRoomInfo.Seat+ "')";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }


        public bool IsRoomExsists(string Code)
        {

            string query = "SELECT * FROM RoomInfo WHERE Code='" + Code + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            bool IsExsists = reader.HasRows;
            connection.Close();
            return IsExsists;
        }

        public int UpdateRoomInfo(RoomInfo aRoomInfo)
        {

            string query = "UPDATE RoomInfo SET Seat='" + aRoomInfo.Seat + "' WHERE Code='" + aRoomInfo.Code + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public List<BuildingInfo> GetAllBuilding()
        {

            string query = "SELECT * FROM BuildingInfo";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<BuildingInfo> buildingList = new List<BuildingInfo>();

            while (reader.Read())
            {
                BuildingInfo aBuildingInfo = new BuildingInfo();
                aBuildingInfo.Id = Convert.ToInt32(reader["id"]);
                aBuildingInfo.Name = reader["Name"].ToString();
                aBuildingInfo.Room = Convert.ToInt32(reader["Room"]);

                buildingList.Add(aBuildingInfo);
                
            }
            connection.Close();
            return buildingList;
        }
    }
}