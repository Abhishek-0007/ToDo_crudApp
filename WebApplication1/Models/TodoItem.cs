using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("todoTbl")]
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }

        [JsonIgnore]
        public bool? isComplete { get; set; } = false;

        [JsonIgnore]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

    }
}
