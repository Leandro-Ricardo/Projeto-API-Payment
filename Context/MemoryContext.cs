using Microsoft.EntityFrameworkCore;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Context
{
    public class MemoryContext : DbContext
    {
        public MemoryContext(DbContextOptions<MemoryContext> options) : base (options)
        {
            
        }
        public DbSet<Vendedor> Vendedores { get; set; }        
    }
}