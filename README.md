Clube dos Esportes - Gestão de Séries e Eventos.

O Clube dos Esportes é uma aplicação de console desenvolvida em C#
Que utiliza conceitos avançados de Programação Orientada a Objetos (POO).
Para gerenciar um catálogo de séries esportivas. 
O projeto foi construído com foco em manutenibilidade e testabilidade,
servindo como base para estudos de automação de testes e garantia de qualidade (QA).

🚀 Funcionalidades
CRUD Completo: Cadastro, listagem, atualização e exclusão (lógica) de séries esportivas.

Persistência de Dados: Armazenamento e recuperação de informações via arquivos JSON (series.json).

Arquitetura Baseada em Interfaces: Uso de contratos (IRepositorio) para desacoplamento de código.

Tratamento de Enums: Organização de categorias esportivas (Futebol, Basquete, UFC, etc.) de forma estruturada.

Tecnologias e Conceitos Aplicados
Linguagem: C# (.NET 10).

Arquitetura: Injeção de dependência e desacoplamento com Interfaces.

Padrões de Projeto: Repository Pattern para abstração da lógica de dados.

Clean Code: Nomenclatura clara de métodos e organização de arquivos por pastas (Classes, Enums, Interfaces).

Foco em Quality Assurance (QA)
Este projeto foi desenvolvido com a mentalidade de um Analista de QA:

Validação de Inputs: O menu trata entradas do usuário com ToUpper() e verificações de tipo.

Edge Cases: Implementação de verificações para IDs inexistentes e tratamento de retornos nulos (Nullability).

Exclusão Lógica: Diferenciação entre remover um registro e apenas marcá-lo como inativo, facilitando auditorias de dados.

Como Rodar o Projeto
Clone o repositório.

Certifique-se de ter o SDK do .NET 10 instalado.

No terminal, execute:

Bash
dotnet run
