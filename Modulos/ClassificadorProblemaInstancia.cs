using System;
using System.Text.Json;

namespace Toolkit
{
    public class ClassificadorProblemaInstancia
    {
        private class ItemClassificacao
        {
            public string Descricao { get; set; } = "";
            public string Tipo { get; set; } = "";
        }

        private readonly string jsonItens = @"
        [
            { ""Descricao"": ""Determinar se um número é primo"", ""Tipo"": ""P"" },
            { ""Descricao"": ""17 é primo?"", ""Tipo"": ""I"" },
            { ""Descricao"": ""Ordenar uma lista de números"", ""Tipo"": ""P"" },
            { ""Descricao"": ""Ordenar a lista [5, 2, 8, 1]"", ""Tipo"": ""I"" },
            { ""Descricao"": ""Verificar se um grafo contém ciclo"", ""Tipo"": ""P"" },
            { ""Descricao"": ""O grafo G1 com vértices {A,B,C} e arestas {A-B, B-C} contém ciclo?"", ""Tipo"": ""I"" },
            { ""Descricao"": ""Calcular o fatorial de um número"", ""Tipo"": ""P"" },
            { ""Descricao"": ""Qual é o fatorial de 5?"", ""Tipo"": ""I"" },
            { ""Descricao"": ""A cadeia 'abba' pertence à linguagem L?"", ""Tipo"": ""I"" },
            { ""Descricao"": ""Decidir se uma cadeia pertence a uma linguagem regular"", ""Tipo"": ""P"" }
        ]";

        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== CLASSIFICADOR PROBLEMA × INSTÂNCIA ===");
            Console.WriteLine();
            Console.WriteLine("Classifique cada item como:");
            Console.WriteLine("P - Problema (descrição geral)");
            Console.WriteLine("I - Instância (caso específico)");
            Console.WriteLine();

            ItemClassificacao[]? itens = JsonSerializer.Deserialize<ItemClassificacao[]>(jsonItens);

            if (itens == null)
            {
                Console.WriteLine("Erro ao carregar itens.");
                Console.WriteLine("Pressione qualquer tecla para voltar...");
                Console.ReadKey();
                return;
            }

            int acertos = 0;
            int erros = 0;

            for (int i = 0; i < itens.Length; i++)
            {
                Console.WriteLine($"\nItem {i + 1}: {itens[i].Descricao}");
                Console.Write("Sua resposta (P/I): ");
                string resposta = Console.ReadLine()?.ToUpper().Trim() ?? "";

                if (resposta != "P" && resposta != "I")
                {
                    Console.WriteLine("Resposta inválida! Use P ou I.");
                    i--;
                    continue;
                }

                if (resposta == itens[i].Tipo)
                {
                    Console.WriteLine("✓ CORRETO!");
                    acertos++;
                }
                else
                {
                    Console.WriteLine($"✗ INCORRETO! Resposta correta: {itens[i].Tipo}");
                    erros++;
                }
            }

            Console.WriteLine();
            Console.WriteLine("=== RESUMO FINAL ===");
            Console.WriteLine($"Total de itens: {itens.Length}");
            Console.WriteLine($"Acertos: {acertos}");
            Console.WriteLine($"Erros: {erros}");
            Console.WriteLine($"Aproveitamento: {(acertos * 100.0 / itens.Length):F1}%");

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal...");
            Console.ReadKey();
        }
    }
}
