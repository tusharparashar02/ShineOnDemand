import { Component, OnInit } from '@angular/core';
import { ApiServiceService } from '../../../../api-service/service/api-service.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-washer-dashboard',
  standalone: true,
  templateUrl: './washer-dashboard.component.html',
  styleUrls: ['./washer-dashboard.component.css'],
  imports: [CommonModule, FormsModule],
})
export class WasherDashboardComponent implements OnInit {
  orders: any[] = [];
  ratings: any[] = [];
  selectedOrder: any = null;
  status: string = '';
  comment: string = '';
  lastUpdatedOrderIds: Set<number> = new Set();
  washerId: string | null = null; // ✅ Stores logged-in washer ID

  constructor(private apiService: ApiServiceService) { }

  ngOnInit() {
    this.washerId = this.apiService.getUserId(); // ✅ Fetch user ID from token
    if (this.washerId) {
      this.fetchOrders();
      this.fetchRatings();
    }
  }

  fetchOrders() {
    if (!this.washerId) return;
    this.apiService.get(`WasherOrder/${this.washerId}/orders`).subscribe({
      next: (data) => {
        this.orders = data;
      },
      error: (err) => {
        console.error("Failed to fetch orders:", err);
      },
    });
  }

  fetchRatings() {
    if (!this.washerId) return;
    this.apiService.get(`Ratings/washer/${this.washerId}`).subscribe({
      next: (data) => {
        this.ratings = data;
      },
      error: (err) => {
        console.error("Failed to fetch ratings:", err);
      },
    });
  }

  selectOrder(order: any) {
    this.selectedOrder = order;
  }

  updateOrderStatus() {
    if (this.selectedOrder && this.status) {
      if (this.lastUpdatedOrderIds.has(this.selectedOrder.id)) {
        alert("This order has already been updated.");
        return;
      }

      this.apiService.put(`WasherOrder/${this.selectedOrder.id}/status`, {
        status: this.status,
        comment: this.comment
      }).subscribe({
        next: () => {
          alert('Order Updated Successfully');
          this.lastUpdatedOrderIds.add(this.selectedOrder.id);
          this.fetchOrders();
          this.selectedOrder = null;
          this.status = '';
          this.comment = '';
        },
        error: (err) => {
          console.error("Update Failed:", err);
        }
      });
    }
  }
}