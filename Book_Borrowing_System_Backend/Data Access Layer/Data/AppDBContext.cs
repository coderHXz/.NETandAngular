using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<BookModel> Books { get; set; }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserModel>()
                .HasMany(u => u.Books_Borrowed)
                .WithOne()
                .HasForeignKey(b => b.Borrowed_By_User_Id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserModel>()
                .HasMany(u => u.Books_Lent)
                .WithOne()
                .HasForeignKey(b => b.Lent_By_User_Id)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
