import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BookModel, BookModelDTO } from 'src/app/Models/models';
import { HomeService } from 'src/app/Services/home.service';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})


export class HomeComponent implements OnInit{
  books: BookModelDTO[] = [];
  filteredBooks: BookModelDTO[] = [];
  filterName: string = '';
  filterAuthor: string = '';
  filterGenre: string = '';

  constructor(
    private homeService: HomeService,
    public loginservice: LoginService,
    private router: Router
  ) {}
  
  ngOnInit(): void {
    this.getBooks();
  }

  gridColumns = 3;

  toggleGridColumns() {
    this.gridColumns = this.gridColumns === 3 ? 4 : 3;
  }

  navigateToBookDetails(bookId: number) {
    this.router.navigate(['/book', bookId]);
  }

  getBooks() {
    this.homeService.getBooks().subscribe(
      (books: BookModelDTO[]) => {
        this.books = books;
        console.log(books)
        this.applyFilters(); 
      },
      (error) => {
        console.error('Error fetching books:', error);
      }
    );
  }

  applyFilters() {
    this.filteredBooks = this.books.filter((book) =>
      (!this.filterName || book.name.toLowerCase().includes(this.filterName.toLowerCase())) &&
      (!this.filterAuthor || book.author.toLowerCase().includes(this.filterAuthor.toLowerCase())) &&
      (!this.filterGenre || book.genre.toLowerCase().includes(this.filterGenre.toLowerCase()))
    );
  }

}


