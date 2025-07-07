import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ApiServiceService } from '../../../../api-service/service/api-service.service';

@Component({
  selector: 'app-add-car',
  standalone: true,
  templateUrl: './add-car.component.html',
  styleUrls: ['./add-car.component.css'],
  imports: [FormsModule, CommonModule]
})
export class AddCarComponent implements OnInit {
  car = {
    userId: '',
    model: '',
    carNumber: '',
    year: new Date().getFullYear(),
    isActive: true
  };

  cars: any[] = []; // Store all added cars

  constructor(private apiService: ApiServiceService) {}

  ngOnInit() {
    this.getCars(); // Fetch all cars on load
  }

  addCar() {
    this.apiService.post('Car', this.car).subscribe(response => {
      console.log('Car added successfully:', response);
      this.getCars(); // Refresh list after adding
    });
  }

  getCars() {
    this.apiService.get('Car').subscribe(response => {
      this.cars = response;
    });
  }

  deleteCar(carNumber: string) {
    this.apiService.delete(`Car/${carNumber}`).subscribe({
      next: () => {
        console.log('Car deleted:', carNumber);
        this.cars = this.cars.filter(car => car.carNumber !== carNumber); // Remove it from the UI
      },
      error: (err) => {
        console.error('Delete failed:', err);
        alert('Error: ' + err.error.message); // Show backend error message
      }
    });
  }
}