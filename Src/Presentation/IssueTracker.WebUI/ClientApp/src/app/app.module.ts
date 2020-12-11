import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { CreateUpdateProjectComponent } from './project/create-update-project/create-update-project.component';
import { SimpleNotificationsModule } from 'angular2-notifications';
import { ListIssuesComponent } from './project/list-issues/list-issues.component';
import { GridModule } from '@progress/kendo-angular-grid';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DialogsModule } from '@progress/kendo-angular-dialog';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { NgSelectModule } from '@ng-select/ng-select';


@NgModule({
  declarations: [
    AppComponent,
    ListIssuesComponent,
    NavMenuComponent,
    HomeComponent,
    CreateUpdateProjectComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    SimpleNotificationsModule.forRoot(),
    FormsModule,
    NgSelectModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'home', pathMatch: 'full'  },
      { path: 'home', component: HomeComponent, canActivate: [AuthorizeGuard]  },
      { path: 'create-project', component: CreateUpdateProjectComponent, canActivate: [AuthorizeGuard] },
      { path: 'project/:id/issues', component: ListIssuesComponent, canActivate: [AuthorizeGuard] }
    ]),
    GridModule,
    BrowserAnimationsModule,
    DialogsModule,
    ButtonsModule,
    DropDownsModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
