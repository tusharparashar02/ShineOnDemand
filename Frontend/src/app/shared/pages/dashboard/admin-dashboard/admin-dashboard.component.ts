interface User {
  id: string;
  name: string;
  email: string;
}

interface Order {
  id: number;
  user: User | null;
  washer: User | null;
  carNumber: string;
  packageId: number | null;
  address: string;
  scheduledDate: string;
  status: string;
}

import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms'; // ✅ Import FormsModule
import { CommonModule } from '@angular/common';
import { ApiServiceService } from '../../../../api-service/service/api-service.service';

@Component({
  selector: 'app-admin-dashboard',
  standalone: true,
  imports: [CommonModule, FormsModule], // ✅ Add FormsModule here
  templateUrl: './admin-dashboard.component.html',
  styleUrl: './admin-dashboard.component.css'
})
export class AdminDashboardComponent {
  orders: any[] = [];
  washers: any[] = [];
  customers: any[] = [];
  selectedOrder: any = null;
  washerId: string = '';


  constructor(private apiService: ApiServiceService) {}

  ngOnInit() {
    this.fetchOrders();
    this.fetchWashers();
    this.fetchCustomers();

  }
  

  fetchOrders() {
    this.apiService.get('admin').subscribe((data) => {
      this.orders = data.map((order: Order) => ({
        id: order.id,
        userName: order.user ? order.user.name : 'N/A',
        userEmail: order.user ? order.user.email : 'N/A',
        washerName: order.washer ? order.washer.name : 'Unassigned',
        washerEmail: order.washer ? order.washer.email : 'Unassigned',
        status: order.status
      }));
    });
  }


  selectOrder(order: any) {
    this.selectedOrder = order;
  }

  assignOrder() {
    if (this.selectedOrder && this.washerId.trim() !== '') { // Ensure washerId is provided
      this.apiService.put(`admin/${this.selectedOrder.id}/assign/${this.washerId}`, {})
        .subscribe({
          next: () => {
            alert('Order Assigned Successfully');
            this.fetchOrders(); // Refresh orders
            this.selectedOrder = null;
            this.washerId = ''; // Reset input field
          },
          error: (err) => {
            console.error("Assign Order Failed:", err);
          }
        });
    } else {
      alert('Please enter a valid Washer ID.');
    }
  }
  selectedSection: string = 'orders'; // Default section

  fetchWashers() {
    this.apiService.get('admin/washers').subscribe((data) => {
      this.washers = data;
    });
  }

  fetchCustomers() {
    this.apiService.get('admin/customers').subscribe((data) => {
      this.customers = data;
    });
  }


}