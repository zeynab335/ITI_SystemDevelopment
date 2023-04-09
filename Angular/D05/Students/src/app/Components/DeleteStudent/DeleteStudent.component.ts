import { Component, Input, OnInit ,ViewChild} from '@angular/core';
import { ActivatedRoute, Route, Router, RouterLink } from '@angular/router';
import { StudentServicesService } from 'src/app/Services/StudentServices.service';
import { __param } from 'tslib';
@Component({
  selector: 'app-DeleteStudent',
  templateUrl: './DeleteStudent.component.html',
  styleUrls: ['./DeleteStudent.component.css']
})
export class DeleteStudentComponent implements OnInit {

  private id:any;
  @ViewChild('model') model:any;

  // closeModel:boolean = false;

  constructor(activeRoute:ActivatedRoute , private httpRequest:StudentServicesService , private route:Router ) {
    this.id = activeRoute.snapshot.params['id'];
   }


  ngOnInit() {
  }

  DeleteStudent(){
    console.log("click")
    this.httpRequest.DeleteStudent(this.id).subscribe({
      next:(data)=>{
        this.model.nativeElement.style.display="none!important"
        this.route.navigateByUrl("");
      },

      error:(err)=>{console.log(err)}
    })
  }

}
