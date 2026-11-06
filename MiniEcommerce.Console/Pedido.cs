namespace MiniEcommerce.ConsoleApp;

public class Pedido
{
    public decimal Total { get; }
    private Pedido(decimal total) => Total = total;

    public static Pedido Finalizar(CarrinhoDeCompras carrinho)
    {
        ArgumentNullException.ThrowIfNull(carrinho);
        if (carrinho.Itens.Count == 0) throw new InvalidOperationException("Carrinho vazio.");
        if (carrinho.Itens.Any(i => i.Quantidade > i.Produto.QuantidadeEstoque))
            throw new InvalidOperationException("Estoque insuficiente para finalizar.");
        var total = carrinho.Total;
        foreach (var item in carrinho.Itens) item.Produto.BaixarEstoque(item.Quantidade);
        carrinho.Limpar();
        return new Pedido(total);
    }
}