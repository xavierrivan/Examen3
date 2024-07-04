using System.ComponentModel.DataAnnotations;

namespace Examen3.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string Subregion { get; set; }
        public string Status { get; set; }
        public string Code { get; set; } // SCxxxx
    }
}
