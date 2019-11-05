using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamHallManagentSystemApp.DAL.Models;
using ExamHallManagentSystemApp.DAL.Gateway;

namespace ExamHallManagentSystemApp.BLL
{
    public class AssignTeacherManeger
    {

        AssignTeacherGateWay aAssignTeacherGateWay = new AssignTeacherGateWay();

        public string SaveTeacherInfo(AssignTeacher aAssignTeacher, ReserveHall aReserveHall)
        {

            if (aReserveHall.Teacher > 0)
            {
            int newTeacher = aReserveHall.Teacher - 1;
                int rowAffect = aAssignTeacherGateWay.UpdateHallInfo(aReserveHall.Id, newTeacher);
                if (rowAffect > 0)
                {
                    int Affect = aAssignTeacherGateWay.SaveTeacherInfo(aAssignTeacher);
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
          public bool IsTeacherExsists(int Teacher, string action)
        {
            return aAssignTeacherGateWay.IsTeacherExsists(Teacher, action);
        }
       public bool IsRoomExsists(DateTime Date)
        {
            return aAssignTeacherGateWay.IsRoomExsists(Date);
        }

         public List<TeacherInfo> GetAllTeacher()
       {
           return aAssignTeacherGateWay.GetAllTeacher();
       }

         public List<ReserveHall> GetAllHall(DateTime date)
         {
             return aAssignTeacherGateWay.GetAllHall(date);
         }
    }
}