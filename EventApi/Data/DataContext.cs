using Microsoft.EntityFrameworkCore;

namespace EventApi.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DataContext() {}
}