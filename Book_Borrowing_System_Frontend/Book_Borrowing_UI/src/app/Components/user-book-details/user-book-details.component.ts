import { Component } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/Services/login.service';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-user-book-details',
  templateUrl: './user-book-details.component.html',
  styleUrls: ['./user-book-details.component.scss']
})
export class UserBookDetailsComponent {
  booksBorrowed: any[] = [];
  booksLent: any[] = [];

  constructor(private userService: UserService, private loginService: LoginService, private router: Router, private snackbar: MatSnackBar) { }

  ngOnInit(): void {
    this.GetUserBookDetails();
  }

  Return(bookId: number){
    const userId = this.loginService.getUserId();
    this.userService.ReturnBook(userId,bookId).subscribe(
      () => {
        this.snackbar.open('Book Returned Successfully!', 'Close', { duration: 3000 });
        window.location.reload();
    },
      (error) => {
      console.error(error);
    });
  }


  GetUserBookDetails(){
    const userId = this.loginService.getUserId();
    if(userId == null){
      this.snackbar.open('Login to see Books Borrowed and Lent by You!!', 'Close', { duration: 5000 });
      this.router.navigateByUrl('/login');
      return;
    }
    this.userService.GetUserBookDetails(userId).subscribe(
      (data: any) => {
        this.booksBorrowed = data.books_Borrowed;
        this.booksLent = data.books_Lent;
      },
      (error) => {
        console.error('Error fetching books data:', error);
      }
    );
  }


}
