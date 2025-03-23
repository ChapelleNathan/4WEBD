using Microsoft.EntityFrameworkCore;

namespace TicketApi.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DataContext() {}
}