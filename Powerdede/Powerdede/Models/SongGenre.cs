using System.ComponentModel;

namespace Powerdede.Models
{
    public class SongGenre
    {
        public int Id { get; set; }
        [DisplayName("Género")]
        public string Name { get; set; }
    }
}