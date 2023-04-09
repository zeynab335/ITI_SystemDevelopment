import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { StudentServicesService } from 'src/app/Services/StudentServices.service';

@Component({
  selector: 'app-AddStudent',
  templateUrl: './AddStudent.component.html',
  styleUrls: ['./AddStudent.component.css']
})
export class AddStudentComponent{

  courses:{}[] = [];
  constructor(private myService:StudentServicesService , private router:Router){

  }

  changeHandler(e:any){
    if(!this.courses.includes(e?.target?.value)){
      this.courses.push(e?.target?.value)
    }  }
  isAdded:boolean  = false;

  Add(name:any, email:any, phone:any , age:any ){

    let newUser = {name, email, phone , age , courses :this.courses};
    this.myService.AddStudent(newUser).subscribe({
      "next":()=>{
        this.isAdded = true;
        setTimeout(() => {
          this.router.navigateByUrl("");
        }, 1000);
      },
      "error":()=>{

      }
    });

  }
}
