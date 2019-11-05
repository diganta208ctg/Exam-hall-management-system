using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamHallManagentSystemApp.DAL.Models;
using ExamHallManagentSystemApp.DAL.Gateway;

namespace ExamHallManagentSystemApp.BLL
{
    public class UnAssignStudentManeger
    {
        UnassignStudentGateWay aUnassignStudentGateWay = new UnassignStudentGateWay();

          public List<SeatInfo> GetAllSeatInfo(string Action)
        {
            return aUnassignStudentGateWay.GetAllSeatInfo(Action);
        }

         public string UpdateSeatInfo(int Id, string action)
          {
              int rowAffect = aUnassignStudentGateWay.UpdateSeatInfo(Id, action);
              if (rowAffect > 0)
              {
                  return "Unassign Successfull";
              }
              else
              {
                  return "Unassigned Failed";
              }
             
          }

         public bool IsSeatExsists( string action)
         {
             return aUnassignStudentGateWay.IsSeatExsists(action);
         }
    }
}