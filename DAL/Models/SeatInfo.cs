using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamHallManagentSystemApp.DAL.Models
{
    public class SeatInfo
    {

        public int Id { get; set; }

        public int Course { get; set; }
        public int Student { get; set; }
        public int Room { get; set; }
        public int Building { get; set; }
        public DateTime Date { get; set; }
        public string Action { get; set; }
     
    }
}