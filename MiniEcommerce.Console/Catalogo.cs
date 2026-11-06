namespace MiniEcommerce.ConsoleApp;

public class Catalogo
{
    private readonly List<Produto> _produtos = new();
    public IReadOnlyList<Produto> Produtos => _produtos.AsReadOnly();

    public void Cadastrar(Produto produto)
    {
        ArgumentNullException.ThrowIfNull(produto);
        _produtos.Add(produto);
    }
}