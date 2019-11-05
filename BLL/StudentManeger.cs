using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamHallManagentSystemApp.DAL.Models;
using ExamHallManagentSystemApp.DAL.Gateway;

namespace ExamHallManagentSystemApp.BLL
{
    public class StudentManeger
    {
        StudentInfoGateWay aStudentInfoGateWay = new StudentInfoGateWay();
        public string SaveAdmin(StudentInfo aStudentInfo)
        {

            if (aStudentInfoGateWay.IsStudentExsists(aStudentInfo.StudentId))
            {
                return "Already registered";
            }

            else
            {
                int rowAffect = Convert.ToInt32(aStudentInfoGateWay.SaveStudent(aStudentInfo));
                if (rowAffect > 0)
                {
                    return "Save successfully";
                }
                else
                {
                    return "Save failed";
                }
            }

        }
         public bool IsStudentExsists(string studentId)
        {
            return aStudentInfoGateWay.IsStudentExsists(studentId);
        }

          public StudentInfo GetStudent(string studentId)
        {
            return aStudentInfoGateWay.GetStudent(studentId);
        }
    }
}