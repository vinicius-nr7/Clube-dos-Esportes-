# ClubeDosEsportes

Este projeto é um aplicativo de console em C# (.NET 10) que simula um clube de séries esportivas. Ele mostra como fazer um menu interativo com operações básicas de cadastro, edição, exclusão e pesquisa.

## Estrutura do projeto

- `Interfaces/Program.cs`
  - Contém o menu principal e os métodos para inserir, excluir, visualizar, atualizar e pesquisar séries esportivas.
  - Usa uma lista em memória de objetos `Esporte`.
- `Classe/Esporte.cs`
  - Modelo simples de um esporte com `Id`, `Titulo`, `Ano` e `Descricao`.
- `Classe/SerieRepositorio.cs`
  - Repositório genérico para trabalhar com objetos `Serie` e persistir dados em `series.json` usando `System.Text.Json`.
- `Classe/Serie.cs`
  - Define a entidade `Serie`, com propriedades como `Genero`, `Titulo`, `Descricao`, `Ano` e `Excluido`.
- `Classe/EntidadeBase.cs`
  - Classe base para entidades com propriedade `Id`.
- `Enum/Genero.cs`
  - Enumeração de gêneros esportivos.
- `Interfaces/IRepositorio.cs`
  - Interface genérica para repositórios com operações CRUD.

## Como o código funciona

O `Program.cs` cria um menu que mostra opções para o usuário. Cada opção chama um método diferente:

1. `Inserir()`
   - Pede título, ano e descrição.
   - Cria um novo `Esporte` e adiciona na lista.
2. `Excluir()`
   - Pede o `Id` da série para remover.
   - Remove o item da lista se encontrado.
3. `Visualizar()`
   - Mostra todas as séries atualmente cadastradas na lista.
4. `Atualizar()`
   - Pede o `Id` da série e sobrescreve título, ano e descrição.
5. `Limpar Tela`
   - Executa `Console.Clear()` para limpar a tela do terminal.
6. `Pesquisar por gênero`
   - Exibe os valores da enum `Genero` e pede um número.
   - Busca o item correspondente ao número informado.

## Observação importante

- `Program.cs` usa apenas a lista de `Esporte` em memória. Isso significa que, ao fechar o aplicativo, as alterações não são salvas automaticamente.
- A classe `SerieRepositorio` está preparada para salvar e carregar séries de `series.json`, mas não está integrada ao menu atual. Ela é um bom exemplo de como implementar persistência usando JSON.

## Passo a passo para testar

1. Abra o terminal no diretório do projeto `ClubeDosEsportes`.
2. Compile o projeto:

```powershell
dotnet build
```

3. Execute o projeto:

```powershell
dotnet run
```

4. Use o menu no console:
   - Digite `1` para inserir uma nova série.
   - Digite `2` para excluir uma série existente.
   - Digite `3` para visualizar todas as séries.
   - Digite `4` para atualizar uma série.
   - Digite `5` para limpar a tela.
   - Digite `6` para pesquisar por gênero.
   - Digite `7` para sair.

5. Teste um fluxo simples:
   - Escolha `3` para ver as séries iniciais.
   - Escolha `1` e adicione uma nova série.
   - Escolha `3` novamente para confirmar que a nova série foi adicionada.
   - Escolha `4` para alterar algum item.
   - Escolha `2` para remover um item.

## Dicas para quem está iniciando

- Olhe o método `Main()` e veja como ele usa um `while` para manter o menu ativo até o usuário escolher sair.
- Observe como cada operação é isolada em um método próprio. Isso deixa o código mais fácil de entender e manter.
- Experimente adicionar validações extras, como impedir títulos vazios ou anos muito antigos.
- Para aprender sobre persistência, tente integrar `SerieRepositorio` ao menu, substituindo a lista em memória por um repositório que salva em `series.json`.

## Próximos passos

Se quiser evoluir este projeto, você pode:

- Integrar o `SerieRepositorio` ao menu principal.
- Ajustar a pesquisa por gênero para usar realmente a propriedade `Genero` de `Serie`.
- Adicionar novas opções ao menu, como listar apenas séries não excluídas.
- Criar testes unitários para cada método do repositório e do menu.
