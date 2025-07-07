import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { jwtDecode } from 'jwt-decode';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class ApiServiceService {
  baseUrl = 'http://localhost:5068/api';

  constructor(private http: HttpClient) { }

  private getHeaders(): HttpHeaders {
    const token = this.getToken();
    let headers = new HttpHeaders();
    if (token) {
      headers = headers.set('Authorization', `Bearer ${token}`);
    }
    return headers;
  }

  get(endpoint: string): Observable<any> {
    return this.http.get(`${this.baseUrl}/${endpoint}`, { headers: this.getHeaders() }).pipe(
      catchError((error) => {
        console.error('API GET Error:', error);
        return throwError(error);
      })
    );
  }
  getUserId(): string | null {
    const token = this.getToken();
    if (!token) return null;

    try {
      const decodedToken: any = jwtDecode(token);
      return decodedToken["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"] || null;
    } catch (error) {
      console.error("JWT Decoding Error:", error);
      return null;
    }
  }

  post(endpoint: string, body: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/${endpoint}`, body, { headers: this.getHeaders(), responseType: 'text' }).pipe(
      catchError((error) => {
        console.error('API POST Error:', error);
        return throwError(error);
      })
    );
  }

  put(endpoint: string, body: any): Observable<any> {
    return this.http.put(`${this.baseUrl}/${endpoint}`, body, { headers: this.getHeaders() }).pipe(
      catchError((error) => {
        console.error('API PUT Error:', error);
        return throwError(error);
      })
    );
  }

  delete(endpoint: string): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${endpoint}`, { headers: this.getHeaders() }).pipe(
      catchError((error) => {
        console.error('API DELETE Error:', error);
        return throwError(error);
      })
    );
  }

  setToken(token: string): void {
    localStorage.setItem('token', token);
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  getRole(): string | null {
    const token = this.getToken();
    if (!token) return null;

    const decodedToken: any = jwtDecode(token);
    return decodedToken.role || 'Unknown';
  }

  isLoggedIn(): boolean {
    return this.getToken() !== null;
  }

  logout(): void {
    localStorage.removeItem('token');
  }
}