using MiniEcommerce.ConsoleApp;
using Xunit;

namespace MiniEcommerce.Tests;

public class ProdutoTests
{
    [Fact]
    public void NaoPermitePrecoNegativo() => Assert.Throws<ArgumentOutOfRangeException>(() => new Produto("Camisa", -1m, 10));

    [Fact]
    public void NaoPermiteEstoqueNegativo() => Assert.Throws<ArgumentOutOfRangeException>(() => new Produto("Camisa", 40m, -1));

    [Fact]
    public void CadastraProdutoValido()
    {
        var catalogo = new Catalogo();
        catalogo.Cadastrar(new Produto("Camisa", 40m, 10));
        Assert.Single(catalogo.Produtos);
    }
}