import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StudentServicesService {

private readonly url="http://localhost:3000/students"

constructor(private readonly request:HttpClient) {}

// get all students
GetAllStudents(){
  return this.request.get(this.url);
}

AddStudent(student:any){
  return this.request.post(this.url,student);
}

DeleteStudent(id:any){
  console.log(id);
  return this.request.delete(this.url+"/"+id);
}

StudentDetails(id:any){
  return this.request.get(this.url+"/"+id);
}

UpdateStudentDetails(id:any , student:any){
  return this.request.put(this.url+"/"+id , student);
}



}
