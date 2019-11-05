using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamHallManagentSystemApp.DAL.Models.ViewModel
{
    public class StudentInfoViewModel
    {
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public string RoomCode { get; set; }
        public string BuildingName { get; set; }
    }
}