import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApiServiceService } from '../../../../api-service/service/api-service.service';

@Component({
  selector: 'app-order-addons',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './order-addons.component.html',
  styleUrls: ['./order-addons.component.css']
})
export class OrderAddonsComponent {
  addons: any[] = [];

  constructor(private apiService: ApiServiceService) {}

  ngOnInit() {
    this.apiService.get('OrderAddOns').subscribe(data => {
      this.addons = data;
    });
  }
}