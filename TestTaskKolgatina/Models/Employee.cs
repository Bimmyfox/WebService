using System.ComponentModel.DataAnnotations.Schema;

namespace TestTaskKolgatina.Models
{
    [Table("employee")]
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public int CompanyId { get; set; }
        public int IdPassport { get; set; }
        //TODO: Passport { Type string Number string }
    }
}