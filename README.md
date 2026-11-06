# MiniEcommerce

Atividade de Garantia da Qualidade de Software â€” professor Daniel Henrique Matos de Paiva.

## Tecnologias

- .NET 10 e C#
- xUnit para testes unitarios
- Git e Conventional Commits

## Arquitetura

- `MiniEcommerce.Console`: aplicacao de console, entidades `Produto`, `Catalogo`, `CarrinhoDeCompras` e `Pedido`.
- `MiniEcommerce.Tests`: testes unitarios de produto, carrinho e checkout.

## Regras

1. Produtos exigem nome, preco nao negativo e estoque nao negativo.
2. Carrinho nao aceita quantidade maior que o estoque nem valores menores ou iguais a zero.
3. Checkout calcula total, diminui estoque e esvazia o carrinho.
4. Menu permite cadastrar, listar, adicionar/remover itens e finalizar compra.

## Executar

```powershell
dotnet run --project MiniEcommerce.Console/MiniEcommerce.Console.csproj
```

## Testar

```powershell
dotnet test
```

## Historico

Commits separados por etapa, seguindo `chore`, `test`, `feat`, `refactor` e `docs`.

## Equipe

Preencha com seu nome e nomes dos colegas, se aplicavel. A entrega no GitHub deve ser individual.