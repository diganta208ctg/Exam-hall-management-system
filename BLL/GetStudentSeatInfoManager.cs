using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamHallManagentSystemApp.DAL.Models;
using ExamHallManagentSystemApp.DAL.Gateway;
using ExamHallManagentSystemApp.DAL.Models.ViewModel;


namespace ExamHallManagentSystemApp.BLL
{
    public class GetStudentSeatInfoManager
    {
        GetStudentSeatInfoGateWay aGetStudentSeatInfoGateWay = new GetStudentSeatInfoGateWay();
    

          public List<CourseViewModel> GetAllCourseByStudentId(int Student)
        {
            return aGetStudentSeatInfoGateWay.GetAllCourseByStudentId(Student);
        }

            public StudentInfoViewModel GetSeatInfoByStudentId(int Student,int Course, string action)
          {
              return aGetStudentSeatInfoGateWay.GetSeatInfoByStudentId(Student,Course, action);
          }
    }
}