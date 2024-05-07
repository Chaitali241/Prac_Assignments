using System.ComponentModel.DataAnnotations;

namespace Prac_assignments.Model
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required]
        public int  Age { get; set; }
        [Required]
        public _Gender Gender { get; set; }
        public string? AboutMe { get; set; }
        public enum _Gender
        {
            Male,
            Female,
            Other
        }

    }
}
