using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamHallManagentSystemApp.DAL.Models
{
    public class RoomInfo
    {

        public int Id { get; set; }
        public string Code { get; set; }
        public int Building { get; set; }
        public int Seat { get; set; }
    }
}