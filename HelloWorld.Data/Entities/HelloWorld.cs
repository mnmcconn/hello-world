using System;
using System.ComponentModel.DataAnnotations;
namespace HelloWorld.Data
{
    public class HelloWorld
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Message { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}

