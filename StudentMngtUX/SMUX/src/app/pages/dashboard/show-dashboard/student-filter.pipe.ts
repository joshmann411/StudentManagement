import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'studentFilter'
})
export class StudentFilterPipe implements PipeTransform {

  transform(students: any[],searchTerm: string): any[] {
    if(!students || !searchTerm){
      return students;
    }

    return students.filter(students => 
      students.Firstname.toLowerCase().indexOf(searchTerm.toLowerCase()) !== -1);
  }
}
