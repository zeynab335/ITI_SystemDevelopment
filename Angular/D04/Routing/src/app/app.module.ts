import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from 'src/Components/Home/Home.component';
import { StudentsComponent } from 'src/Components/Students/Students.component';
import { DetailsComponent } from 'src/Components/Details/Details.component';
import { ErrorComponent } from 'src/Components/Error/Error.component';
import { RouterModule } from '@angular/router';
import { HeaderComponent } from 'src/Components/Header/Header.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,
    StudentsComponent,
    DetailsComponent,
    ErrorComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      {path:"" , component:HomeComponent},
      {path:"students" , component:StudentsComponent},
      {path:"details/:id" , component:DetailsComponent},
      {path:"**" , component:ErrorComponent},
    ]),

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
