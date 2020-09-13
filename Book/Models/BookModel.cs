using System;
using System.Data.Entity;
namespace Book.Models
{
    public class BookModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Auther { get; set; }
        public string publisher { get; set; }
        public decimal Price { get; set; }
    }
    public class BookDBContext : DbContext
    {
        public DbSet<BookModel> books { get; set; }
    }
}