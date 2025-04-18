using System.ComponentModel.DataAnnotations;

namespace StudentsGroupsCollege.Models
{
    public class College
    {        

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="College")]
        public string Name { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Description { get; set; } = string.Empty;

        public ICollection<CollegeGroup> CollegeGroups { get; set; } = new List<CollegeGroup>();
        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
        public ICollection<Staff> Staffs { get; set; } = new List<Staff>();
    }
}
