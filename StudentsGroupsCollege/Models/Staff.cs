using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace StudentsGroupsCollege.Models
{
    public class Staff
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Description { get; set; }
                
        public StaffRole Role { get; set; }

        public int CollegeId { get; set; }

        [ValidateNever]
        public College College { get; set; } = null!;
    }

    public enum StaffRole
    {
        Accountant,
        Supervisor,
        Cleaner,
        Librarian,
        Secretary,
        Security
    }
}
