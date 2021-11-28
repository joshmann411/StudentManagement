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
    public class ContactController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IContact _contact;

        public ContactController(ILoggerFactory loggerFactory,
                                IContact contact)
        {
            _logger = loggerFactory.CreateLogger(typeof(ContactController));
            _contact = contact;
        }

        [HttpGet]
        [Route("Get")]
        public JsonResult Get()
        {
            try
            {
                _logger.LogInformation("Retrieving list of known contacts");

                return new JsonResult(_contact.GetContacts().Value);
            }
            catch (Exception ex)
            {
                //log error
                _logger.LogError($"Error while retrieving contacts list: {ex.Message}");

                return new JsonResult("Error retrieving contacts list", ex.Message.ToString());
            }
        }


        [HttpGet]
        [Route("GetById/{id}")]
        public JsonResult GetById(int id)
        {
            try
            {
                _logger.LogInformation($"Retrieving contact with ID: {id}");

                return new JsonResult(_contact.GetContact(id).Value);
            }
            catch (Exception ex)
            {
                //log error
                _logger.LogError($"Error while retrieving contact with ID: {id}. Exception: {ex.Message}");

                // return thrown error 
                return new JsonResult("Error retrieving contact with ID " + id, ex.Message.ToString());
            }
        }

        [HttpPost]
        [Route("Post")]
        public JsonResult Post([FromBody] Contact contact)
        {
            if (contact != null)
            {
                try
                {
                    _logger.LogInformation($"Adding new contact with id: {contact.ContactId}");

                    JsonResult msg = _contact.CreateContact(contact);

                    _logger.LogInformation("Added Successfully !");

                    return new JsonResult(msg.Value);
                }
                catch (Exception ex)
                {
                    //log 
                    _logger.LogError($"Error while attempting to add new contact with id {contact.ContactId}. Error {ex.Message}");

                    return new JsonResult("Error occurred while adding new contact", ex.Message.ToString());
                }
            }

            return new JsonResult(BadRequest("Error occurred"));
        }

        [HttpPut]
        [Route("Put")]
        public JsonResult Put([FromBody] Contact contactChanges)
        {
            try
            {
                _logger.LogInformation($"Updating contact changes. Object: {new JsonResult(contactChanges)}");

                JsonResult response = _contact.UpdateContact(contactChanges);

                _logger.LogInformation("Updated Successfully");

                return new JsonResult(response.Value);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to update contact details. Error Details: {ex.Message}");

                return new JsonResult("Error occurred while updating contact" + ex.Message.ToString());
            }
        }

        [HttpDelete]
        [Route("Delete/{contactId}")]
        public JsonResult Delete(int contactId)
        {
            try
            {
                _logger.LogInformation($"Deleting contact with ID: {contactId}");

                JsonResult response = _contact.DeleteContact(contactId);

                _logger.LogInformation("Deleted Successfully !");

                return new JsonResult(response.Value);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to delete contact with id {contactId}. Error detail: {ex.Message}");

                return new JsonResult("Error while deleting contact", ex.Message.ToString());
            }
        }
    }
}
