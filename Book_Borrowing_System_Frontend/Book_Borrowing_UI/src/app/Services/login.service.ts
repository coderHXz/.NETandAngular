import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  apiUrl = "https://localhost:44327/api/Login";
  private readonly tokenKey = 'jwtToken';
  
  constructor(private http: HttpClient) {}

  login(username: string, password: string): Observable<any> {
    const body = {
      username: username,
      password: password
    };

    console.log(body);
    return this.http.post<any>(this.apiUrl, body).pipe(tap(response => this.saveToken(response)));
  }

  private saveToken(response: any): void {
    const token = response && response.token;
    if (token) {
      localStorage.setItem(this.tokenKey, token);
    }
  }

  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  isLoggedIn(): boolean {
    const token = this.getToken();
    return token !== null;
  }

  logout(): void {
    localStorage.removeItem(this.tokenKey);
  }

  getName(){
    const token =this.getToken();
    if(token){
      const tokenPayload = this.decodeTokenPayload(token);
      var result = tokenPayload ? tokenPayload.name : null;
      return result;
    }
    return null;
  }

  getUserId(): any {
    const token =this.getToken();
    if(token){
      const tokenPayload = this.decodeTokenPayload(token);
      var result = tokenPayload ? tokenPayload.nameid : null;
      return result;
    }
    return null;
  }

  getTokensAvailable(){
    const token =this.getToken();
    if(token){
      const tokenPayload = this.decodeTokenPayload(token);
      var result = tokenPayload ? tokenPayload.Tokens_Available : null;
      return result;
    }
    return null;
  }

  private decodeTokenPayload(token: string): any {
    try {
      const base64Url = token.split('.')[1];
      const base64 = base64Url.replace('-', '+').replace('_', '/');
      return JSON.parse(window.atob(base64));
    } catch (error) {
      return null;
    }
  }
}
