using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace Powerdede.Models {
    public class Song {
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "El título no puede contener más de 50 caracteres")]
        [DisplayName("Título")]
        public string Title { get; set; }
        public string Link { get; set; }
        [DisplayName("Duración")]
        public int Duration { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Fecha Subida")]
        public DateTime UploadTime { get; set; }
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
        public int SongGenreId { get; set; }
        [ForeignKey("SongGenreId")]
        public SongGenre SongGenre { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        [DisplayName("Activo")]
        public bool Active { get; set; }
    }
}