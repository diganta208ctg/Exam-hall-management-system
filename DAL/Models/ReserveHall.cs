using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamHallManagentSystemApp.DAL.Models
{
    public class ReserveHall
    {

        public int Id { get; set; }

        public int Room { get; set; }
        public int Building { get; set; }
        public int AvailableSeat { get; set; }

        public DateTime Date { get; set; }

        public int Teacher { get; set; }
    }
}