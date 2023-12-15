import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BookModelDTO, AddBookModelDTO, Book} from '../Models/models';
import { LoginService } from './login.service';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  private apiUrl = 'https://localhost:44327/api/Home'
  constructor(private http: HttpClient, private loginservice: LoginService) { }

  getBooks(): Observable<BookModelDTO[]> {
    return this.http.get<BookModelDTO[]>(this.apiUrl);
  }

  getBookById(id: number): Observable<Book> {
    const url = `${this.apiUrl}/Id?id=${id}`;
    return this.http.get<Book>(url)
  }

  addBook(book: AddBookModelDTO): Observable<string> {
    const token = this.loginservice.getToken();
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.post<string>(this.apiUrl, book, {headers});
  }

}
