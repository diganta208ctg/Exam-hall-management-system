using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamHallManagentSystemApp.DAL.Models;
using ExamHallManagentSystemApp.DAL.Gateway;

namespace ExamHallManagentSystemApp.BLL
{
    public class SubjectRegistrationManeger
    {
        SubjectRegistrationGateWay aSubjectRegistrationGateWay = new SubjectRegistrationGateWay();


        public string SaveSubjectRegistration(SubjectRegistration aSubjectRegistration)
        {
            int rowAffect = aSubjectRegistrationGateWay.SaveSubjectRegistration(aSubjectRegistration);
            if (rowAffect > 0)
            {
                return "Save Successfull";
            }
            else
            {
                return "Save failed";
            }
        
        }
            public List<Course> GetAllCourse()
        {
            return aSubjectRegistrationGateWay.GetAllCourse();
        }


    }
}