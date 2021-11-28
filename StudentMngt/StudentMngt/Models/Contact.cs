using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMngt.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public int ContactTypeId { get; set; } //links to the other table
        public int StudentId { get; set; }
        public string ContactDescription { get; set; }
    }
}
