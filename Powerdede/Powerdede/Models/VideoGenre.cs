using System.ComponentModel;

namespace Powerdede.Models
{
    public class VideoGenre
    {
        public int Id { get; set; }
        [DisplayName("Nombre")]
        public string Name { get; set; }
    }
}