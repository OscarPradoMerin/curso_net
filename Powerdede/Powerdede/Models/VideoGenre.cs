using System.ComponentModel;

namespace Powerdede.Models
{
    public class VideoGenre
    {
        public int Id { get; set; }
        [DisplayName("Género")]
        public string Name { get; set; }
    }
}