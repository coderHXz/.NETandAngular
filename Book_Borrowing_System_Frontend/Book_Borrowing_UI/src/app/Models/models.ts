export interface SideNavItem {
    title: string;
    link: string;
}

export interface BookModel {
    id: number;
    name: string;
    rating: number;
    author: string;
    genre: string;
    description: string;
    isBookAvailable: boolean;
    lent_By_User_Id: number;
    borrowedByUserId?: number;
}

export interface AddBookModelDTO {
    name: string;
    rating: number;
    author: string;
    genre: string;
    description: string;
    lent_By_User_Id: number;
}

export interface BookModelDTO {
    id: number;
    name: string;
    author: string;
    genre: string;
}

export interface Book {
    id: number;
    name: string;
    rating: number;
    author: string;
    genre: string;
    description: string;
    is_Book_Available: boolean;
    lender: string;
}

export interface UserDTO {
    name:string;
    tokens: any;
}

export interface UserModel {
    userId: number;
    name: string;
    username: string;
    password: string;
    tokensAvailable: number;
    booksBorrowed?: BookModel[];
    booksLent?: BookModel[];
}

// export interface BookDetailDTO{

// }

// export interface UserBookDetailDTO{

// }
