import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'D02';
  showBinding = "d-none"
  showSlider = "d-none"

  btnBinding = "d-block"
  btnSlider = "d-block"

  ShowBindingHandler(){
    this.showBinding = "d-block"

    this.btnBinding  = "d-none"
    this.btnSlider  = "d-none"
  }

  ShowSliderHandler(){
    this.showSlider = "d-block"

    this.btnBinding  = "d-none"
    this.btnSlider  = "d-none"
  }

}

