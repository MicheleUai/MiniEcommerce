using MiniEcommerce.ConsoleApp;
using Xunit;

namespace MiniEcommerce.Tests;

public class PedidoTests
{
    [Fact]
    public void FinalizarCompraDescontaEstoqueEGeraTotal()
    {
        var camiseta = new Produto("Camisa", 40m, 10);
        var carrinho = new CarrinhoDeCompras();
        carrinho.Adicionar(camiseta, 2);
        var pedido = Pedido.Finalizar(carrinho);
        Assert.Equal(80m, pedido.Total);
        Assert.Equal(8, camiseta.QuantidadeEstoque);
        Assert.Empty(carrinho.Itens);
    }

    [Fact]
    public void NaoFinalizaCarrinhoVazio()
    {
        Assert.Throws<InvalidOperationException>(() => Pedido.Finalizar(new CarrinhoDeCompras()));
    }
}