using Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Data_Access_Layer.Data
{
    public class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using ( var scope = serviceProvider.CreateScope()) 
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDBContext>();

                if (context.Books.Any() || context.Users.Any())
                {
                    return;
                }

                // Seed user
                var users = new[]
                {
                new UserModel
                {
                    Name = "First User",
                    Username = "User1",
                    Password = "User1@#123",
                    Tokens_Available = 0,
                },

                new UserModel
                {
                    Name = "Second User",
                    Username = "User2",
                    Password = "User2@#123",
                    Tokens_Available = 0,
                },

                new UserModel
                {
                    Name = "Third User",
                    Username = "User3",
                    Password = "User3@#123",
                    Tokens_Available = 1,
                },

                new UserModel
                {
                    Name = "Fourth User",
                    Username = "User4",
                    Password = "User4@#123",
                    Tokens_Available = 0,
                }
                };
                context.Users.AddRange(users);
                context.SaveChanges();

                // Seed Books
                var books = new[]
                {
                    new BookModel {
                        Name = "THE SAGE with TWO HORNS",
                        Rating = 4,
                        Author = "SUDHA MURTY", 
                        Genre = "Mythology", 
                        Description = "The Sage With Two Horns is yet another collection of stories from Hindu Mythology, this time featuring the Rishis and Gurus of lore. Sudha Murty has a way of telling stories in a simple, yet thought-provoking way. Even the ones you know always feel different when read from Murty-ji's perspective.", 
                        Is_Book_Available = true, 
                        Lent_By_User_Id = users[0].UserId,
                        Borrowed_By_User_Id = null
                    },

                    new BookModel { 
                        Name = "THE LOVE HYPOTHESIS",
                        Rating=4,
                        Author = "ALI HAZLEWOOD", 
                        Genre = "Romance", 
                        Description = "Hazelwood's science-based rom-com finds a PhD student embarking on a fake relationship with a hot young professor. When a fake relationship between scientists meets the irresistible force of attraction, it throws one woman's carefully calculated theories on love into chaos.", 
                        Is_Book_Available = true, 
                        Lent_By_User_Id = users[1].UserId,
                        Borrowed_By_User_Id = null
                    },

                    new BookModel { 
                        Name = "HOW HUMANS TOOK OVER THE WORLD", 
                        Rating=4,
                        Author = "YUVAL NOAH HARARI", 
                        Genre = "Non-Fiction", 
                        Description = "Acclaimed author Yuval Noah Harari has expertly crafted an extraordinary story of how humans learned to not only survive but also thrive on Earth, complete with maps, a timeline, and full-color illustrations that bring his dynamic, unputdownable writing to life.", 
                        Is_Book_Available = false, 
                        Lent_By_User_Id = users[2].UserId,
                        Borrowed_By_User_Id = users[3].UserId
                    },

                    new BookModel { 
                        Name = "ATOMIC HABITS",
                        Rating=5,
                        Author = "JAMES CLEAR", 
                        Genre = "Self-help", 
                        Description = "Atomic Habits is a self-help book written by James Clear. It falls under the category of personal development and psychology. The book delves into the concept of habits and provides practical strategies for building good habits, breaking bad ones, and making long-lasting changes in various aspects of life.", 
                        Is_Book_Available = true, 
                        Lent_By_User_Id = users[3].UserId,
                        Borrowed_By_User_Id = null
                    }
                };
                context.Books.AddRange(books);
                context.SaveChanges();
            }
           
        }
    }
}
