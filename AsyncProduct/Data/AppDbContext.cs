using AsyncProduct.Models;
using Microsoft.EntityFrameworkCore;

namespace AsyncProduct.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<ListingRequest> ListingRequests => Set<ListingRequest>();
}