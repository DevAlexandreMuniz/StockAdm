namespace StockAdm.Models;

public class Produto
{
    public Produto() {}
    public Produto(string nome, int quantidade, decimal valor)
    {
        Nome = nome;
        Quantidade = quantidade;
        Valor = valor;
    }

    public void Atualizar(string nome, int quantidade, decimal valor)
    {
        Nome = nome;
        Quantidade = quantidade;
        Valor = valor;
    }
    public int ProdutoId{get; set;}

    public string Nome{get; set;}

    public int Quantidade{get;set;}

    public decimal Valor{get;set;}
}