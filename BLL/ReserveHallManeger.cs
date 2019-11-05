using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamHallManagentSystemApp.DAL.Models;
using ExamHallManagentSystemApp.DAL.Gateway;

namespace ExamHallManagentSystemApp.BLL
{
    public class ReserveHallManeger
    {
        ReserveHallGateWay aReserveHallGateWay = new ReserveHallGateWay();
        public string GetRoom(ReserveHall aReserveHall)
        {

            
            
                int rowAffect = aReserveHallGateWay.GetRoom(aReserveHall);
                if (rowAffect > 0)
                {
                    return "Save Successfull";
                }
                else
                {
                    return "Save failed";
                }
            
            
        }

            public List<RoomInfo> GetAllRoom()
        {
            return aReserveHallGateWay.GetAllRoom();
        }

             public bool IsDateExsists(DateTime Date)
            {
                return aReserveHallGateWay.IsDateExsists(Date);
            }
    }
}