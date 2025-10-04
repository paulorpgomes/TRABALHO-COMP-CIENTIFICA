using System;

namespace Toolkit
{
    public class VerificadorAlfabeto
    {
        private readonly char[] alfabeto = { 'a', 'b' };

        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== VERIFICADOR DE ALFABETO Σ={a,b} ===");
            Console.WriteLine();

            Console.WriteLine("1. Verificação de símbolo individual:");
            Console.Write("Digite um símbolo: ");
            string entradaSimbolo = Console.ReadLine() ?? "";
            
            if (entradaSimbolo.Length == 1)
            {
                char simbolo = entradaSimbolo[0];
                bool simboloValido = VerificarSimbolo(simbolo);
                Console.WriteLine($"Símbolo '{simbolo}': {(simboloValido ? "VÁLIDO" : "INVÁLIDO")}");
            }
            else
            {
                Console.WriteLine("Entrada inválida: deve ser um único símbolo.");
            }

            Console.WriteLine();

            Console.WriteLine("2. Verificação de cadeia:");
            Console.Write("Digite uma cadeia: ");
            string cadeia = Console.ReadLine() ?? "";
            
            bool cadeiaValida = VerificarCadeia(cadeia);
            Console.WriteLine($"Cadeia '{cadeia}': {(cadeiaValida ? "VÁLIDA" : "INVÁLIDA")}");

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal...");
            Console.ReadKey();
        }

        private bool VerificarSimbolo(char simbolo)
        {
            return Array.IndexOf(alfabeto, simbolo) != -1;
        }

        private bool VerificarCadeia(string cadeia)
        {
            if (string.IsNullOrEmpty(cadeia))
            {
                return true;
            }

            foreach (char simbolo in cadeia)
            {
                if (!VerificarSimbolo(simbolo))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
