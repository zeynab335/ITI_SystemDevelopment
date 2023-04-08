import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-Students',
  templateUrl: './Students.component.html',
  styleUrls: ['./Students.component.css']
})
export class StudentsComponent  {

  constructor() { }
  Students:{name:string ,age:Number}[] = [
    {name:"zeinab", age:22},
    {name:"Adham" , age:16},
    {name:"Ali"   , age:25},
    {name:"Aliaa" , age:26},

  ]

}
