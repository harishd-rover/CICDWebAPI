using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManageAPI.Models;

namespace TaskManageAPI.Data
{
    public class TaskManageAPIContext : DbContext
    {
        public TaskManageAPIContext (DbContextOptions<TaskManageAPIContext> options)
            : base(options)
        {
        }

        public DbSet<TaskManageAPI.Models.MyTask> MyTask { get; set; }

      



        public DbSet<TaskManageAPI.Models.Owner> Owner { get; set; }
    }
}
