import { Component } from '@angular/core';
import { FormGroup ,FormControl , Validators } from '@angular/forms';

@Component({
  selector: 'app-Home',
  templateUrl: './Home.component.html',
  styleUrls: ['./Home.component.css']
})
export class HomeComponent  {

  constructor() { }

  FormValidation = new FormGroup(
    {
      name : new FormControl("zeinab",[Validators.required , Validators.minLength(3)]),
      age : new FormControl("20",[Validators.required , Validators.min(20) , Validators.max(40)]),
      email : new FormControl("z@email.com",Validators.required)
    }
  );

  get NameIsNotValid(){
    return !this.FormValidation.controls.name.valid;
  }
  get AgeIsNotValid(){
    return !this.FormValidation.controls.age.valid;
  }
  get EmailIsNotValid(){
    return !this.FormValidation.controls.email.valid;
  }

  ErrorMessage:any = "";
  FormIsValid:any;


  GetData(){
    let controls = this.FormValidation.controls;

    if(!this.FormValidation.valid){
      this.FormIsValid = false;

      if(!controls.email.valid){
        this.ErrorMessage += " Email is not valid , "
      }
      if(!controls.name.valid){
        this.ErrorMessage += " Name is not valid , "
      }
      if(!controls.age.valid){
        this.ErrorMessage += " Age is not valid , "

      }

      this.ErrorMessage += "❌";

    }
    else{
      this.FormIsValid = true;
      this.ErrorMessage = ""
    }
  }

}
