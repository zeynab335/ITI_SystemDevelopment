import { Component , EventEmitter , Output} from '@angular/core';

@Component({
  selector: 'app-Registration',
  templateUrl: './Registration.component.html',
  styleUrls: ['./Registration.component.css']
})
export class RegistrationComponent{

  // initialize inputs
  name = "";
  age = "";
  Data = {};

  @Output() RegisterEvent = new EventEmitter()

  addData(){
    if((+this.age <= 40 && +this.age >= 20) && this.name.length >= 3){
      this.Data = {name:this.name , age:this.age}
      this.RegisterEvent.emit(this.Data);
    }

  }

}
