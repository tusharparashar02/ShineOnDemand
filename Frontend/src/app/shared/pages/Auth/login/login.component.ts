import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ApiServiceService } from '../../../../api-service/service/api-service.service';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginForm: FormGroup;
  isSubmitting = false;

  constructor(private fb: FormBuilder, private api: ApiServiceService, private router: Router) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
    });
  }

  onSubmit() {
    if (this.loginForm.valid) {
      this.isSubmitting = true;

      console.log('Login form submitted:', this.loginForm.value);

      this.api.post("Auth/login", this.loginForm.value).subscribe({
        next: (res: any) => {
          // console.log(res);

          const response = JSON.parse(res);
          const token = response.token;

          if (token && token.trim() !== '') {
            this.api.setToken(token);
            localStorage.setItem('token', token);
            //console.log('Token:', token);

            try {
              const decodedToken: any = jwtDecode(token);
              console.log('Decoded Token:', decodedToken);

              const role = (decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] || 'UNKNOWN').toUpperCase();
              localStorage.setItem('role', role);

              alert(`Login successful! as ${role}`);

              const routes: Record<string, string> = {
                CUSTOMER: '/customer-dashboard',
                WASHER: '/washer-dashboard',
                ADMIN: '/admin-dashboard',
              };

              if (routes[role]) {
                console.log(`Navigating to: ${routes[role]}`);
                this.router.navigate([routes[role]]);
              } else {
                console.error('Invalid role detected:', role);
                alert('Access denied.');
                this.router.navigate(['/']);
              }

              this.isSubmitting = false; // Reset after successful navigation
            } catch (error) {
              console.error('Error decoding token:', error);
              alert('Invalid token received.');
              this.isSubmitting = false;
            }
          } else {
            console.error('Empty or malformed token');
            alert('Login failed! Token is invalid.');
            this.isSubmitting = false;
          }
        },
        error: (err) => {
          console.error('API error:', err);
          alert(err.error.message || 'Login failed!');
          this.isSubmitting = false;
        }
      });
    } else {
      console.error('Form is invalid:', this.loginForm.errors);
    }
  }

  // Getters for validation
  get email() { return this.loginForm.get('email'); }
  get password() { return this.loginForm.get('password'); }
}