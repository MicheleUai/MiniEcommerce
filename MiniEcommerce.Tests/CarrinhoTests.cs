using MiniEcommerce.ConsoleApp;
using Xunit;

namespace MiniEcommerce.Tests;

public class CarrinhoTests
{
    [Fact]
    public void AdicionaItemECalculaSubtotal()
    {
        var carrinho = new CarrinhoDeCompras();
        var produto = new Produto("Camisa", 40m, 10);
        carrinho.Adicionar(produto, 2);
        Assert.Equal(80m, carrinho.Total);
    }

    [Fact]
    public void NaoPermiteQuantidadeMaiorQueEstoque()
    {
        var carrinho = new CarrinhoDeCompras();
        var produto = new Produto("Camisa", 40m, 3);
        Assert.Throws<InvalidOperationException>(() => carrinho.Adicionar(produto, 4));
    }

    [Fact]
    public void NaoPermiteUltrapassarEstoqueEmAdicoesSeparadas()
    {
        var carrinho = new CarrinhoDeCompras();
        var produto = new Produto("Camisa", 40m, 3);
        carrinho.Adicionar(produto, 2);
        Assert.Throws<InvalidOperationException>(() => carrinho.Adicionar(produto, 2));
    }

    [Fact]
    public void RemoveItemDoCarrinho()
    {
        var carrinho = new CarrinhoDeCompras();
        var produto = new Produto("Camisa", 40m, 3);
        carrinho.Adicionar(produto, 1);
        carrinho.Remover(produto);
        Assert.Empty(carrinho.Itens);
    }
}