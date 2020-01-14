using System.ComponentModel.DataAnnotations.Schema;

namespace TestTaskKolgatina.Models
{
    [Table("passport")]
    public class Passport
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }
    }
}
