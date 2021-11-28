using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMngt.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string Firstname{ get; set; }
        public string Lastname{ get; set; }
        public string IdNumber { get; set; }
        public string ImagePath { get; set; }
    }
}
