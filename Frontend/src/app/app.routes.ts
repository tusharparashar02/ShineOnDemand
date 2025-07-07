import { Routes } from '@angular/router';
import { HomePageComponent } from './shared/pages/HomePage/home-page/home-page.component';
import { LoginComponent } from './shared/pages/Auth/login/login.component';
import { RegisterComponent } from './shared/pages/Auth/register/register.component';
import { CustomerDashboardComponent } from './shared/pages/dashboard/customer-dashboard/customer-dashboard.component';
import { Component } from '@angular/core';
import { NotFoundComponent } from './shared/pages/not-found/not-found.component';
import { AddCarComponent } from './shared/pages/Car/add-car/add-car.component';
import { OrderPlaceComponent } from './shared/pages/Car/order-place/order-place.component';
import { OrderAddonsComponent } from './shared/pages/Car/order-addons/order-addons.component';
import { AdminDashboardComponent } from './shared/pages/dashboard/admin-dashboard/admin-dashboard.component';
import { WasherDashboardComponent } from './shared/pages/dashboard/washer-dashboard/washer-dashboard.component';
import { RoleGuard } from './Auth/role.guard';

export const routes: Routes = [
  { path: '', component: HomePageComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'customer-dashboard', component: CustomerDashboardComponent ,canActivate: [RoleGuard], data: { expectedRole:'Customer' }},
  { path: "add-car", component: AddCarComponent },
  { path: "order-place", component: OrderPlaceComponent },
  { path: "order-addons", component: OrderAddonsComponent},
  { path: "admin-dashboard", component: AdminDashboardComponent, canActivate: [RoleGuard], data: { expectedRole:'ADMIN' } },
  {path:"washer-dashboard", component: WasherDashboardComponent, canActivate: [RoleGuard], data: { expectedRole:'Washer' }},
  { path: '**', component: NotFoundComponent },

];
