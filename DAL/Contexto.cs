using AportesBlazor.Models;
using Microsoft.EntityFrameworkCore;

namespace AportesBlazor.DAL
{
    public class Contexto:DbContext
    {
        public DbSet<Aportes> aportes { get; set; }
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            
        }
    }
}
