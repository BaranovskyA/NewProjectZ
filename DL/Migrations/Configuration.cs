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
            DataLayer.Entities.Authors author1 = new Entities.Authors {FirstName = "Alexander", LastName = "Pishkin"};
            DataLayer.Entities.Authors author2 = new Entities.Authors {FirstName = "Lev", LastName = "Tolstoy"};
            context.Authors.AddOrUpdate(author1);
            context.Authors.AddOrUpdate(author2);
            DataLayer.Entities.Genre genre1 = new Entities.Genre {Name = "Action"};
            DataLayer.Entities.Genre genre2 = new Entities.Genre {Name = "Detective"};
            context.Genre.AddOrUpdate(genre1);
            context.Genre.AddOrUpdate(genre2);
            DataLayer.Entities.Books book1 = new Entities.Books {AuthorId = 1, Title = "TestBook1", GenreId = 1, Price = 1000, Pages = 150};
            DataLayer.Entities.Books book2 = new Entities.Books {AuthorId = 2, Title = "TestBook2", GenreId = 2, Price = 3000, Pages = 200};
            context.Books.AddOrUpdate(book1);
            context.Books.AddOrUpdate(book2);
            DataLayer.Entities.Users user1 = new Entities.Users {Email = "testUser1@mail.ru", Name = "TestUser1"};
            DataLayer.Entities.Users user2 = new Entities.Users {Email = "testUser2@mail.ru", Name = "TestUser2"};
            context.Users.AddOrUpdate(user1);
            context.Users.AddOrUpdate(user2);
        }
    }
}
