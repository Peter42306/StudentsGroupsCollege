using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace StudentsGroupsCollege.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Description { get; set; }
        
        public int CollegeGroupId { get; set; }

        [ValidateNever]
        public CollegeGroup CollegeGroup { get; set; } = null!;
    }
}
