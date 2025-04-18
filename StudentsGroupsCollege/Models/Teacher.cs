using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace StudentsGroupsCollege.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [StringLength(50)]
        public string? Position { get; set; }

        public int CollegeId { get; set; }

        [ValidateNever]
        public College College { get; set; } = null!;

        public ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
    }
}
