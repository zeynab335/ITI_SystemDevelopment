import { Component, OnInit } from '@angular/core';
import { StudentServicesService } from 'src/app/Services/StudentServices.service';

@Component({
  selector: 'app-Students',
  templateUrl: './Students.component.html',
  styleUrls: ['./Students.component.css']
})
export class StudentsComponent implements OnInit {

  Students:any
  showModule:boolean = false

  constructor(private context:StudentServicesService) { }

  ngOnInit() {
    this.context.GetAllStudents().subscribe({
      next:(data)=>{this.Students = data},
      error:(err)=> {console.log("error" + err)}
    })
  }

  showDeleteModule(){
    this.showModule = true;
  }



}
