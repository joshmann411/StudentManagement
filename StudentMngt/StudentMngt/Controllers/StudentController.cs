using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentMngt.Interfaces;
using StudentMngt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMngt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IStudent _student;

        public StudentController(ILoggerFactory loggerFactory,
                                IStudent student)
        {
            _logger = loggerFactory.CreateLogger(typeof(StudentController));
            _student = student;
        }

        [HttpGet]
        [Route("Get")]
        public JsonResult Get()
        {
            try
            {
                _logger.LogInformation("Retrieving list of known students");

                return new JsonResult(_student.GetStudents().Value);
            }
            catch (Exception ex)
            {
                //log error
                _logger.LogError($"Error while retrieving students list: {ex.Message}");

                return new JsonResult("Error retrieving students list", ex.Message.ToString());
            }
        }

        
        [HttpGet]
        [Route("GetById/{id}")]
        public JsonResult GetById(int id)
        {
            try
            {
                _logger.LogInformation($"Retrieving student with ID: {id}");

                return new JsonResult(_student.GetStudent(id).Value);
            }
            catch (Exception ex)
            {
                //log error
                _logger.LogError($"Error while retrieving student with ID: {id}. Exception: {ex.Message}");

                // throw 
                return new JsonResult("Error retrieving student with ID " + id, ex.Message.ToString());
            }
        }

        //[HttpGet]
        //[Route("getAccountsOfClientByEmail/{clientEmail}")]
        //public JsonResult getAccountsOfClientByEmail(string clientEmail) //get by Email
        //{
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(clientEmail) && !clientEmail.Contains("null"))
        //        {
        //            _logger.LogInformation("==> Retrieving accounts with client email: {0}", clientEmail);

        //            //get client object
        //            Client cl = _clientRepo.GetClients().Where(x => x.email == clientEmail).FirstOrDefault();

        //            if (cl != null)
        //            {
        //                IEnumerable<Account> accounts = _accountRepo.GetAccountsOfClient(cl.id);

        //                _logger.LogInformation("<== Retrieving accounts with client email: {0}:", clientEmail);

        //                return new JsonResult(accounts);
        //            }

        //            return new JsonResult("Errpr occurred with Client");
        //        }
        //        else
        //        {
        //            _logger.LogInformation("<== Empty email provided");

        //            return new JsonResult(new Exception("Empty email provided"));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // log error
        //        _logger.LogError("XXX Error while retrieving business with email: {0} | Exception: {1}", clientEmail, ex.Message.ToString());

        //        // throw 
        //        return new JsonResult("Error retrieving accounts of client Email " + clientEmail, ex.Message.ToString());

        //    }
        //}


        [HttpPost]
        [Route("Post")]
        public JsonResult Post([FromBody] Student student)
        {
            if (student != null)
            {
                try
                {
                    _logger.LogInformation($"Adding new student with id: {student.StudentId}");

                    JsonResult msg = _student.CreateStudent(student);

                    _logger.LogInformation("Added Successfully !");

                    return new JsonResult(msg.Value);
                }
                catch (Exception ex)
                {
                    //log 
                    _logger.LogError($"Error while attempting to add new student with id {student.StudentId}. Error {ex.Message}");

                    return new JsonResult("Error occurred while adding new student", ex.Message.ToString());
                }
            }

            return new JsonResult(BadRequest("Error occurred"));
        }

        [HttpPut]
        [Route("Put")]
        public JsonResult Put([FromBody] Student studentChanges)
        {
            try
            {
                _logger.LogInformation($"Updating student changes. Object: {new JsonResult(studentChanges)}");

                JsonResult response = _student.UpdateStudent(studentChanges);

                _logger.LogInformation("Updated Successfully");

                return new JsonResult(response.Value);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to update student details. Error Details: {ex.Message}");

                return new JsonResult("Error occurred while updating student" + ex.Message.ToString());
            }
        }

        [HttpDelete]
        [Route("Delete/{studentId}")]
        public JsonResult Delete(int studentId)
        {
            try
            {
                _logger.LogInformation($"Deleting student with ID: {studentId}");

                JsonResult response = _student.DeleteStudent(studentId);

                _logger.LogInformation("Deleted Successfully !");

                return new JsonResult(response.Value);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to delete student with id {studentId}. Error detail: {ex.Message}");

                return new JsonResult("Error while deleting student", ex.Message.ToString());
            }
        }
    }
}
