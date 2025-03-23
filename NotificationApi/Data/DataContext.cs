using Microsoft.EntityFrameworkCore;

namespace NotificationApi.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DataContext() {}
}