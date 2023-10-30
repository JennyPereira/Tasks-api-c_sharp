using Microsoft.EntityFrameworkCore;

namespace TareaApi.Models;

public class TareaContext : DbContext {
    public TareaContext(DbContextOptions<TareaContext> options)
        : base(options)
    {
    }

    public DbSet<Tarea> Tareas { get; set; } = null!;
}
