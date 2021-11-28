using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMngt.Models
{
    public class ContactType
    {
        [Key]
        public int ContactTypeId { get; set; }
        public string SelectedType { get; set; } //Cell, Email, Address, Social Media Detail
    }
}
