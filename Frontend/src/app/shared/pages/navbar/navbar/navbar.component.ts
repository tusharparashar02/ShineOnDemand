import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  constructor(private router: Router) { }

  showDropdown = false;

  toggleDropdown() {
    this.showDropdown = !this.showDropdown;
  }

  get isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  get userRole(): string | null {
    return localStorage.getItem('role'); // Retrieve stored role
  }

  logout(): void {
    localStorage.removeItem('token');
    localStorage.removeItem('role');
    alert('Logged out successfully');
    this.router.navigate(['/']);
  }

  navigateToDashboard(): void {
    if (this.isLoggedIn) {
      const routes: Record<string, string> = {
        CUSTOMER: '/customer-dashboard',
        WASHER: '/washer-dashboard',
        ADMIN: '/admin-dashboard',
      };

      const role = this.userRole || 'UNKNOWN';
      if (routes[role]) {
        this.router.navigate([routes[role]]);
      } else {
        alert('Invalid role detected. Redirecting to home.');
        this.router.navigate(['/']);
      }
    } else {
      this.router.navigate(['/login']);
    }
  }
  closeDropdown() {
    this.showDropdown = false;
  }
}