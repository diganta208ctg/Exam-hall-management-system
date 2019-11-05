using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamHallManagentSystemApp.DAL.Models;
using ExamHallManagentSystemApp.DAL.Gateway;


namespace ExamHallManagentSystemApp.BLL
{
    public class CourseManeger
    {

        CorseGateWay aCourseGateWay = new CorseGateWay();

        public string SaveCourse(Course aCourse)
        {
            if (aCourseGateWay.IsCourseExsists(aCourse.CourseId))
            {
                return "Course already exists";
            }

            else
            {
                int rowAffect = aCourseGateWay.SaveCourse(aCourse);
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
    }
}