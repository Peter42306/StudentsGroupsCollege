using System.ComponentModel.DataAnnotations;

namespace StudentsGroupsCollege.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Subject")]
        public string Name { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Description { get; set; }

        public ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
    }
}
