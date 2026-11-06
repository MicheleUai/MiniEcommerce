# MiniEcommerce

Atividade de Garantia da Qualidade de Software — professor Daniel Henrique Matos de Paiva.

## Autoria

**Michele Carvalho** — desenvolvimento individual.

Este trabalho foi realizado individualmente, incluindo a implementação da aplicação, a elaboração dos testes unitários e a organização do histórico de commits.

## Tecnologias

- .NET 10 e C#
- xUnit para testes unitários
- Git e Conventional Commits

## Arquitetura

- `MiniEcommerce.Console`: aplicação de console, entidades `Produto`, `Catalogo`, `CarrinhoDeCompras` e `Pedido`.
- `MiniEcommerce.Tests`: testes unitários de produto, carrinho e checkout.

## Regras

1. Produtos exigem nome, preço não negativo e estoque não negativo.
2. Carrinho não aceita quantidade maior que o estoque nem valores menores ou iguais a zero.
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

## Histórico

Commits separados por etapa, seguindo `chore`, `test`, `feat`, `refactor` e `docs`.
