import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { HttpServices } from '../../services/HttpServices';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  projectLst: any;
  constructor(private service: HttpServices, private route: Router) { }

  ngOnInit() {
    this.service.get("project").subscribe(result => {
      this.projectLst = result;
    });
  }
}
