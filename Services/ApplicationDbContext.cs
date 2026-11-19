using System;
using CodespacesBlank.Models;
using Microsoft.EntityFrameworkCore;
namespace CodespacesBlank.Services;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }

//this is how I tell efcore to create my table using products
    public DbSet<Products> Products {get; set;}
}
