import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ApiServiceService } from '../../../../api-service/service/api-service.service';

@Component({
  selector: 'app-order-place',
  standalone: true,  
  templateUrl: './order-place.component.html',
  styleUrls: ['./order-place.component.css'],
  imports: [FormsModule, CommonModule]
})

export class OrderPlaceComponent implements OnInit {
  order = {
    userId: '',
    carNumber: '',
    packageId: '',
    address: '',
    scheduledDate: new Date().toISOString().slice(0, 10),
    orderAddOns: [{ addOnId: 0, addOnName: '', addOnPrice: 0 }]
  };

  orders: any[] = [];

  constructor(private apiService: ApiServiceService) { }

  ngOnInit() {
    this.getOrders();
  }

  placeOrder() {
    this.apiService.post('Order', this.order).subscribe(response => {
      alert('Order placed successfully!');
      this.getOrders(); // Refresh order list
    });
  }

  getOrders() {
    this.apiService.get('Order').subscribe(response => {
      this.orders = response || [];
    });
  }

  deleteOrder(orderId: number, scheduledDate: string) {
    const today = new Date().toISOString().slice(0, 10);
    if (new Date(scheduledDate) <= new Date(today)) {
      alert("Order cannot be deleted after placement.");
      return;
    }

    if (confirm("⚠️ Are you sure you want to delete this order?")) {
      this.apiService.delete(`Order/${orderId}`).subscribe(() => {
        alert("Order deleted successfully!");
        this.getOrders(); // Refresh order list
      });
    }
  }

  addNewAddOn() {
    this.order.orderAddOns.push({ addOnId: 0, addOnName: '', addOnPrice: 0 });
  }

  removeAddOn(index: number) {
    this.order.orderAddOns.splice(index, 1);
  }
}