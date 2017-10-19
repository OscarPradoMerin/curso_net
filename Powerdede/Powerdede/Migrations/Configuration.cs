using Powerdede.Models;

namespace Powerdede.Migrations {
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Powerdede.Models.ApplicationDbContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Powerdede.Models.ApplicationDbContext context) {
            // Seed SongGenres
            context.SongGenres.AddOrUpdate(
                new SongGenre { Id = 1, Name = "Rock"},
                new SongGenre { Id = 2, Name = "Blues" },
                new SongGenre { Id = 3, Name = "Country" },
                new SongGenre { Id = 4, Name = "Electronic" },
                new SongGenre { Id = 5, Name = "Folk" },
                new SongGenre { Id = 6, Name = "Hip hop" },
                new SongGenre { Id = 7, Name = "Jazz" },
                new SongGenre { Id = 8, Name = "Latin" },
                new SongGenre { Id = 9, Name = "Pop" },
                new SongGenre { Id = 10, Name = "Heavy Metal" },
                new SongGenre { Id = 11, Name = "Dubstep" },
                new SongGenre { Id = 12, Name = "Classical" }
            );

            // Seed MovieGenres
            context.VideoGenres.AddOrUpdate(
                new VideoGenre { Id = 1, Name = "Action" },
                new VideoGenre { Id = 2, Name = "Comedy" },
                new VideoGenre { Id = 3, Name = "Fantasy" },
                new VideoGenre { Id = 4, Name = "Adventure" },
                new VideoGenre { Id = 5, Name = "Drama" },
                new VideoGenre { Id = 6, Name = "Crime" },
                new VideoGenre { Id = 7, Name = "Mystery" },
                new VideoGenre { Id = 8, Name = "Historical" },
                new VideoGenre { Id = 9, Name = "Horror" },
                new VideoGenre { Id = 10, Name = "Philosophical" },
                new VideoGenre { Id = 11, Name = "Political" },
                new VideoGenre { Id = 12, Name = "Romance" },
                new VideoGenre { Id = 13, Name = "Science fiction" },
                new VideoGenre { Id = 14, Name = "Thriller" }
            );

            // Seed Authors
            context.Authors.AddOrUpdate(
                new Author { Id = 1, Name = "Nirvana" },
                new Author { Id = 2, Name = "AC/DC" },
                new Author { Id = 3, Name = "The Rolling Stones" },
                new Author { Id = 4, Name = "The Beatles" },
                new Author { Id = 5, Name = "Guns n Roses" },
                new Author { Id = 6, Name = "Linkin Park" },
                new Author { Id = 7, Name = "Billy Talent" },
                new Author { Id = 8, Name = "Biffy Clyro" },
                new Author { Id = 9, Name = "The Offspring" },
                new Author { Id = 10, Name = "Bad Religion" },
                new Author { Id = 11, Name = "Rise Against" },
                new Author { Id = 12, Name = "Slipknot" },
                new Author { Id = 13, Name = "Oasis" }
            );

            // Commit changes to database
            context.SaveChanges();
        }
    }
}