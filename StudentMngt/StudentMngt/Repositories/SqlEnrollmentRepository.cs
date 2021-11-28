using Microsoft.AspNetCore.Mvc;
using StudentMngt.Interfaces;
using StudentMngt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMngt.Repositories
{
    public class SqlEnrollmentRepository : IEnrollment
    {
        private readonly AppDbContext _context;

        public SqlEnrollmentRepository(AppDbContext context)
        {
            _context = context;

        }
        public JsonResult CreateEnrollment(Enrollment Enrollment)
        {
            _context.Add(Enrollment);
            _context.SaveChanges();
            return new JsonResult("Added Successfully !");
        }

        public JsonResult DeleteEnrollment(int EnrollmentId)
        {
            Enrollment enrollment = _context.Enrollments.Find(EnrollmentId);

            if (enrollment != null)
            {
                _context.Remove(enrollment);
                _context.SaveChanges();
                return new JsonResult("Deleted Successfully !");
            }

            return new JsonResult("Error Occurred !");
        }

        public JsonResult GetEnrollment(int EnrollmentId)
        {
            return new JsonResult(_context.Enrollments.Find(EnrollmentId));
        }

        public JsonResult GetEnrollments()
        {
            return new JsonResult(_context.Enrollments);
        }

        public JsonResult UpdateEnrollment(Enrollment EnrollmentChanges)
        {
            var contact = _context.Enrollments.Attach(EnrollmentChanges);
            contact.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return new JsonResult("Updated Successfully");
        }
    }
}