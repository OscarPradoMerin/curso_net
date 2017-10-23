/*************************************

The contents of this file should be copied into Seed() method of Migrations/Configuration

This will populate our database with songs

*************************************/

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