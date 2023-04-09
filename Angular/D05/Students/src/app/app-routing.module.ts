import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentsComponent } from './Components/Students/Students.component';
import { StudentDetailsComponent } from './Components/StudentDetails/StudentDetails.component';
import { AddStudentComponent } from './Components/AddStudent/AddStudent.component';
import { ErrorComponent } from './Components/Error/Error.component';
import { UpdateStudentComponent } from './Components/UpdateStudent/UpdateStudent.component';
import { AppComponent } from './app.component';
import { DeleteStudentComponent } from './Components/DeleteStudent/DeleteStudent.component';

const routes: Routes = [
  {path:"" , component:StudentsComponent},
  {path:"students/:id" , component:StudentDetailsComponent},
  {path:"addStudent" , component:AddStudentComponent},
  {path:"updateStudent/:id" , component:UpdateStudentComponent},
  {path:":id" , component:StudentsComponent},


  {path:"*" , component:ErrorComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
