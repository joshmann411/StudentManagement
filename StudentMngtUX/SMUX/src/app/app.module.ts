import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthComponent } from './shared/services/auth/auth.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { LayoutFullModule } from './layouts/layout-full/layout-full.module';
import { LayoutSideModule } from './layouts/layout-side/layout-side.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ShowDashboardComponent } from './pages/dashboard/show-dashboard/show-dashboard.component';
import { AddEditDashboardComponent } from './pages/dashboard/add-edit-dashboard/add-edit-dashboard.component';
import { StudentFilterPipe } from './pages/dashboard/show-dashboard/student-filter.pipe';

@NgModule({
  declarations: [
    AppComponent,
    AuthComponent,
    DashboardComponent,
    LoginComponent,
    RegisterComponent,
    ShowDashboardComponent,
    AddEditDashboardComponent,
    StudentFilterPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    RouterModule,
    CommonModule,
    LayoutFullModule,
    LayoutSideModule,
    FlexLayoutModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
