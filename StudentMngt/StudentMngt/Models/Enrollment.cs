using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMngt.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }
        public string Institution { get; set; }
        public string Qualification { get; set; }
        public string QualificationType { get; set; } //enum data (or hard coded from UI)
        public string DateRegistered { get; set; }
        public string GraduationDate { get; set; }
        public string AverageToDate { get; set; }
    }
}
