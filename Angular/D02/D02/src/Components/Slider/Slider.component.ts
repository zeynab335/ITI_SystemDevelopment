import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-Slider',
  templateUrl: './Slider.component.html',
  styleUrls: ['./Slider.component.css']
})
export class SliderComponent {


  rootPath = "assets/";
  images = ["1.gif" , "2.gif" , "3.gif" , "4.gif"];

  index = 0;
  imgSrc = this.rootPath + this.images[this.index];

  Interval:any;

  nxtImgHandler(){
    //* circular Slider

    if(this.index == 3){
      this.index = 0 ;
    }
    else{
      this.index ++ ;
    }
    this.imgSrc = this.rootPath + this.images[this.index];
  }

  prvImgHandler(){
    //* circular Slider
    if(this.index == 0){
      this.index = 3 ;
    }
    else{
      this.index -- ;
    }
    this.imgSrc = this.rootPath + this.images[this.index];
  }

  sliderImgHandler(){

    this.Interval = setInterval(()=>{
      this.index ++;

      if(this.index > 3){
        this.index = 0 ;
      }
      else if(this.index == 0){
        this.index = 3 ;
      }
      this.imgSrc = this.rootPath + this.images[this.index];
    },1000)
  }

  stopHandler(){
     clearInterval(this.Interval);
  }
}
