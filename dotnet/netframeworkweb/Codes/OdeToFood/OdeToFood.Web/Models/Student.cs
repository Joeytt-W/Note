﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OdeToFood.Web.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public decimal TotalScore { get; set; }
    }
}