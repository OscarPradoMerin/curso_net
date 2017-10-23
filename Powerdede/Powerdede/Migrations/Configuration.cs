using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Powerdede.Data;
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
                new SongGenre {Id = 1, Name = "Rock"},
                new SongGenre {Id = 2, Name = "Blues"},
                new SongGenre {Id = 3, Name = "Country"},
                new SongGenre {Id = 4, Name = "Electronic"},
                new SongGenre {Id = 5, Name = "Folk"},
                new SongGenre {Id = 6, Name = "Hip hop"},
                new SongGenre {Id = 7, Name = "Jazz"},
                new SongGenre {Id = 8, Name = "Latin"},
                new SongGenre {Id = 9, Name = "Pop"},
                new SongGenre {Id = 10, Name = "Heavy Metal"},
                new SongGenre {Id = 11, Name = "Dubstep"},
                new SongGenre {Id = 12, Name = "Classical"}
            );

            // Seed MovieGenres
            context.VideoGenres.AddOrUpdate(
                new VideoGenre {Id = 1, Name = "Action"},
                new VideoGenre {Id = 2, Name = "Comedy"},
                new VideoGenre {Id = 3, Name = "Fantasy"},
                new VideoGenre {Id = 4, Name = "Adventure"},
                new VideoGenre {Id = 5, Name = "Drama"},
                new VideoGenre {Id = 6, Name = "Crime"},
                new VideoGenre {Id = 7, Name = "Mystery"},
                new VideoGenre {Id = 8, Name = "Historical"},
                new VideoGenre {Id = 9, Name = "Horror"},
                new VideoGenre {Id = 10, Name = "Philosophical"},
                new VideoGenre {Id = 11, Name = "Political"},
                new VideoGenre {Id = 12, Name = "Romance"},
                new VideoGenre {Id = 13, Name = "Science fiction"},
                new VideoGenre {Id = 14, Name = "Thriller"}
            );

            // Seed Authors
            context.Authors.AddOrUpdate(
                new Author {Id = 1, Name = "Nirvana"},
                new Author {Id = 2, Name = "AC/DC"},
                new Author {Id = 3, Name = "The Rolling Stones"},
                new Author {Id = 4, Name = "The Beatles"},
                new Author {Id = 5, Name = "Guns n Roses"},
                new Author {Id = 6, Name = "Linkin Park"},
                new Author {Id = 7, Name = "Billy Talent"},
                new Author {Id = 8, Name = "Biffy Clyro"},
                new Author {Id = 9, Name = "The Offspring"},
                new Author {Id = 10, Name = "Bad Religion"},
                new Author {Id = 11, Name = "Rise Against"},
                new Author {Id = 12, Name = "Slipknot"},
                new Author {Id = 13, Name = "Oasis"}
            );

            // Seed Roles

            if (!context.Roles.Any(r => r.Name == RolesData.Admin)) {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole {Name = RolesData.Admin};

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == RolesData.Moderator)) {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole {Name = RolesData.Moderator};

                manager.Create(role);
            }

            // Seed Users
            ApplicationUser user;
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            //****************     ADMIN      ********************
            // If user exists, get it; otherwise, create it
            if (context.Users.Any(u => u.UserName == "oscarprado")) {
                user = context.Users.First(u => u.UserName == "oscarprado");
            } else {
                user = new ApplicationUser {UserName = "oscarprado", Email = "oscarpradomerin@gmail.com"};

                // Create user
                userManager.Create(user, "Cur$0Net");
            }

            //****************     MODERATOR      ********************

            // If user exists, get it; otherwise, create it
            if (context.Users.Any(u => u.UserName == "menospringao")) {
                user = context.Users.First(u => u.UserName == "menospringao");
            } else {
                user = new ApplicationUser {UserName = "menospringao", Email = "menospringao@gmail.com"};

                // Create user
                userManager.Create(user, "Cur$0Net");
            }

            //****************     USER      ********************

            // If user exists, get it; otherwise, create it
            if (context.Users.Any(u => u.UserName == "pringao")) {
                user = context.Users.First(u => u.UserName == "pringao");
            } else {
                user = new ApplicationUser {UserName = "pringao", Email = "pringao@gmail.com"};

                // Create user
                userManager.Create(user, "Cur$0Net");
            }

            // Seed Authors
            context.Authors.AddOrUpdate(
                new Author {Id = 1, Name = "Nirvana"},
                new Author {Id = 2, Name = "AC/DC"},
                new Author {Id = 3, Name = "The Rolling Stones"},
                new Author {Id = 4, Name = "The Beatles"},
                new Author {Id = 5, Name = "Guns n Roses"},
                new Author {Id = 6, Name = "Linkin Park"},
                new Author {Id = 7, Name = "Billy Talent"},
                new Author {Id = 8, Name = "Biffy Clyro"},
                new Author {Id = 9, Name = "The Offspring"},
                new Author {Id = 10, Name = "Bad Religion"},
                new Author {Id = 11, Name = "Rise Against"},
                new Author {Id = 12, Name = "Slipknot"},
                new Author {Id = 13, Name = "Oasis"}
            );

            // Seed Songs
            context.Songs.AddOrUpdate(
                new Song {
                    Id = 1,
                    Title = "Heart-shaped Box",
                    Active = true,
                    AuthorId = 1,
                    Duration = 4,
                    Link = "http://youtube.com",
                    SongGenreId = 1,
                    UploadTime = DateTime.Today
                },
                new Song {
                    Id = 2,
                    Title = "Highway to hell",
                    Active = true,
                    AuthorId = 2,
                    Duration = 4,
                    Link = "http://youtube.com",
                    SongGenreId = 1,
                    UploadTime = DateTime.Today
                },
                new Song {
                    Id = 3,
                    Title = "Paint it, black",
                    Active = true,
                    AuthorId = 3,
                    Duration = 4,
                    Link = "http://youtube.com",
                    SongGenreId = 1,
                    UploadTime = DateTime.Today.AddDays(-5)
                },
                new Song {
                    Id = 4,
                    Title = "Hey Jude",
                    Active = true,
                    AuthorId = 4,
                    Duration = 4,
                    Link = "http://youtube.com",
                    SongGenreId = 1,
                    UploadTime = DateTime.Today.AddDays(-5)
                },
                new Song {
                    Id = 5,
                    Title = "Sweet child o' mine",
                    Active = true,
                    AuthorId = 5,
                    Duration = 4,
                    Link = "http://youtube.com",
                    SongGenreId = 1,
                    UploadTime = DateTime.Today.AddDays(-5)
                },
                new Song {
                    Id = 6,
                    Title = "Castle of glass",
                    Active = true,
                    AuthorId = 6,
                    Duration = 4,
                    Link = "http://youtube.com",
                    SongGenreId = 1,
                    UploadTime = DateTime.Today.AddDays(-5)
                },
                new Song {
                    Id = 7,
                    Title = "Rusted from the rain",
                    Active = true,
                    AuthorId = 7,
                    Duration = 4,
                    Link = "http://youtube.com",
                    SongGenreId = 1,
                    UploadTime = DateTime.Today.AddDays(-5)
                },
                new Song {
                    Id = 8,
                    Title = "Who's got a match?",
                    Active = true,
                    AuthorId = 8,
                    Duration = 4,
                    Link = "http://youtube.com",
                    SongGenreId = 1,
                    UploadTime = DateTime.Today.AddDays(-10)
                },
                new Song {
                    Id = 9,
                    Title = "Self Esteem",
                    Active = true,
                    AuthorId = 9,
                    Duration = 4,
                    Link = "http://youtube.com",
                    SongGenreId = 1,
                    UploadTime = DateTime.Today.AddDays(-10)
                },
                new Song {
                    Id = 10,
                    Title = "21st century digital boy",
                    Active = true,
                    AuthorId = 10,
                    Duration = 4,
                    Link = "http://youtube.com",
                    SongGenreId = 1,
                    UploadTime = DateTime.Today.AddDays(-10)
                },
                new Song {
                    Id = 11,
                    Title = "Re-education",
                    Active = true,
                    AuthorId = 11,
                    Duration = 4,
                    Link = "http://youtube.com",
                    SongGenreId = 1,
                    UploadTime = DateTime.Today.AddDays(-10)
                },
                new Song {
                    Id = 12,
                    Title = "The negative one",
                    Active = true,
                    AuthorId = 12,
                    Duration = 4,
                    Link = "http://youtube.com",
                    SongGenreId = 1,
                    UploadTime = DateTime.Today.AddDays(-10)
                },
                new Song {
                    Id = 13,
                    Title = "Wonderwall",
                    Active = true,
                    AuthorId = 13,
                    Duration = 4,
                    Link = "http://youtube.com",
                    SongGenreId = 1,
                    UploadTime = DateTime.Today.AddDays(-10)
                }
            );


            // Commit changes to database
            context.SaveChanges();
        }
    }
}