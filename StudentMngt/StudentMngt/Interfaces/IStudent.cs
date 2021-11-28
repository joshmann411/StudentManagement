using Microsoft.AspNetCore.Mvc;
using StudentMngt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMngt.Interfaces
{
    public interface IStudent
    {
        JsonResult GetStudents();
        JsonResult GetStudent(int studentId);
        JsonResult CreateStudent(Student student);
        JsonResult UpdateStudent(Student studentChanges);
        JsonResult DeleteStudent(int studentId);

    }
}
