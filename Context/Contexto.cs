using Microsoft.EntityFrameworkCore;
using StockAdm.Models;

namespace StockAdm.Context;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) {}

    public DbSet<Produto> Produtos {get;set;}
}