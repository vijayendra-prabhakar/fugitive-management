using System.ComponentModel.DataAnnotations;

namespace FugitiveManagement.Models
{
    public class Crime
    {
        [Key]
        public int Id { get; set; }
        public string CrimeName { get; set; }
    }
}
