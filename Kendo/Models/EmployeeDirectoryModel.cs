using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kendo.Models
{
    public class EmployeeDirectoryModel
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string Position { get; set; }

        public DateTime? HireDate { get; set; }

        public string Phone { get; set; }

        public int? Extension { get; set; }

        public int? ReportsTo { get; set; }

     
    }
}
