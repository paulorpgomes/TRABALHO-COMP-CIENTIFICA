using System;
using System.Collections.Generic;

namespace Toolkit
{
    public class SimuladorAFD
    {
        private class AFD
        {
            public string Nome { get; set; } = "";
            public string Descricao { get; set; } = "";
            public string EstadoInicial { get; set; } = "";
            public HashSet<string> EstadosFinais { get; set; } = new HashSet<string>();
            public Dictionary<string, Dictionary<char, string>> Transicoes { get; set; } = new Dictionary<string, Dictionary<char, string>>();
        }

        private readonly char[] alfabeto = { 'a', 'b' };

        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== SIMULADOR DE AUTÔMATO FINITO DETERMINÍSTICO ===");
            Console.WriteLine();
            Console.WriteLine("Escolha um AFD pré-definido:");
            Console.WriteLine("1. AFD que aceita cadeias terminadas em 'b'");
            Console.WriteLine("2. AFD que aceita cadeias com número par de 'a's");
            Console.WriteLine("3. AFD que aceita cadeias contendo 'ab'");
            Console.WriteLine("0. Voltar ao menu principal");
            Console.WriteLine();
            Console.Write("Opção: ");

            string opcao = Console.ReadLine() ?? "";

            AFD? afd = opcao switch
            {
                "1" => CriarAFDTerminaB(),
                "2" => CriarAFDParA(),
                "3" => CriarAFDContemAB(),
                "0" => null,
                _ => null
            };

            if (afd == null)
            {
                if (opcao != "0")
                {
                    Console.WriteLine("Opção inválida!");
                    Console.ReadKey();
                }
                return;
            }

            ExibirAFD(afd);
            ExecutarSimulacao(afd);
        }

        private AFD CriarAFDTerminaB()
        {
            AFD afd = new AFD
            {
                Nome = "AFD_TERMINA_B",
                Descricao = "Aceita cadeias que terminam com 'b'",
                EstadoInicial = "q0",
                EstadosFinais = new HashSet<string> { "q1" }
            };

            afd.Transicoes["q0"] = new Dictionary<char, string>
            {
                { 'a', "q0" },
                { 'b', "q1" }
            };

            afd.Transicoes["q1"] = new Dictionary<char, string>
            {
                { 'a', "q0" },
                { 'b', "q1" }
            };

            return afd;
        }

        private AFD CriarAFDParA()
        {
            AFD afd = new AFD
            {
                Nome = "AFD_PAR_A",
                Descricao = "Aceita cadeias com número par de 'a's",
                EstadoInicial = "q0",
                EstadosFinais = new HashSet<string> { "q0" }
            };

            afd.Transicoes["q0"] = new Dictionary<char, string>
            {
                { 'a', "q1" },
                { 'b', "q0" }
            };

            afd.Transicoes["q1"] = new Dictionary<char, string>
            {
                { 'a', "q0" },
                { 'b', "q1" }
            };

            return afd;
        }

        private AFD CriarAFDContemAB()
        {
            AFD afd = new AFD
            {
                Nome = "AFD_CONTEM_AB",
                Descricao = "Aceita cadeias que contêm a substring 'ab'",
                EstadoInicial = "q0",
                EstadosFinais = new HashSet<string> { "q2" }
            };

            afd.Transicoes["q0"] = new Dictionary<char, string>
            {
                { 'a', "q1" },
                { 'b', "q0" }
            };

            afd.Transicoes["q1"] = new Dictionary<char, string>
            {
                { 'a', "q1" },
                { 'b', "q2" }
            };

            afd.Transicoes["q2"] = new Dictionary<char, string>
            {
                { 'a', "q2" },
                { 'b', "q2" }
            };

            return afd;
        }

        private void ExibirAFD(AFD afd)
        {
            Console.Clear();
            Console.WriteLine($"=== {afd.Nome} ===");
            Console.WriteLine($"Descrição: {afd.Descricao}");
            Console.WriteLine();
            Console.WriteLine("DEFINIÇÃO DO AFD:");
            Console.WriteLine($"Alfabeto: Σ = {{a, b}}");
            Console.WriteLine($"Estado inicial: {afd.EstadoInicial}");
            Console.WriteLine($"Estados finais: {{{string.Join(", ", afd.EstadosFinais)}}}");
            Console.WriteLine();
            Console.WriteLine("Tabela de transições:");
            Console.WriteLine("Estado | a    | b");
            Console.WriteLine("-------|------|------");

            foreach (var estado in afd.Transicoes.Keys)
            {
                string marcaEstado = estado;
                if (estado == afd.EstadoInicial) marcaEstado += "*";
                if (afd.EstadosFinais.Contains(estado)) marcaEstado += "F";

                string transicaoA = afd.Transicoes[estado].ContainsKey('a') ? afd.Transicoes[estado]['a'] : "-";
                string transicaoB = afd.Transicoes[estado].ContainsKey('b') ? afd.Transicoes[estado]['b'] : "-";

                Console.WriteLine($"{marcaEstado,-7}| {transicaoA,-5}| {transicaoB}");
            }

            Console.WriteLine();
            Console.WriteLine("Legenda: * = inicial, F = final");
            Console.WriteLine();
        }

        private void ExecutarSimulacao(AFD afd)
        {
            Console.Write("Digite a cadeia para testar: ");
            string cadeia = Console.ReadLine() ?? "";

            if (!VerificarAlfabeto(cadeia))
            {
                Console.WriteLine("ERRO: cadeia contém símbolos fora do alfabeto Σ={a,b}");
                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine();
            Console.WriteLine("=== EXECUÇÃO DO AFD ===");
            Console.WriteLine();

            string estadoAtual = afd.EstadoInicial;
            Console.WriteLine($"Estado inicial: {estadoAtual}");

            if (string.IsNullOrEmpty(cadeia))
            {
                Console.WriteLine("Cadeia vazia (ε)");
            }
            else
            {
                for (int i = 0; i < cadeia.Length; i++)
                {
                    char simbolo = cadeia[i];

                    if (!afd.Transicoes.ContainsKey(estadoAtual) || !afd.Transicoes[estadoAtual].ContainsKey(simbolo))
                    {
                        Console.WriteLine($"Símbolo '{simbolo}': ERRO - transição não definida!");
                        Console.WriteLine("REJEITA");
                        Console.WriteLine();
                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal...");
                        Console.ReadKey();
                        return;
                    }

                    string proximoEstado = afd.Transicoes[estadoAtual][simbolo];
                    Console.WriteLine($"Símbolo '{simbolo}': {estadoAtual} → {proximoEstado}");
                    estadoAtual = proximoEstado;
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Estado final: {estadoAtual}");

            bool aceita = afd.EstadosFinais.Contains(estadoAtual);
            Console.WriteLine($"Resultado: {(aceita ? "ACEITA" : "REJEITA")}");

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal...");
            Console.ReadKey();
        }

        private bool VerificarAlfabeto(string cadeia)
        {
            if (string.IsNullOrEmpty(cadeia))
            {
                return true;
            }

            foreach (char c in cadeia)
            {
                if (Array.IndexOf(alfabeto, c) == -1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
