using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamHallManagentSystemApp.DAL.Models;
using ExamHallManagentSystemApp.DAL.Gateway;

namespace ExamHallManagentSystemApp.BLL
{
    public class SeatInfoManeger
    {
        SeatInfoGateWay aSeatInfoGateWay = new SeatInfoGateWay();
        public string SaveSeatInfo(SeatInfo aSeatInfo, ReserveHall aReserveHall)
        {
            if (aReserveHall.AvailableSeat > 0)
            {
                int newAvailableSeat = aReserveHall.AvailableSeat - 1;
                int rowAffect = aSeatInfoGateWay.UpdateHallInfo(aReserveHall.Id, newAvailableSeat);
                if (rowAffect > 0)
                {
                    int Affect = aSeatInfoGateWay.SaveSeatInfo(aSeatInfo);
                    if (Affect > 0)
                    {
                        return "Save Successfull";
                    }
                    else
                    {
                        return "Failed";
                    }
                }
                else
                {
                    return "Failed";
                }
            }
            else
            {
                return "Not avaiable Seat";
            }
        }
    
          public List<Course> GetAllCourse()
         {
             return aSeatInfoGateWay.GetAllCourse();
         }

         public List<ReserveHall> GetAllHall(DateTime date)
          {
              return aSeatInfoGateWay.GetAllHall(date);
          }

            public List<SubjectRegistration> GetAllStudentBySubject(int subjectId)
         {
             return aSeatInfoGateWay.GetAllStudentBySubject(subjectId);
         }
         public bool IsStudentExsists(SubjectRegistration aStudent, string action)
            {
                return aSeatInfoGateWay.IsStudentExsists(aStudent, action);
            }

         public bool IsRoomExsists(DateTime Date)
         {
             return aSeatInfoGateWay.IsRoomExsists(Date);
         }
    }
}