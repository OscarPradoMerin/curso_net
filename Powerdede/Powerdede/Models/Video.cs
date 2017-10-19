using System;
using System.ComponentModel;
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
        public DateTime UploadTime { get; set; }
        public string Link { get; set; }
        public int VideoGenreId { get; set; }
        [ForeignKey("VideoGenreId")]
        public VideoGenre VideoGenre { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }
        [DisplayName("Activo")]
        public bool Active { get; set; }
    }
}