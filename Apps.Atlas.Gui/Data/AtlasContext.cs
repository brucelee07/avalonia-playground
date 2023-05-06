using Apps.Atlas.Gui.Models;
using Microsoft.EntityFrameworkCore;

namespace Apps.Atlas.Gui.Data;

public class AtlasContext: DbContext
{
    public DbSet<Product> Products => Set<Product>();
    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(
            "Data Source=identifier.sqlite");
    }
}