import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
@Component({
  selector: 'app-customer-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './customer-dashboard.component.html',
  styleUrl: './customer-dashboard.component.css'
})
export class CustomerDashboardComponent {
  constructor(private router:Router){}
  onClickAddCar() {
    this.router.navigate(["add-car"]);
    
  }
  onClickOrderPlace() {
    this.router.navigate(["order-place"]);
  }
  onClickPromoCode() {
    this.router.navigate(["promo-code"]);
  }
  onClickOrderAddon() {
    this.router.navigate(["order-addons"]);
  }
  onClickNotFound() {
    this.router.navigate(["**"]);
  }
}
