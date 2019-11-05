using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamHallManagentSystemApp.DAL.Models
{
    public class AssignTeacher
    {

        public int Id { get; set; }

        public int TeacherId { get; set; }
        public int Building { get; set; }
        public int Room { get; set; }
      
        public DateTime Date { get; set; }
        public string Action { get; set; }
    }
}