import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  readonly apiUrl = "http://localhost:5000/api/";

  constructor(private http: HttpClient) { }

  //add student
  addStudent(val: any)
  {
    return this.http.post(this.apiUrl + 'Student/Post', val);
  }

  //get students list
  getAllStudents():Observable<any[]>{
    return this.http.get<any>(
      this.apiUrl + 'Student/Get'
    );
  }

  deleteStudent(id: any){
    return this.http.delete(this.apiUrl + 'Student/delete/' + id);
  }
}
