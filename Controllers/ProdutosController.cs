using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockAdm.Context;

namespace StockAdm.Controllers;

public class ProdutosController : Controller
{
    private readonly Contexto db;

    public ProdutosController(Contexto contexto)
    {
        db = contexto;
    }
    
    public async Task<IActionResult> Criar()
    {
        var produtos = await db.Produtos.ToListAsync();
        return View(produtos);
    }
}