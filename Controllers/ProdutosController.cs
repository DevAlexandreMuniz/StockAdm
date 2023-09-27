using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockAdm.Context;
using StockAdm.Models;

namespace StockAdm.Controllers;

public class ProdutosController : Controller
{
    private readonly Contexto db;

    public ProdutosController(Contexto contexto)
    {
        db = contexto;
    }
    
    public IActionResult Criar()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Criar(string nome, int quantidade, decimal valor)
    {
        var produto = new Produto(nome, quantidade, valor);

        await db.Produtos.AddAsync(produto);
        await db.SaveChangesAsync();
        
        return View("_cadastradoComSucesso");
    }

    public async Task<IActionResult> Editar(int id)
    {
        var produto = await db.Produtos.SingleOrDefaultAsync(a => a.ProdutoId == id);
         
        return View(produto);
    }

    [HttpPost]
    public async Task<IActionResult> Editar(int produtoId, string nome, int quantidade, decimal valor)
    {
        var produto = await db.Produtos.SingleOrDefaultAsync(a => a.ProdutoId == produtoId);

        produto.Atualizar(nome, quantidade, valor);

        db.Update(produto);
        await db.SaveChangesAsync();

        return View("_cadastradoComSucesso");
    }

    public async Task<IActionResult> Listar()
    {
        var produtos = await db.Produtos.ToListAsync();
        return View(produtos);
    }

    public async Task<IActionResult> Apagar(int produtoId)
    {
        var produto = await db.Produtos
            .SingleOrDefaultAsync(a => a.ProdutoId == produtoId);

        if (produto == null)
            return NotFound();

        return View(produto);
    }

    [HttpPost]
    public async Task<IActionResult> ConfirmarParaApagar(Produto produto)
    {
        if (produto is null)
            throw new ArgumentNullException(nameof(produto));

        db.Produtos.Remove(produto);
        await db.SaveChangesAsync();

        return RedirectToAction(nameof(Listar));
    }
}