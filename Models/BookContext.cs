using System.Data.Entity;

namespace PhoneBook.Models
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}