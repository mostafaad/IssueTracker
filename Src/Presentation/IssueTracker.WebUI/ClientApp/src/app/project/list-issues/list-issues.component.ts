import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpServices } from '../../../services/HttpServices';

@Component({
  selector: 'app-list-issues',
  templateUrl: './list-issues.component.html',
  styleUrls: ['./list-issues.component.css']
})
export class ListIssuesComponent implements OnInit {
  id: any;
  public dialogOpened = false;
  public windowOpened = false;
  public participantsDialogOpened = false;
  public participantsWindowOpened = false;
  issueForm: FormGroup;
  participantForm: FormGroup;
  submitted = false;
  AssigneeItems: any;
  public gridData: any;
  public participantGridData: any;
  isProjectOwner: any;

  constructor(private service: HttpServices, private route: Router, private activatedRoute: ActivatedRoute, private formBuilder: FormBuilder) { }

  get f() { return this.issueForm.controls; }
  get fa() { return this.participantForm.controls; }

  public status: Array<{ text: string, value: number }> = [
    { text: 'Todo', value: 0 },
    { text: 'InProgress', value: 1 },
    { text: 'Done', value: 2 }
  ];

  getProjectIssues() {
    this.service.get("issue/" + this.id).subscribe(result => {
      console.log("");
      this.gridData = result;
    });
  }
  getParticipantIssues() {
    this.service.get("Participant/" + this.id).subscribe(result => {
      console.log(result);
      this.participantGridData = result;
    });
  }
  async ngOnInit() {
    this.issueForm = this.formBuilder.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
      assignee: ['', Validators.required],
      status: ['', Validators.required]

    });

    this.participantForm = this.formBuilder.group({
      email: ['', Validators.required]

    });

    this.activatedRoute.params.subscribe(params => {
      this.id = params['id'];
    });

    this.service.get("project/validateProjectOwner/" + this.id).subscribe(result => {

      this.isProjectOwner = result;
    });

    this.service.get("user").subscribe(result => {
      console.log(result);
      this.AssigneeItems = result;
    });

    this.getProjectIssues();
    this.getParticipantIssues();
  }

  deleteProject() {
    this.service.get("project/DeleteProject/" + this.id).subscribe(result => {
      this.route.navigateByUrl("/home");
    });
  }

  onParticipantsSubmit() {
    if (this.participantForm.invalid) {
      return;
    }

    this.service.post("Participant/" + this.id + "/" + this.participantForm.value.email, this.participantForm.value).subscribe(
      result => {
        this.getParticipantIssues();

      }, error => {
        console.log(error);
        this.service.onFailedOutline("operation falied");
      }
    );

  }
  onSubmit() {
    this.submitted = true;
    console.log(this.issueForm.invalid);
    // stop here if form is invalid
    if (this.issueForm.invalid) {
      return;
    }

    this.service.post("issue/" + this.id, this.issueForm.value).subscribe(
      result => {
        this.dialogOpened = false;
        this.getProjectIssues();

      }, error => {
        console.log(error);
        this.service.onFailedOutline("operation falied");
      }
    );
  }

  public close(component) {
    this.dialogOpened = false;
  }

  public open(component) {
    this[component + 'Opened'] = true;
  }
  participantsopen() {
    this.participantsDialogOpened = true;
  }
  participantsclose() {
    this.participantsDialogOpened = false;

  }
  public action(status) {
    console.log(`Dialog result: ${status}`);

    if (this.issueForm.invalid) {
      return;
    }

    this.service.post("issue/" + this.id, this.issueForm.value).subscribe(
      result => {


      }, error => {
        console.log(error);
        this.service.onFailedOutline("operation falied");
      }
    );

    this.dialogOpened = false;
  }
}
