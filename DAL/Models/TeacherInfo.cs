using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamHallManagentSystemApp.DAL.Models
{
    public class TeacherInfo
    {

        public int Id { get; set; }
        public string Code { get; set; }
        public int Department { get; set; }

        public string Password{ get; set; }
    }
}