using Microsoft.AspNetCore.Mvc;
using StudentMngt.Interfaces;
using StudentMngt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMngt.Repositories
{
    public class SqlEnrollmentRepository : IEnrollmenet
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
            _context.Remove(EnrollmentId);
            _context.SaveChanges();
            return new JsonResult("Deleted Successfully !");
        }

        public JsonResult Enrollment(int EnrollmentId)
        {
            _context.Enrollment.Find(EnrollmentId);
            return new JsonResult("Returned Successfully with enrollment Id" + EnrollmentId);
        }

        public JsonResult GetEnrollment()
        {
            _context.Enrollment.Find();
            return new JsonResult("Returned Successfully !");
        }

        public JsonResult UpdateEnrollment(Enrollment EnrollmentChanges)
        {
            var contact = _context.Enrollment.Attach(EnrollmentChanges);
            contact.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return new JsonResult("Updated Successfully");
        }
    }
}