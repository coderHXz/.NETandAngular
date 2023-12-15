import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './Components/home/home.component';
import { UserBookDetailsComponent } from './Components/user-book-details/user-book-details.component';
import { LoginComponent } from './Components/login/login.component';
import { AddBookComponent } from './Components/add-book/add-book.component';
import { BookDetailsComponent } from './Components/book-details/book-details.component';
import { AuthGuard } from './auth.guard';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'User-Book-Details',
    component: UserBookDetailsComponent
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'add-book',
    component: AddBookComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'book/:id',
    component: BookDetailsComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
