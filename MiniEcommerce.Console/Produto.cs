namespace MiniEcommerce.ConsoleApp;

public class Produto
{
    public string Nome { get; }
    public decimal Preco { get; }
    public int QuantidadeEstoque { get; private set; }

    public Produto(string nome, decimal preco, int quantidadeEstoque)
    {
        if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("Nome obrigatorio.", nameof(nome));
        if (preco < 0) throw new ArgumentOutOfRangeException(nameof(preco), "Preco nao pode ser negativo.");
        if (quantidadeEstoque < 0) throw new ArgumentOutOfRangeException(nameof(quantidadeEstoque), "Estoque nao pode ser negativo.");
        Nome = nome;
        Preco = preco;
        QuantidadeEstoque = quantidadeEstoque;
    }

    public void BaixarEstoque(int quantidade)
    {
        if (quantidade <= 0 || quantidade > QuantidadeEstoque)
            throw new InvalidOperationException("Quantidade invalida ou estoque insuficiente.");
        QuantidadeEstoque -= quantidade;
    }
}