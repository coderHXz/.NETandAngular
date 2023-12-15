import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  hide = true;
  loginForm: FormGroup;

  constructor(private fb: FormBuilder, private loginservice: LoginService, private router: Router, private snackbar: MatSnackBar){
    this.loginForm = fb.group({
      username: fb.control('', [Validators.required]),
      password: fb.control('', [
        Validators.required,
        Validators.minLength(8),
        Validators.maxLength(15),
      ])
    })
  }

  getUsernameErrors() {
    if (this.Username.hasError('required')) return 'Username is required!';
    return '';
  }

  getPasswordErrors() {
    if (this.Password.hasError('required')) return 'Password is required!';
    if (this.Password.hasError('minlength'))
      return 'Minimum 8 characters are required!';
    if (this.Password.hasError('maxlength'))
      return 'Maximum 15 characters are required!';
    return '';
  }

  login() {
    const username = this.loginForm.get('username')?.value;
    const password = this.loginForm.get('password')?.value;
    this.loginservice.login(username,password).subscribe(() => {
      this.loginForm.reset();
      this.snackbar.open('Login Successful', 'Close', { duration: 5000 });
      this.router.navigateByUrl('/').then(() => {
        window.location.reload();
      });
    });
  }

  get Username(): FormControl {
    return this.loginForm.get('username') as FormControl;
  }
  get Password(): FormControl {
    return this.loginForm.get('password') as FormControl;
  }
}
