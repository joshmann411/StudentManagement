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
    public class EnrollmentController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IEnrollment _enrollment;

        public EnrollmentController(ILoggerFactory loggerFactory,
                                    IEnrollment enrollment)
        {
            _logger = loggerFactory.CreateLogger(typeof(EnrollmentController));
            _enrollment = enrollment;
        }

        [HttpGet]
        [Route("Get")]
        public JsonResult Get()
        {
            try
            {
                _logger.LogInformation("Retrieving list of known enrollments");

                return new JsonResult(_enrollment.GetEnrollments());
            }
            catch (Exception ex)
            {
                //log error
                _logger.LogError($"Error while retrieving enrollments list: {ex.Message}");

                return new JsonResult("Error retrieving enrollments list", ex.Message.ToString());
            }
        }


        [HttpGet]
        [Route("GetById/{id}")]
        public JsonResult GetById(int id)
        {
            try
            {
                _logger.LogInformation($"Retrieving enrollment with ID: {id}");

                return new JsonResult(_enrollment.GetEnrollment(id));
            }
            catch (Exception ex)
            {
                //log error
                _logger.LogError($"Error while retrieving enrollment with ID: {id}. Exception: {ex.Message}");

                // return thrown error 
                return new JsonResult("Error retrieving enrollment with ID " + id, ex.Message.ToString());
            }
        }

        [HttpPost]
        [Route("Post")]
        public JsonResult Post([FromBody] Enrollment enrollment)
        {
            if (enrollment != null)
            {
                try
                {
                    _logger.LogInformation($"Adding new enrollment with id: {enrollment.EnrollmentId}");

                    JsonResult msg = _enrollment.CreateEnrollment(enrollment);

                    _logger.LogInformation("Added Successfully !");

                    return new JsonResult(msg);
                }
                catch (Exception ex)
                {
                    //log 
                    _logger.LogError($"Error while attempting to add new enrollment with id {enrollment.EnrollmentId}. Error {ex.Message}");

                    return new JsonResult("Error occurred while adding new enrollment", ex.Message.ToString());
                }
            }

            return new JsonResult(BadRequest("Error occurred"));
        }

        [HttpPut]
        [Route("Put")]
        public JsonResult Put([FromBody] Enrollment enrollmentChanges)
        {
            try
            {
                _logger.LogInformation($"Updating enrollment changes. Object: {new JsonResult(enrollmentChanges)}");

                JsonResult response = _enrollment.UpdateEnrollment(enrollmentChanges);

                _logger.LogInformation("Updated Successfully");

                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to update enrollment details. Error Details: {ex.Message}");

                return new JsonResult("Error occurred while updating enrollment" + ex.Message.ToString());
            }
        }

        [HttpDelete]
        [Route("Delete/{enrollmentId}")]
        public JsonResult Delete(int enrollmentId)
        {
            try
            {
                _logger.LogInformation($"Deleting enrollment with ID: {enrollmentId}");

                JsonResult response = _enrollment.DeleteEnrollment(enrollmentId);

                _logger.LogInformation("Deleted Successfully !");

                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to delete enrollment with id {enrollmentId}. Error detail: {ex.Message}");

                return new JsonResult("Error while deleting enrollment", ex.Message.ToString());
            }
        }
    }
}
