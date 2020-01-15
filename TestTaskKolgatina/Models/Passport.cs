using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTaskKolgatina.Models
{
    [Table("passport")]
    public class Passport
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }
    }
}
