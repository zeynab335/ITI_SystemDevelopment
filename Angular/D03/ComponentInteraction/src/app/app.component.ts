import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})


export class AppComponent {
  AllStudents:{name:string, age:number}[] = [{name:"zeze" , age:20}];

  title = 'ComponentInteraction';
  GetStudents(data:any){
    console.log(data)
    this.AllStudents.push(data);
  }
}
