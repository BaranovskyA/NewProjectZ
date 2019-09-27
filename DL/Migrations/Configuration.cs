namespace DataLayer.Migrations
{
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
            DataLayer.Entities.Authors author1 = new Entities.Authors {Id = 1,FirstName = "Alexander", LastName = "Pishkin"};
            DataLayer.Entities.Authors author2 = new Entities.Authors {Id = 2,FirstName = "Lev", LastName = "Tolstoy"};
            context.Authors.Add(author1);
            context.Authors.Add(author2);
            context.SaveChanges();
            DataLayer.Entities.Genre genre1 = new Entities.Genre {Id = 1, Name = "Action"};
            DataLayer.Entities.Genre genre2 = new Entities.Genre {Id = 2, Name = "Detective"};
            context.Genre.Add(genre1);
            context.Genre.Add(genre2);
            context.SaveChanges();
            DataLayer.Entities.Books book1 = new Entities.Books {Id = 1, AuthorId = 1, Title = "TestBook1", GenreId = 1, Price = 1000, Pages = 150};
            DataLayer.Entities.Books book2 = new Entities.Books {Id = 2, AuthorId = 2, Title = "TestBook2", GenreId = 2, Price = 3000, Pages = 200};
            context.Books.Add(book1);
            context.Books.Add(book2);
            context.SaveChanges();
            DataLayer.Entities.Users user1 = new Entities.Users {Id = 1, Email = "testUser1@mail.ru", Name = "TestUser1"};
            DataLayer.Entities.Users user2 = new Entities.Users {Id = 2, Email = "testUser2@mail.ru", Name = "TestUser2"};
            context.Users.Add(user1);
            context.Users.Add(user2);
            context.SaveChanges();

        }
    }
}
