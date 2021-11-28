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
            Student student = _context.Students.Find(studentId);

            if (student != null)
            {
                _context.Remove(student);
                _context.SaveChanges();
                return new JsonResult("Deleted Successfully !");
            }

            return new JsonResult("Error Occurred !");
        }

        public JsonResult GetStudents()
        {
            return new JsonResult(_context.Students);
        }

        public JsonResult GetStudent(int studentId)
        {
            return new JsonResult(_context.Students.Find(studentId));
        }

        public JsonResult UpdateStudent(Student studentChanges)
        {
            var contact = _context.Students.Attach(studentChanges);
            contact.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return new JsonResult("Updated Successfully");
        }
    }
}
