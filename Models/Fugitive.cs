using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FugitiveManagement.Models
{
    public class Fugitive
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime Dob { get; set; }

        public int CrimeId { get; set; }
        [ForeignKey("CrimeId")]
        public Crime Crime { get; set; }
    }
}
