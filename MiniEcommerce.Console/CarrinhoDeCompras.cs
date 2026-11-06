namespace MiniEcommerce.ConsoleApp;

public record ItemCarrinho(Produto Produto, int Quantidade)
{
    public decimal Subtotal => Produto.Preco * Quantidade;
}

public class CarrinhoDeCompras
{
    private readonly List<ItemCarrinho> _itens = new();
    public IReadOnlyList<ItemCarrinho> Itens => _itens.AsReadOnly();
    public decimal Total => _itens.Sum(item => item.Subtotal);

    public void Adicionar(Produto produto, int quantidade)
    {
        ArgumentNullException.ThrowIfNull(produto);
        if (quantidade <= 0) throw new ArgumentOutOfRangeException(nameof(quantidade));
        var atual = _itens.FirstOrDefault(item => ReferenceEquals(item.Produto, produto));
        var acumulado = (atual?.Quantidade ?? 0) + quantidade;
        if (acumulado > produto.QuantidadeEstoque)
            throw new InvalidOperationException("Estoque insuficiente.");
        if (atual != null) _itens.Remove(atual);
        _itens.Add(new ItemCarrinho(produto, acumulado));
    }

    public void Remover(Produto produto) => _itens.RemoveAll(item => ReferenceEquals(item.Produto, produto));
    public void Limpar() => _itens.Clear();
}