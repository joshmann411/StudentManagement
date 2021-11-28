using Microsoft.AspNetCore.Mvc;
using StudentMngt.Interfaces;
using StudentMngt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMngt.Repositories
{
    public class SqlContactRepository : IContact
    {
        private readonly AppDbContext _context;

        public SqlContactRepository(AppDbContext context)
        {
            _context = context;

        }
        public JsonResult CreateContact(int Contact)
        {
            _context.Add(Contact);
            _context.SaveChanges();
            return new JsonResult("Added Successfully !");
        }

        public JsonResult DeleteContact(int contactId)
        {
            _context.Remove(contactId);
            _context.SaveChanges();
            return new JsonResult("Deleted Successfully !");
        }

        public JsonResult GetContacts()
        {
            _context.Student.Find();
            return new JsonResult("Returned Successfully !");
        }

        public JsonResult GetContact(Contact contactId)
        {
            _context.Contact.Find(contactId);
            return new JsonResult("Returned Successfully with student Id" + contactId);
        }

        public JsonResult UpdateContact(Contact ContactChange)
        {
            var contact = _context.Contact.Attach(ContactChange);
            contact.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return new JsonResult("Updated Successfully");
        }
    }
}
