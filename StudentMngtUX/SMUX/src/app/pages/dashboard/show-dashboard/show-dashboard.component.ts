import { Component, OnInit } from '@angular/core';
import { StudentService } from 'src/app/services/student.service';


@Component({
  selector: 'app-show-dashboard',
  templateUrl: './show-dashboard.component.html',
  styleUrls: ['./show-dashboard.component.css']
})
export class ShowDashboardComponent implements OnInit {

  StudentList: any;

  constructor(private service: StudentService) { }

  ngOnInit(): void {
    this.refreshStudents();
  }

  // addClick(){
  //   this.student = {
  //     StudentId: "0",
  //     Firstname: "",
  //     Lastname: "",
  //     IdNumber:"", 
  //     ImagePath: ""
  //   }

  //   this.ModalTitle = "Add New Student";
  //   this.ActivateAddEditStudentCom = true;

  //   this.refreshStudents();
  // }

  // closeClick(){
  //   this.ActivateAddEditStudentCom = false;

  //   this.refreshStudents();
  // }

  // editClick(item:any){
  //   this.student=item;
  //   this.ModalTitle = "Edit Student and Enrollment Details";
  //   this.ActivateAddEditStudentCom=true;

  //   this.refreshStudents();
  // }

  // deleteClick(item:any){
  //   if(confirm('Are you sure ?')){
  //     this.service.deleteStudent(item.ContactId).subscribe(data=> {
  //       alert(data.toString());
  //       this.refreshStudents();
  //     })
  //   }

  //   this.refreshStudents();
  // }

  refreshStudents(){
    this.service.getAllStudents().subscribe(data=> {
      this.StudentList = data;

      console.log('Student data: '+ this.StudentList);
    });
  }

  // getTotalContactCount(): number {
  //   return this.StudentList.length;
  // }

  // getContactsOlderThan35(){
  //   //get contacts older than 35
  //   // var timeDiff = Math.abs(Date.now() - new Date(this.birthdate).getTime());
  //   // this.age = Math.floor(timeDiff / (1000 * 3600 * 24) / 365.25);
    
  //   // return this.StudentList.filter(e => 
  //   //    Math.floor(Math.abs(Date.now() - new Date(e.BirthDate).getTime()) /(1000 * 3600 * 24) / 365.25) > 35).length;
       
  // }

  // onContactCountRBChange(selectedRBValue: string) : void {
  //   this.selectedStudentCountRadioBtn = selectedRBValue;
  // }


}
