using System.ComponentModel;

namespace Powerdede.Models
{
    public class SongGenre
    {
        public int Id { get; set; }
        [DisplayName("Nombre")]
        public string Name { get; set; }
    }
}