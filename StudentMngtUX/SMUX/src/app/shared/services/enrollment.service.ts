import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EnrollmentService {

  readonly apiUrl = "http://localhost:5000/api/";
  constructor(private http: HttpClient) { }

  //add Enrollment
  addEnrollment(val: any)
  {
    return this.http.post(this.apiUrl + 'Enrollment/Post', val);
  }

  //add Enrollment for student

  //Read Enrollment


  //Read Enrollment of a Student (outstanding)


  //update Enrollment

  
  //update Enrollment of a student (outstanding)


  //Remove Enrollment of a Student (outstanding)

  
  //remove enrollment
  deleteContact(val: any)
  {
    return this.http.post(this.apiUrl + 'Contact/Delete', val);
  }
}
