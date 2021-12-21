using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManageAPI.Models
{
    
    public class MyTask
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MyTaskId { get; set; }
        [Required]
        public string TaskName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime TargetDate { get; set; }
        [Required]
        public string Status { get; set; }
        public string Priority { get; set; }

        public string Tags { get; set; }

        [NotMapped]
        public bool Urgent { get; set; }
        [NotMapped]
        public bool Important { get; set; }

        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
        

    }
}
