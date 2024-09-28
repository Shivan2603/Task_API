using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TaskManagementApp.Models;

namespace TaskManagementApp.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
        }

        public DbSet<AppTask> Tasks { get; set; } 
    }
}