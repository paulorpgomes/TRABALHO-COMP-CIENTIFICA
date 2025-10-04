using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Toolkit
{
    public class ClassificadorTIN
    {
        private readonly List<ItemProblema> itensProblemas;

        public ClassificadorTIN()
        {
            itensProblemas = CarregarItensProblemas();
        }

        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== CLASSIFICADOR T/I/N ===");
            Console.WriteLine();
            Console.WriteLine("Classifique cada item como:");
            Console.WriteLine("T - Tratável");
            Console.WriteLine("I - Intratável");
            Console.WriteLine("N - Não computável");
            Console.WriteLine();

            int acertos = 0;
            int total = itensProblemas.Count;

            for (int i = 0; i < itensProblemas.Count; i++)
            {
                ItemProblema item = itensProblemas[i];
                Console.WriteLine($"Item {i + 1}: {item.Descricao}");
                Console.Write("Sua classificação (T/I/N): ");
                
                string resposta = Console.ReadLine()?.ToUpper() ?? "";
                
                bool acertou = VerificarResposta(resposta, item.Classificacao);
                if (acertou)
                {
                    acertos++;
                    Console.WriteLine("✓ Correto!");
                }
                else
                {
                    Console.WriteLine($"✗ Incorreto. Resposta correta: {item.Classificacao}");
                }
                
                Console.WriteLine();
            }
            Console.WriteLine("=== RESUMO FINAL ===");
            Console.WriteLine($"Total de itens: {total}");
            Console.WriteLine($"Acertos: {acertos}");
            Console.WriteLine($"Erros: {total - acertos}");
            Console.WriteLine($"Taxa de acerto: {(acertos * 100.0 / total):F1}%");

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal...");
            Console.ReadKey();
        }

        private bool VerificarResposta(string resposta, string classificacaoCorreta)
        {
            return resposta == classificacaoCorreta;
        }

        private List<ItemProblema> CarregarItensProblemas()
        {
            string jsonItens = @"[
                {
                    ""descricao"": ""Ordenar uma lista de números"",
                    ""classificacao"": ""T""
                },
                {
                    ""descricao"": ""Resolver o problema do caixeiro viajante"",
                    ""classificacao"": ""I""
                },
                {
                    ""descricao"": ""Determinar se um programa para em todas as entradas"",
                    ""classificacao"": ""N""
                },
                {
                    ""descricao"": ""Buscar um elemento em uma lista ordenada"",
                    ""classificacao"": ""T""
                },
                {
                    ""descricao"": ""Resolver o problema da satisfabilidade booleana (SAT)"",
                    ""classificacao"": ""I""
                },
                {
                    ""descricao"": ""Verificar se dois programas são equivalentes"",
                    ""classificacao"": ""N""
                },
                {
                    ""descricao"": ""Calcular o máximo divisor comum de dois números"",
                    ""classificacao"": ""T""
                },
                {
                    ""descricao"": ""Resolver o problema da mochila"",
                    ""classificacao"": ""I""
                },
                {
                    ""descricao"": ""Determinar se uma fórmula matemática é verdadeira"",
                    ""classificacao"": ""N""
                },
                {
                    ""descricao"": ""Multiplicar duas matrizes"",
                    ""classificacao"": ""T""
                }
            ]";

            try
            {
                List<ItemProblema> itens = JsonSerializer.Deserialize<List<ItemProblema>>(jsonItens);
                return itens ?? new List<ItemProblema>();
            }
            catch (JsonException)
            {
                Console.WriteLine("Erro ao carregar itens de problemas.");
                return new List<ItemProblema>();
            }
        }
    }

    public class ItemProblema
    {
        public string Descricao { get; set; } = "";
        public string Classificacao { get; set; } = "";
    }
}
