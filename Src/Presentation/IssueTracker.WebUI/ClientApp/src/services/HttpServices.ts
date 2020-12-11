import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { AuthorizeService } from '../api-authorization/authorize.service';
import { NotificationsService, NotificationType } from 'angular2-notifications';

@Injectable({
  providedIn: 'root'
})
export class HttpServices {
  token: any;
  headers: HttpHeaders = new HttpHeaders();
  httpOptions: any;
  httpFormOptions: any;
  constructor(private _http: HttpClient, private authorizeService: AuthorizeService, private notifications: NotificationsService) {

    this.authorizeService.getAccessToken().subscribe(res => {
      this.token = res;
      this.httpOptions = {
        headers: new HttpHeaders({
          'Content-Type': 'application/json',
          'Authorization': "Bearer " + this.token
        })
      };

      this.httpFormOptions = {
        headers: new HttpHeaders({
          'Authorization': "Bearer " + this.token
        })
      }


    });
  }

  public post(url, body) {
    return this._http.post(environment.appUrl + url, body, this.httpOptions);
  }

  public postForm(url, body) {
    return this._http.post(environment.appUrl + url, body, this.httpFormOptions);
  }

  public get(url) {
    return this._http.get(environment.appUrl + url, this.httpOptions);
  }

  onSuccessOutline(): void {
    this.notifications.create("success", "Operation done successfully",
      NotificationType.Success, { theClass: 'outline', timeOut: 3000, showProgressBar: false });

  }
  onFailedOutline(msg): void {
    this.notifications.create("error",
      msg,
      NotificationType.Error, { theClass: 'outline', timeOut: 3000, showProgressBar: false });

  }
}
