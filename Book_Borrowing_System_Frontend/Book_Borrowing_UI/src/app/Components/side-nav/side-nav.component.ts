import { Component } from '@angular/core';
import { SideNavItem } from 'src/app/Models/models';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.scss']
})
export class SideNavComponent {

  constructor(public loginService: LoginService){}
  sideNavContent: SideNavItem[] = [
    {
      title: 'VIEW BOOKS',
      link: '',
    },
    {
      title: 'USER BOOK DETAILS',
      link: 'User-Book-Details',
    }
  ]
}
