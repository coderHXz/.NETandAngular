import { Component, EventEmitter, Output } from '@angular/core';
import { Router } from '@angular/router';
import { UserDTO } from 'src/app/Models/models';
import { LoginService } from 'src/app/Services/login.service';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {

  user: UserDTO | null = null;
  @Output() menuClicked = new EventEmitter<Boolean>();
  constructor(public loginservice: LoginService, public userService: UserService, private router: Router) {}

  ngOnInit(){
    this.GetToken();
  }

  logout(){
    this.loginservice.logout();
  }

  GetToken(){
    var userId = this.loginservice.getUserId();
    if (userId !== null) {
    this.userService.getUsernameandTokenById(userId).subscribe(
      (getuser: UserDTO | null) => {
        this.user= getuser;
        console.log(this.user)
      },
      (error) => {
        console.error('Error fetching username and token details:', error);
      }
    );
    }
  }
}
