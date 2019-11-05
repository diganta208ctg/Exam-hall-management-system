using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamHallManagentSystemApp.DAL.Models;
using ExamHallManagentSystemApp.DAL.Gateway;

namespace ExamHallManagentSystemApp.BLL
{
    public class UnAssignTeacherManeger
    {
        UnAssignTeacherGateWay aTeacher = new UnAssignTeacherGateWay();
         public List<AssignTeacher> GetAllTeacher(string Action)
        {
            return aTeacher.GetAllTeacher(Action);
        }
        public bool IsTeacherExsists(string action)
         {
             return aTeacher.IsTeacherExsists(action);
         }

        public string UpdateTeacherInfo(int Id, string action)
        {
            int rowAffect = aTeacher.UpdateTeacherInfo(Id, action);
            if (rowAffect > 0)
            {
                return "Unassign Successfull";
            }
            else
            {
                return "Unassigned Failed";
            }

        }
    }
}