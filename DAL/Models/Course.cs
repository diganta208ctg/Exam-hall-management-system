﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamHallManagentSystemApp.DAL.Models
{
    public class Course
    {

        public int Id { get; set; }

        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public int Credit { get; set; }
    }
}