import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BindingComponent } from '../Components/Binding/Binding.component';
import { FormsModule } from '@angular/forms';
import { SliderComponent } from 'src/Components/Slider/Slider.component';

@NgModule({
  declarations: [
    AppComponent,
      BindingComponent,
      SliderComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {

 }
