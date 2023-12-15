import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Book, UserDTO } from 'src/app/Models/models';
import { HomeService } from 'src/app/Services/home.service';
import { LoginService } from 'src/app/Services/login.service';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-book-details',
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-details.component.scss']
})
export class BookDetailsComponent implements OnInit {
  book: Book | null = null;
  user: UserDTO | null = null;
  tokens: any;
  id: number = 0;

  constructor(
    private homeService: HomeService,
    private userService: UserService,
    private route: ActivatedRoute,
    private loginService : LoginService,
    private snackbar: MatSnackBar,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.id = +params['id'];
      console.log(this.id);
      this.getBookById(this.id);
    });
  }

  getBookById(id: number) {
    this.homeService.getBookById(id).subscribe(
      (getbook: Book | null) => {
        this.book= getbook;
      },
      (error) => {
        console.error('Error fetching book details:', error);
      }
    );
  }

  BorrowBook(){
    if(this.loginService.isLoggedIn()){
    if(this.loginService.getName() == this.book?.lender){
      this.snackbar.open('User Cannot Borrow his own Book', 'Close', {duration: 5000});
      this.router.navigateByUrl('/');
      return;
    }
    }else{
      this.snackbar.open('Please Login!!', 'Close', {duration: 5000});
      this.router.navigateByUrl('/login');
      return;
    }

    var userid = this.loginService.getUserId();
    console.log(userid);

    if(userid){
      this.userService.getUsernameandTokenById(userid).subscribe(
        (getuser: UserDTO | null) => {
          this.user= getuser;
          console.log(this.user);
          this.handleUserData();
        },
        (error) => {
          console.error('Error fetching username and token details:', error);
        }
      );
    }

  }

  handleUserData()
  {
    var userid = this.loginService.getUserId();
    console.log(userid);

    if (this.user?.tokens > 0) {
      this.userService.BorrowBook(userid, this.id).subscribe(
        response => {
          this.snackbar.open('Book Borrowed Successfully', 'Close', { duration: 5000 });
          this.router.navigateByUrl('/').then(() => {
            window.location.reload();
          });
        },
        error => {
          console.error('Error Borrowing Book:', error);
        }
      );
    } else {
      this.snackbar.open('Tokens not Available!', 'Close', { duration: 5000 });
      this.router.navigateByUrl('/');
    }    
  }
}
