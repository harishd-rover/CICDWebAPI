using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManageAPI.Models
{
    
    public class Owner
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OwnerId { get; set; }
        [Required]
        public string OwnerName { get; set; }
        public string Email { get; set; }
        
        public ICollection<MyTask>? MyTasks { get; set; }

    }
}
