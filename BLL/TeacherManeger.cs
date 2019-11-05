using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamHallManagentSystemApp.DAL.Models;
using ExamHallManagentSystemApp.DAL.Gateway;

namespace ExamHallManagentSystemApp.BLL
{
    public class TeacherManeger
    {
        TeacherGateWay aTeacherGateWay = new TeacherGateWay();
        public string SaveTeacher(TeacherInfo aTeacherInfo)
        {
            if(aTeacherGateWay.IsTeacherExsists(aTeacherInfo.Code))
            {
                return "Already Registered";
            }

            else
            {
                int rowAffect = aTeacherGateWay.SaveTeacher(aTeacherInfo);
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

              public List<DepartmentInfo> GetAllDepartment()
              {
                  return aTeacherGateWay.GetAllDepartment();
              }
             public bool IsTeacherExsists(string Code)
              {
                  return aTeacherGateWay.IsTeacherExsists(Code);
              }
           public TeacherInfo GetTeacher(string TeacherId)
             {
                 return aTeacherGateWay.GetTeacher(TeacherId);
             }
        
    }
}