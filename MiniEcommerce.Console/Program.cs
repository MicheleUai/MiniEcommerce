using MiniEcommerce.ConsoleApp;

var catalogo = new Catalogo();
var carrinho = new CarrinhoDeCompras();
while (true)
{
    System.Console.WriteLine("\n=== MINI ECOMMERCE ===");
    System.Console.WriteLine("1 - Cadastrar produto");
    System.Console.WriteLine("2 - Listar catalogo");
    System.Console.WriteLine("3 - Adicionar ao carrinho");
    System.Console.WriteLine("4 - Ver carrinho");
    System.Console.WriteLine("5 - Remover do carrinho");
    System.Console.WriteLine("6 - Finalizar pedido");
    System.Console.WriteLine("0 - Sair");
    System.Console.Write("Opcao: ");
    var opcao = System.Console.ReadLine();
    if (opcao == "0") break;
    try
    {
        switch (opcao)
        {
            case "1":
                System.Console.Write("Nome: ");
                var nome = System.Console.ReadLine() ?? "";
                System.Console.Write("Preco (ex.: 40,00): ");
                var preco = decimal.Parse(System.Console.ReadLine() ?? "");
                System.Console.Write("Quantidade em estoque: ");
                var estoque = int.Parse(System.Console.ReadLine() ?? "");
                catalogo.Cadastrar(new Produto(nome, preco, estoque));
                System.Console.WriteLine("Produto cadastrado!");
                break;
            case "2":
                MostrarCatalogo();
                break;
            case "3":
                MostrarCatalogo();
                var produto = EscolherProduto();
                System.Console.Write("Quantidade desejada: ");
                var quantidade = int.Parse(System.Console.ReadLine() ?? "");
                carrinho.Adicionar(produto, quantidade);
                System.Console.WriteLine("Adicionado ao carrinho!");
                break;
            case "4":
                foreach (var item in carrinho.Itens)
                    System.Console.WriteLine($"{item.Produto.Nome}: {item.Quantidade} x {item.Produto.Preco:C} = {item.Subtotal:C}");
                System.Console.WriteLine($"Total: {carrinho.Total:C}");
                break;
            case "5":
                MostrarCatalogo();
                carrinho.Remover(EscolherProduto());
                System.Console.WriteLine("Item removido.");
                break;
            case "6":
                var pedido = Pedido.Finalizar(carrinho);
                System.Console.WriteLine($"Compra concluida! Total: {pedido.Total:C}");
                break;
            default:
                System.Console.WriteLine("Opcao desconhecida.");
                break;
        }
    }
    catch (Exception ex) when (ex is ArgumentException or FormatException or OverflowException or InvalidOperationException)
    {
        System.Console.WriteLine($"Atencao: {ex.Message}");
    }
}

void MostrarCatalogo()
{
    if (catalogo.Produtos.Count == 0) System.Console.WriteLine("Catalogo vazio.");
    for (var i = 0; i < catalogo.Produtos.Count; i++)
    {
        var produto = catalogo.Produtos[i];
        System.Console.WriteLine($"{i + 1} - {produto.Nome} | {produto.Preco:C} | Estoque: {produto.QuantidadeEstoque}");
    }
}

Produto EscolherProduto()
{
    System.Console.Write("Numero do produto: ");
    var indice = int.Parse(System.Console.ReadLine() ?? "") - 1;
    if (indice < 0 || indice >= catalogo.Produtos.Count)
        throw new ArgumentException("Produto nao encontrado.");
    return catalogo.Produtos[indice];
}