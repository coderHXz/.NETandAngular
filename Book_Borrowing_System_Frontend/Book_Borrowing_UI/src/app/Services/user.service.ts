import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginService } from './login.service';
import { Observable } from 'rxjs';
import { UserDTO } from '../Models/models';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = 'https://localhost:44327/api/User'
  constructor(private http: HttpClient, private loginservice: LoginService) { }

  getUsernameandTokenById(id: number): Observable<UserDTO> {
    const url = `${this.apiUrl}/username/${id}`;
    return this.http.get<UserDTO>(url)
  }

  BorrowBook(userId: number, bookId: number): Observable<any> {
    console.log(userId)
    const url = `${this.apiUrl}?userId=${userId}&bookId=${bookId}`;
    return this.http.post<any>(url,{});
  }

  GetUserBookDetails(userId: number): Observable<any> {
    const url = `${this.apiUrl}/${userId}`;
    return this.http.get<any>(url);
  }

  ReturnBook(userId:number, bookId:number): Observable<any> {
    const url = `${this.apiUrl}/${userId}/${bookId}`;
    return this.http.put<any>(url,{});
  }
}
