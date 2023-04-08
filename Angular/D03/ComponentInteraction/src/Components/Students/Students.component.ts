import { Component , Input} from '@angular/core';

@Component({
  selector: 'app-Students',
  templateUrl: './Students.component.html',
  styleUrls: ['./Students.component.css']
})
export class StudentsComponent {
  @Input() Students:any;


}
