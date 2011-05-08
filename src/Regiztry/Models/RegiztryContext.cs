using System.Data.Entity;
using Regiztry.Models;

public class RegiztryContext : DbContext
{
    public DbSet<Merchandise> MerchandiseItems { get; set; }
    public DbSet<MerchRequest> MerchRequests { get; set; }
    public DbSet<MerchSource> MerchSources { get; set; }
    public DbSet<Startup> Startups { get; set; }
}