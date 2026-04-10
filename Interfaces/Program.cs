using System;
using System.Collections.Generic;
using ClubeDosEsportes.Enums;

namespace ClubeDosEsportes
{
    class Program
    {
        // Lista inicial de esportes
        static List<Esporte> esportes = new List<Esporte>
        {
            new Esporte(1, "Futebol", 2024, "Série que mostra os bastidores da Copa do Mundo e os maiores craques em ação."),
            new Esporte(2, "Basquete", 2025, "Documentário sobre a NBA e a ascensão de novos talentos."),
            new Esporte(3, "Vôlei", 2023, "Histórias inspiradoras de atletas do vôlei em torneios internacionais."),
            new Esporte(4, "Tênis", 2026, "A trajetória dos grandes campeões de tênis e seus desafios nas quadras."),
            new Esporte(5, "Natação", 2022, "Série sobre treinos intensos e conquistas na natação olímpica."),
            new Esporte(6, "Atletismo", 2021, "Explora corridas, saltos e lançamentos, mostrando a preparação dos atletas."),
            new Esporte(7, "Judô", 2025, "A disciplina e filosofia por trás do judô, com foco em campeonatos mundiais.")
        };

        static void Main(string[] args)
        {
            string opcao = "";

            while (opcao != "7") // enquanto não escolher "Sair"
            {
                Console.WriteLine("==================================");
                Console.WriteLine("        MENU PRINCIPAL");
                Console.WriteLine("==================================");
                Console.WriteLine("1 - Inserir nova série");
                Console.WriteLine("2 - Excluir série");
                Console.WriteLine("3 - Visualizar todas as séries");
                Console.WriteLine("4 - Atualizar série");
                Console.WriteLine("5 - Limpar Tela");
                Console.WriteLine("6 - Pesquisar por gênero");
                Console.WriteLine("7 - Sair");
                Console.WriteLine("==================================");
                Console.Write("Escolha uma opção: ");

                opcao = Console.ReadLine() ?? "";

                switch (opcao)
                {
                    case "1":
                        Inserir();
                        break;
                    case "2":
                        Excluir();
                        break;
                    case "3":
                        Visualizar();
                        break;
                    case "4":
                        Atualizar();
                        break;
                    case "5":
                        Console.Clear();
                        break;
                    case "6":
                        PesquisarPorGenero();
                        break;
                    case "7":
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }
            }
        }

        private static void Inserir()
        {
            Console.WriteLine("=== Inserindo nova série ===");

            Console.Write("Digite o título do esporte: ");
            string titulo = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(titulo))
            {
                Console.WriteLine("Título inválido. Operação cancelada.");
                return;
            }

            Console.Write("Digite o ano da série: ");
            int ano;
            while (!int.TryParse(Console.ReadLine(), out ano))
            {
                Console.Write("Ano inválido. Digite novamente: ");
            }

            Console.Write("Digite a descrição: ");
            string descricao = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(descricao))
            {
                Console.WriteLine("Descrição inválida. Operação cancelada.");
                return;
            }

            int novoId = esportes.Count + 1;

            Esporte novoEsporte = new Esporte(novoId, titulo, ano, descricao);
            esportes.Add(novoEsporte);

            Console.WriteLine("==================================");
            Console.WriteLine("Nova série inserida com sucesso!");
            Console.WriteLine($"{novoEsporte.Id} - {novoEsporte.Titulo} ({novoEsporte.Ano})");
            Console.WriteLine($"Descrição: {novoEsporte.Descricao}");
            Console.WriteLine("==================================");
        }

        private static void Excluir()
        {
            Console.WriteLine("=== Excluindo série ===");
            Console.Write("Digite o Id da série que deseja excluir: ");
            string entrada = Console.ReadLine() ?? "";

            if (int.TryParse(entrada, out int id))
            {
                var esporte = esportes.Find(e => e.Id == id);
                if (esporte != null)
                {
                    esportes.Remove(esporte);
                    Console.WriteLine("Série excluída com sucesso!");
                }
                else
                {
                    Console.WriteLine("Id não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida.");
            }
        }

        private static void Visualizar()
        {
            Console.WriteLine("=== LISTA DE ESPORTES ===");
            foreach (var esporte in esportes)
            {
                Console.WriteLine("==================================");
                Console.WriteLine($"{esporte.Id} - {esporte.Titulo} ({esporte.Ano})");
                Console.WriteLine($"Descrição: {esporte.Descricao}");
                Console.WriteLine("==================================");
            }
        }

        private static void Atualizar()
        {
            Console.WriteLine("=== Atualizando série ===");
            Console.Write("Digite o Id da série que deseja atualizar: ");
            string entrada = Console.ReadLine() ?? "";

            if (int.TryParse(entrada, out int id))
            {
                var esporte = esportes.Find(e => e.Id == id);
                if (esporte != null)
                {
                    Console.Write("Novo título: ");
                    esporte.Titulo = Console.ReadLine() ?? "";

                    Console.Write("Novo ano: ");
                    int novoAno;
                    while (!int.TryParse(Console.ReadLine(), out novoAno))
                    {
                        Console.Write("Ano inválido. Digite novamente: ");
                    }
                    esporte.Ano = novoAno;

                    Console.Write("Nova descrição: ");
                    esporte.Descricao = Console.ReadLine() ?? "";

                    Console.WriteLine("Série atualizada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Id não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida.");
            }
        }

        private static void PesquisarPorGenero()
        {
            Console.WriteLine("=== PESQUISAR POR GÊNERO ===");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }

            Console.Write("Digite o número do gênero que deseja pesquisar: ");
            string entrada = Console.ReadLine() ?? "";

            if (int.TryParse(entrada, out int generoId))
            {
                var resultado = esportes.Find(e => e.Id == generoId);
                if (resultado != null)
                {
                    Console.WriteLine("=== Resultado da pesquisa ===");
                    Console.WriteLine("==================================");
                    Console.WriteLine($"{resultado.Id} - {resultado.Titulo} ({resultado.Ano})");
                    Console.WriteLine($"Descrição: {resultado.Descricao}");
                    Console.WriteLine("==================================");
                }
                else
                {
                    Console.WriteLine("Nenhum esporte encontrado com esse gênero.");
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida.");
            }
        }
    }
}
