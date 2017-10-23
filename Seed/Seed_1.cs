/*************************************

The contents of this file should be copied into Seed() method of Migrations/Configuration

This will populate our database with some data in order to practice filtering, deleting, updating...

*************************************/
// Seed SongGenres
context.SongGenres.AddOrUpdate(
	new SongGenre {Name = "Rock"},
	new SongGenre {Name = "Blues" },
	new SongGenre {Name = "Country" },
	new SongGenre {Name = "Electronic" },
	new SongGenre {Name = "Folk" },
	new SongGenre {Name = "Hip hop" },
	new SongGenre {Name = "Jazz" },
	new SongGenre {Name = "Latin" },
	new SongGenre {Name = "Pop" },
	new SongGenre {Name = "Heavy Metal" },
	new SongGenre {Name = "Dubstep" },
	new SongGenre {Name = "Classical" }
);

// Seed MovieGenres
context.VideoGenres.AddOrUpdate(
	new VideoGenre { Name = "Action" },
	new VideoGenre { Name = "Comedy" },
	new VideoGenre { Name = "Fantasy" },
	new VideoGenre { Name = "Adventure" },
	new VideoGenre { Name = "Drama" },
	new VideoGenre { Name = "Crime" },
	new VideoGenre { Name = "Mystery" },
	new VideoGenre { Name = "Historical" },
	new VideoGenre { Name = "Horror" },
	new VideoGenre { Name = "Philosophical" },
	new VideoGenre { Name = "Political" },
	new VideoGenre { Name = "Romance" },
	new VideoGenre { Name = "Science fiction" },
	new VideoGenre { Name = "Thriller" }
);

// Seed Authors
context.Authors.AddOrUpdate(
	new Author { Name = "Nirvana" },
	new Author { Name = "AC/DC" },
	new Author { Name = "The Rolling Stones" },
	new Author { Name = "The Beatles" },
	new Author { Name = "Guns n Roses" },
	new Author { Name = "Linkin Park" },
	new Author { Name = "Billy Talent" },
	new Author { Name = "Biffy Clyro" },
	new Author { Name = "The Offspring" },
	new Author { Name = "Bad Religion" },
	new Author { Name = "Rise Against" },
	new Author { Name = "Slipknot" },
	new Author { Name = "Oasis" }
);

// Commit changes to database
context.SaveChanges();