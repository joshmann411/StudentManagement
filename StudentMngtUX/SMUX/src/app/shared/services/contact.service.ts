import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  readonly apiUrl = "http://localhost:5000/api/";

  constructor(private http: HttpClient) { }

  //add contact
  addContact(val: any)
  {
    return this.http.post(this.apiUrl + 'Contact/Post', val);
  }

  //add contact for a student

  
  //Read Contact


  //Read Contact of a Student (outstanding)


  //update contact

  
  //update Contact of a student (outstanding)


  //Remove Contact of a Student (outstanding)


  //remove contact
  deleteContact(val: any)
  {
    return this.http.post(this.apiUrl + 'Contact/Delete', val);
  }
}
