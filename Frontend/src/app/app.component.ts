import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { NavbarComponent } from './shared/pages/navbar/navbar/navbar.component';
import { FooterComponent } from "./shared/pages/footer/footer/footer.component";


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NavbarComponent, FooterComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Frontend';

  constructor(private router: Router) { }
  get isLoggedIn(): boolean{
    return !!localStorage.getItem('token');
  }
  logout() {
    localStorage.removeItem('token');
    alert('Logged out successfully');
    this.router.navigate(['/login']);
  }
}