using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using ExamHallManagentSystemApp.DAL.Models;

namespace ExamHallManagentSystemApp.DAL.Gateway
{
    public class UnassignStudentGateWay
    {

        
         private SqlConnection connection;

        private SqlCommand command;

        private SqlDataReader reader;

        public UnassignStudentGateWay()
        {
            string conString = WebConfigurationManager.ConnectionStrings["ExamHallManegementDBConnectionString"].ConnectionString;
            connection = new SqlConnection(conString);
        }


        public int UpdateSeatInfo(int Id, string action)
        {

            string query = "UPDATE SeatPlan SET Action='" + action + "' WHERE Id='" + Id + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public bool IsSeatExsists( string action)
        {

            string query = "SELECT * FROM SeatPlan WHERE Action='" + action + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            bool IsExsists = reader.HasRows;
            connection.Close();
            return IsExsists;
        }
        public List<SeatInfo> GetAllSeatInfo(string Action)
        {

            string query = "SELECT * FROM SeatPlan WHERE Action='" + Action + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<SeatInfo> SeatInfoList = new List<SeatInfo>();

            while (reader.Read())
            {
                SeatInfo aSeatInfo = new SeatInfo();
                aSeatInfo.Id = Convert.ToInt32(reader["id"]);


                SeatInfoList.Add(aSeatInfo);

            }
            connection.Close();
            return SeatInfoList;
        }

    }
}