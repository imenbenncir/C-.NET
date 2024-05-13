#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
using CRUDelicious.Models;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions options) : base(options) {}

    public DbSet<Dish> Dishs {get;set;}
}