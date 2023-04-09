import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { StudentServicesService } from 'src/app/Services/StudentServices.service';

@Component({
  selector: 'app-StudentDetails',
  templateUrl: './StudentDetails.component.html',
  styleUrls: ['./StudentDetails.component.css']
})
export class StudentDetailsComponent implements OnInit {

  user:any;
  private id :any;
  constructor(private context:StudentServicesService , activeRoute:ActivatedRoute) {
    this.id = activeRoute.snapshot.params['id'];
   }

  ngOnInit() {
    this.context.StudentDetails(this.id).subscribe({
      next:(data)=>{this.user = data},
      error:(err)=> {console.log("error" + err)}
    })
  }

}
