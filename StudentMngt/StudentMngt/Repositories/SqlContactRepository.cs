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
        public JsonResult CreateContact(Contact Contact)
        {
            _context.Add(Contact);
            _context.SaveChanges();
            return new JsonResult("Added Successfully !");
        }

        public JsonResult DeleteContact(int contactId)
        {
            Contact contact = _context.Contacts.Find(contactId);

            if (contact != null)
            {
                _context.Remove(contactId);
                _context.SaveChanges();
                return new JsonResult("Deleted Successfully !");
            }

            return new JsonResult("Error Occurred !");
        }

        public JsonResult GetContacts()
        {
            return new JsonResult(_context.Contacts);
        }

        public JsonResult GetContact(int contactId)
        {
            return new JsonResult(_context.Contacts.Find(contactId));
        }

        public JsonResult UpdateContact(Contact ContactChange)
        {
            var contact = _context.Contacts.Attach(ContactChange);
            contact.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return new JsonResult("Updated Successfully");
        }
    }
}
