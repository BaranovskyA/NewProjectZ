namespace DataLayer.Migrations
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataLayer.Entities.Model1>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataLayer.Entities.Model1 context)
        {
            Authors author1 = new Entities.Authors { Id = 1, FirstName = "Alexander", LastName = "Pishkin" };
            Authors author2 = new Entities.Authors { Id = 2,FirstName = "Lev", LastName = "Tolstoy" };
            context.Authors.AddOrUpdate(author1);
            context.Authors.AddOrUpdate(author2);
            Genre genre1 = new Entities.Genre { Id = 1, Name = "Action" };
            Genre genre2 = new Entities.Genre { Id = 2,Name = "Detective" };
            context.Genre.AddOrUpdate(genre1);
            context.Genre.AddOrUpdate(genre2);
            Books book1 = new Entities.Books { Id = 1,AuthorId = 1, Title = "TestBook1", GenreId = 1, Price = 1000, Pages = 150 };
            Books book2 = new Entities.Books { Id = 2,AuthorId = 2, Title = "TestBook2", GenreId = 2, Price = 3000, Pages = 200 };
            context.Books.AddOrUpdate(book1);
            context.Books.AddOrUpdate(book2);
            Users user1 = new Entities.Users { Id = 1,Email = "testUser1@mail.ru", Name = "TestUser1" };
            Users user2 = new Entities.Users { Id = 2,Email = "testUser2@mail.ru", Name = "TestUser2" };
            context.Users.AddOrUpdate(user1);
            context.Users.AddOrUpdate(user2);
        }
    }
}
