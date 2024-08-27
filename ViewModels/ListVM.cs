using System.ComponentModel.DataAnnotations;

namespace TaskToDoList.ViewModels
{
    public class ListVM
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime Deadline { get; set; }
    }
}
