using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMngt.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Contact> Contacts {get;set;}
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    ContactId = 1,
                    ContactDescription = "John",
                    ContactTypeId = 1,
                    StudentId = 245
                });

            modelBuilder.Entity<ContactType>().HasData(
               new ContactType
               {
                   ContactTypeId = 1,
                   SelectedType = "email"
               },
               new ContactType
               {
                   ContactTypeId = 2,
                   SelectedType = "cellphone"
               },
               new ContactType
               {
                   ContactTypeId = 3,
                   SelectedType = "Address"
               });

          
            modelBuilder.Entity<Student>().HasData(
               new Student
               {
                   StudentId = 1,
                   Firstname = "John",
                   Lastname ="Doe",
                   IdNumber = "23",
                   ImagePath = null

               });

            modelBuilder.Entity<Enrollment>().HasData(
              new Enrollment
              {
                 AverageToDate = 50.90,
                 DateRegistered = "12/12/12",
                 EnrollmentId = 123,
                 GraduationDate = "1/1/1",
                 Institution = "school",
                 Qualification = "bsc234",
                 QualificationType = "Undergraduate"
                 

              });
           
        }

    }
}
