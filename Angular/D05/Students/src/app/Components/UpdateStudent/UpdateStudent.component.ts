import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StudentServicesService } from 'src/app/Services/StudentServices.service';

@Component({
  selector: 'app-UpdateStudent',
  templateUrl: './UpdateStudent.component.html',
  styleUrls: ['./UpdateStudent.component.css']
})
export class UpdateStudentComponent implements OnInit {

  isUpdated:boolean  = false;
  studentDetails:any;
  private id:any;
  courses:{}[] = []

  constructor(private myService:StudentServicesService , private router:Router , activeRouted:ActivatedRoute){
    this.id= activeRouted.snapshot.params["id"];
  }

  ngOnInit() {
    this.myService.StudentDetails(this.id).subscribe({
      "next":(data)=>{
        console.log(data)
        this.studentDetails = data;
      },
      "error":()=>{

      }
    });
  }

  changeHandler(e:any){
    if(!this.courses.includes(e?.target?.value)){
      this.courses.push(e?.target?.value)
    }
  }

  Update(name:any, email:any, phone:any , age:any){
    //service==>AddNewUser().subscribe()
    let studentDate = {name, email, phone , age,courses :this.courses};
    this.myService.UpdateStudentDetails(this.id , studentDate).subscribe({
      "next":()=>{
        this.isUpdated = true;
        setTimeout(() => {
          this.router.navigateByUrl("");
        }, 1000);
      },
      "error":()=>{

      }
    });

  }
}
