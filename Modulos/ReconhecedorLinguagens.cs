using System;

namespace Toolkit
{
    public class ReconhecedorLinguagens
    {
        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== RECONHECEDOR DE LINGUAGENS ===");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("Escolha uma linguagem para reconhecer:");
                Console.WriteLine("1. L_par_a - Linguagem das cadeias com número par de 'a'");
                Console.WriteLine("2. L = { w | w = a b* } - Linguagem das cadeias que começam com 'a' seguido de zero ou mais 'b'");
                Console.WriteLine("0. Voltar ao menu principal");
                Console.WriteLine();
                Console.Write("Opção: ");

                string opcao = Console.ReadLine() ?? "";

                switch (opcao)
                {
                    case "1":
                        ReconhecerLParA();
                        break;
                    case "2":
                        ReconhecerABEstrela();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void ReconhecerLParA()
        {
            Console.WriteLine("=== L_PAR_A - LINGUAGEM DAS CADEIAS COM NÚMERO PAR DE 'a' ===");
            Console.WriteLine("Esta linguagem aceita cadeias que contêm um número par de símbolos 'a'.");
            Console.WriteLine();

            while (true)
            {
                Console.Write("Digite uma cadeia sobre Σ={a,b} (ou 'voltar' para sair): ");
                string cadeia = Console.ReadLine() ?? "";

                if (cadeia.ToLower() == "voltar")
                {
                    break;
                }

                if (ValidarAlfabeto(cadeia))
                {
                    bool aceita = ReconhecerLParA(cadeia);
                    Console.WriteLine($"Resultado: {(aceita ? "ACEITA" : "REJEITA")}");
                }
                else
                {
                    Console.WriteLine("Cadeia inválida: contém símbolos fora do alfabeto Σ={a,b}");
                }

                Console.WriteLine();
            }
        }

        private void ReconhecerABEstrela()
        {
            Console.WriteLine("=== L = { w | w = a b* } ===");
            Console.WriteLine("Esta linguagem aceita cadeias que começam com 'a' seguido de zero ou mais 'b'.");
            Console.WriteLine();

            while (true)
            {
                Console.Write("Digite uma cadeia sobre Σ={a,b} (ou 'voltar' para sair): ");
                string cadeia = Console.ReadLine() ?? "";

                if (cadeia.ToLower() == "voltar")
                {
                    break;
                }

                if (ValidarAlfabeto(cadeia))
                {
                    bool aceita = ReconhecerABEstrela(cadeia);
                    Console.WriteLine($"Resultado: {(aceita ? "ACEITA" : "REJEITA")}");
                }
                else
                {
                    Console.WriteLine("Cadeia inválida: contém símbolos fora do alfabeto Σ={a,b}");
                }

                Console.WriteLine();
            }
        }

        private bool ReconhecerLParA(string cadeia)
        {
            int contadorA = 0;

            foreach (char simbolo in cadeia)
            {
                if (simbolo == 'a')
                {
                    contadorA++;
                }
            }

            return contadorA % 2 == 0;
        }

        private bool ReconhecerABEstrela(string cadeia)
        {
            if (string.IsNullOrEmpty(cadeia))
            {
                return false;
            }

            if (cadeia[0] != 'a')
            {
                return false;
            }

            for (int i = 1; i < cadeia.Length; i++)
            {
                if (cadeia[i] != 'b')
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValidarAlfabeto(string cadeia)
        {
            if (string.IsNullOrEmpty(cadeia))
            {
                return true;
            }

            foreach (char simbolo in cadeia)
            {
                if (simbolo != 'a' && simbolo != 'b')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
