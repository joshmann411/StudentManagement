﻿using Microsoft.AspNetCore.Mvc;
using StudentMngt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMngt.Interfaces
{
    public interface IContact
    {
        JsonResult GetContacts();
        JsonResult CreateContact(int Contact);
        JsonResult GetContact(Contact contactId);
        JsonResult UpdateContact(Contact ContactChange);
        JsonResult DeleteContact(int contactId);

    }
}
