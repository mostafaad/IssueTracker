import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpServices } from '../../../services/HttpServices';

@Component({
  selector: 'app-create-update-project',
  templateUrl: './create-update-project.component.html',
  styleUrls: ['./create-update-project.component.css']
})
export class CreateUpdateProjectComponent implements OnInit {
  projectForm: FormGroup;
  submitted = false;

  constructor(private service: HttpServices, private route: Router, private formBuilder: FormBuilder) { }

  ngOnInit() {

    this.projectForm = this.formBuilder.group({
      name: ['', Validators.required],
      key: ['', [Validators.required, Validators.maxLength(4), Validators.minLength(3), Validators.pattern('^[A-Z \-\']+')]]
    });
  }

  get f() {return this.projectForm.controls; }

  onSubmit() {
    this.submitted = true;
    console.log(this.f.key.errors);
    // stop here if form is invalid
    if (this.projectForm.invalid) {
      return;
    }

    this.service.post("project", this.projectForm.value).subscribe(
      result => {

        this.route.navigateByUrl("project/" + result["key"] + "/issues");

      }, error => {
        console.log(error);
        this.service.onFailedOutline("operation falied");
      }
    );
  }

  onReset() {
    this.submitted = false;
    this.projectForm.reset();
  }
}
