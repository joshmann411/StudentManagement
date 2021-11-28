using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentMngt.Interfaces;
using StudentMngt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMngt.Repositories
{
    public class SqlStudentRepository : IStudent
    {
        private readonly AppDbContext _context;

        public SqlStudentRepository(AppDbContext context)
        {
            _context = context;

        }
        public JsonResult CreateStudent(Student student)
        {

            _context.Add(student);
            _context.SaveChanges();
            return new JsonResult("Added Successfully !");

        }

        public JsonResult DeleteStudent(int studentId)
        {
            _context.Remove(studentId);
            _context.SaveChanges();
            return new JsonResult("Deleted Successfully !");
        }

        public JsonResult GetStudents()
        {
            _context.Student.Find();
            return new JsonResult("Returned Successfully !");
        }

        public JsonResult GetStudent(int studentId)
        {
            _context.Student.Find(studentId);
            return new JsonResult("Returned Successfully with student Id" + studentId);
        }

        public JsonResult UpdateStudent(Student studentChanges)
        {
            var contact = _context.Student.Attach(studentChanges);
            contact.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return new JsonResult("Updated Successfully");
        }
    }
}
