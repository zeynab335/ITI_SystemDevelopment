import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-Details',
  templateUrl: './Details.component.html',
})
export class DetailsComponent{
  ID:Number = 0;
  constructor(Route:ActivatedRoute) {
    this.ID = Route.snapshot.params['id']
  }



}
