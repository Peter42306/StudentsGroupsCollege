using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace StudentsGroupsCollege.Models
{
    public class CollegeGroup
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Group")]
        public string Name { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Description { get; set; }

        
        public int CollegeId { get; set; }
        [ValidateNever]
        public College College { get; set; } = null!;

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
