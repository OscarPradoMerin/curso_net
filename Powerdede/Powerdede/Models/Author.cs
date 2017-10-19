using System.ComponentModel;

namespace Powerdede.Models
{
    public class Author
    {
        public int Id { get; set; }
        [DisplayName("Nombre")]
        public string Name { get; set; }
        [DisplayName("Apellido")]
        public string Surname { get; set; }
        [DisplayName("Activo")]
        public bool Active { get; set; }
    }
}