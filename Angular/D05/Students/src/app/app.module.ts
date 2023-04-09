import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './Components/Header/Header.component';
import { StudentsComponent } from './Components/Students/Students.component';
import { AddStudentComponent } from './Components/AddStudent/AddStudent.component';
import { UpdateStudentComponent } from './Components/UpdateStudent/UpdateStudent.component';
import { ReactiveFormsModule ,FormsModule } from '@angular/forms';
import {HttpClientModule} from "@angular/common/http";
import { DeleteStudentComponent } from './Components/DeleteStudent/DeleteStudent.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    StudentsComponent,
    AddStudentComponent,
    UpdateStudentComponent,
    DeleteStudentComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
