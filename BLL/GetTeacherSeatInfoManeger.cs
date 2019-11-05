using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamHallManagentSystemApp.DAL.Models;
using ExamHallManagentSystemApp.DAL.Gateway;
using ExamHallManagentSystemApp.DAL.Models.ViewModel;

namespace ExamHallManagentSystemApp.BLL
{
    public class GetTeacherSeatInfoManeger
    {


        TeacherSeatInfoGateWay aTeacherSeatInfoGateWay= new TeacherSeatInfoGateWay();
        
        public TeacherInfoViewModel GetTeacherSeatInfoById(int Teacher, DateTime Date)
        {
            return aTeacherSeatInfoGateWay.GetTeacherSeatInfoById(Teacher, Date);
        }
    }
}