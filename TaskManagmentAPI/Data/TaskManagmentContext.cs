using Microsoft.EntityFrameworkCore;
using TaskManagmentAPI.Models;

namespace TaskManagmentAPI.Data
{
    public class TaskManagmentContext : DbContext
    {
       public TaskManagmentContext(DbContextOptions<TaskManagmentContext> options) : base(options) { }

       public DbSet<TaskItem> TaskItems { get; set; }
       
       public DbSet<User> User { get; set; }
    }
}
