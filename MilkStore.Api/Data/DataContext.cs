using Microsoft.EntityFrameworkCore;
using MilkStore.Api.Models;

namespace MilkStore.Api.Data;

public class DataContext : DbContext
{
    
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public DbSet<Milk>Milks { get; set; }
        
}