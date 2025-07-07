import { inject } from '@angular/core';
import { ActivatedRouteSnapshot, Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';

export const RoleGuard = (route: ActivatedRouteSnapshot): boolean => {
  const router = inject(Router);
  const token = localStorage.getItem('token');

  if (!token) {
    router.navigate(['/login']);
    return false;
  }

  try {
    const decoded: any = jwtDecode(token);
    const userRole = decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] || 'Unknown';
    
    const expectedRole = route.data['expectedRole'];
    if (userRole === expectedRole) {
      return true;
    } else {
      alert('Access denied.');
      router.navigate(['/']);
      return false;
    }
  } catch (err) {
    console.error('Invalid token', err);
    router.navigate(['/login']);
    return false;
  }
};