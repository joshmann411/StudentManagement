using Microsoft.AspNetCore.Mvc;
using StudentMngt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMngt.Interfaces
{
    public interface IEnrollmenet
    {
        JsonResult GetEnrollment();
        JsonResult Enrollment(int EnrollmentId);
        JsonResult CreateEnrollment(Enrollment Enrollment);
        JsonResult UpdateEnrollment(Enrollment EnrollmentChanges);
        JsonResult DeleteEnrollment(int EnrollmentId);

    }
}
