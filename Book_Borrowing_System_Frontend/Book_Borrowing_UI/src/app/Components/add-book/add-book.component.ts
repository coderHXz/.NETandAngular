import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { AddBookModelDTO } from 'src/app/Models/models';
import { HomeService } from 'src/app/Services/home.service';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.scss']
})
export class AddBookComponent {

  addBookForm: FormGroup;

  constructor(private fb: FormBuilder, public homeservice: HomeService, private router : Router, private snackbar: MatSnackBar, private loginservice: LoginService) {
    this.addBookForm = fb.group(
     {
      name: ['', Validators.required],
      author: ['', Validators.required],
      rating: ['', [Validators.required,  Validators.pattern('^[1-5]$')]],
      genre: ['', Validators.required],
      description: ['', Validators.required],
      lent_By_User_Id: loginservice.getUserId(), 
     } 
    )
  }

  onSubmit() {
    if (this.addBookForm.valid) {
      const newBook: AddBookModelDTO = this.addBookForm.value;

      this.homeservice.addBook(newBook).subscribe(
        (response) => {
          this.snackbar.open('Book added successfully', 'Close', { duration: 5000 });
          console.log('Book added successfully:', response);
          this.addBookForm.reset();
          this.router.navigateByUrl('/');
        },
        (error) => {
          console.error('Error adding book:', error);
        }
      );
    } else {
      console.error('Form is invalid.');
    }
  }

}
