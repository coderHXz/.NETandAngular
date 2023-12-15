import { CanActivateFn, Router } from '@angular/router';
import { LoginService } from './Services/login.service';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})

export class AuthGuard {
  constructor(private loginService: LoginService, private router: Router) { }

  canActivate: CanActivateFn = (route, state) => {
    const isAuthenticated = this.loginService.isLoggedIn();

    if (isAuthenticated) {
      return true;
    } else {
      this.router.navigateByUrl('/login');
      return false;
    }
  };

}
