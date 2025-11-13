using System;

namespace Toolkit
{
    public class DecisoresDecidiveis
    {
        private readonly char[] alfabeto = { 'a', 'b' };

        public void Executar()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== DECISORES DECIDÍVEIS ===");
                Console.WriteLine();
                Console.WriteLine("Escolha uma linguagem decidível:");
                Console.WriteLine("1. L_fim_b: cadeias que terminam com 'b'");
                Console.WriteLine("2. L_mult3_b: cadeias com quantidade de 'b' múltipla de 3");
                Console.WriteLine("0. Voltar ao menu principal");
                Console.WriteLine();
                Console.Write("Opção: ");

                string opcao = Console.ReadLine() ?? "";

                switch (opcao)
                {
                    case "1":
                        ExecutarLFimB();
                        break;
                    case "2":
                        ExecutarLMult3B();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ExecutarLFimB()
        {
            Console.Clear();
            Console.WriteLine("=== DECISOR: L_fim_b ===");
            Console.WriteLine("Linguagem: cadeias sobre Σ={a,b} que terminam com 'b'");
            Console.WriteLine();

            Console.Write("Digite a cadeia: ");
            string cadeia = Console.ReadLine() ?? "";

            if (!VerificarAlfabeto(cadeia))
            {
                Console.WriteLine("ERRO: cadeia contém símbolos fora do alfabeto Σ={a,b}");
            }
            else
            {
                bool resultado = DecideLFimB(cadeia);
                Console.WriteLine($"Resultado: {(resultado ? "SIM" : "NÃO")}");
            }

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        private void ExecutarLMult3B()
        {
            Console.Clear();
            Console.WriteLine("=== DECISOR: L_mult3_b ===");
            Console.WriteLine("Linguagem: cadeias sobre Σ={a,b} com quantidade de 'b' múltipla de 3");
            Console.WriteLine();

            Console.Write("Digite a cadeia: ");
            string cadeia = Console.ReadLine() ?? "";

            if (!VerificarAlfabeto(cadeia))
            {
                Console.WriteLine("ERRO: cadeia contém símbolos fora do alfabeto Σ={a,b}");
            }
            else
            {
                bool resultado = DecideLMult3B(cadeia);
                Console.WriteLine($"Resultado: {(resultado ? "SIM" : "NÃO")}");
            }

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        private bool DecideLFimB(string cadeia)
        {
            // Caso vazio: não termina com 'b'
            if (string.IsNullOrEmpty(cadeia))
            {
                return false;
            }

            // Verifica o último caractere
            return cadeia[cadeia.Length - 1] == 'b';
        }

        private bool DecideLMult3B(string cadeia)
        {
            // Conta a quantidade de 'b' na cadeia
            int contadorB = 0;

            foreach (char c in cadeia)
            {
                if (c == 'b')
                {
                    contadorB++;
                }
            }

            // Verifica se é múltiplo de 3 (incluindo 0)
            return contadorB % 3 == 0;
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
