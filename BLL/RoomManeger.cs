using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamHallManagentSystemApp.DAL.Models;
using ExamHallManagentSystemApp.DAL.Gateway;


namespace ExamHallManagentSystemApp.BLL
{
    public class RoomManeger
    {
        RoomGateWay aRoomGateWay = new RoomGateWay();

          public string SaveRoom(RoomInfo aRoomInfo)
        {
              if(aRoomGateWay.IsRoomExsists(aRoomInfo.Code))
              {
                  int rowAffect = aRoomGateWay.UpdateRoomInfo(aRoomInfo);
                  if (rowAffect > 0)
                  {
                      return "Update Successfull";
                  }
                  else
                  {
                      return "Update Failed";
                  }
              }

              else
              {
                  int rowAffect = aRoomGateWay.SaveRoom(aRoomInfo);
                  if (rowAffect > 0)
                  {
                      return "Save Successfull";
                  }
                  else
                  {
                      return "Save failed";
                  }
              }
           
        }


            public List<BuildingInfo> GetAllBuilding()
          {
              return aRoomGateWay.GetAllBuilding();
          }
    }
}