using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using ExamHallManagentSystemApp.DAL.Models;

namespace ExamHallManagentSystemApp.DAL.Gateway
{
    public class BuildingGateWay
    {
       private SqlConnection connection;

        private SqlCommand command;

        private SqlDataReader reader;

        public BuildingGateWay()
        {
            string conString = WebConfigurationManager.ConnectionStrings["ExamHallManegementDBConnectionString"].ConnectionString;
            connection = new SqlConnection(conString);
        }

        public int SaveBuilding(BuildingInfo aBuildingInfo)
        {

            string query = "INSERT INTO BuildingInfo VALUES('" + aBuildingInfo.Name + "','" + aBuildingInfo.Room + "')";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public bool IsBuildingExsists(string Name)
        {

            string query = "SELECT * FROM BuildingInfo WHERE Name='" + Name + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            bool IsExsists = reader.HasRows;
            connection.Close();
            return IsExsists;
        }

        public int UpdateBuildingInfo(BuildingInfo aBuildingInfo)
        {

            string query = "UPDATE BuildingInfo SET Room='" + aBuildingInfo.Room + "' WHERE Name='"+aBuildingInfo.Name+"'";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }
    }
}