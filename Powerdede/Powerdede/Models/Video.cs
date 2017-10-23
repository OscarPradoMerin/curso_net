using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Powerdede.Models {
    public class Video {
        public int Id { get; set; }
        [DisplayName("Título")]
        public string Title { get; set; }
        [DisplayName("Descripción")]
        public string Description { get; set; }
        [DisplayName("Duración")]
        public int Duration { get; set; }
        [DisplayName("Fecha subida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime UploadTime { get; set; }
        public string Link { get; set; }
        public int VideoGenreId { get; set; }
        [ForeignKey("VideoGenreId")]
        public VideoGenre VideoGenre { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        [DisplayName("Activo")]
        public bool Active { get; set; }
    }
}