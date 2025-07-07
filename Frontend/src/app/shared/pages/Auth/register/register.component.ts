import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ApiServiceService } from '../../../../api-service/service/api-service.service';
import { compileNgModule } from '@angular/compiler';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule,ReactiveFormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  registerForm: FormGroup;
  data:any

  constructor(private fb: FormBuilder, private api:ApiServiceService, private router:Router) {
    this.registerForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(3)]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      role: ['', [Validators.required]],
    });
  }

  onSubmit() {
    if (this.registerForm.valid) {
      // console.log('Form Submitted!', this.registerForm.value);
      this.api.post("Auth/register", this.registerForm.value).subscribe(res => {
        
        if (res) {
          
          this.router.navigate(["login"]);
        }
      })

    }
  }

  // Getters for validation
  get name() { return this.registerForm.get('name'); }
  get email() { return this.registerForm.get('email'); }
  get password() { return this.registerForm.get('password'); }
  get role() { return this.registerForm.get('role'); }
}