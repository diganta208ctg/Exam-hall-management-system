using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamHallManagentSystemApp.DAL.Models
{
    public class SubjectRegistration
    {

        public int Id { get; set; }
        public int Student { get; set; }

        public int Course { get; set; }
    }
}