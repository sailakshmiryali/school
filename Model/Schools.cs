using System.ComponentModel.DataAnnotations;

namespace School.Model
{
    public class Schools
    {

        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
    }
}
