using System;

namespace Toolkit
{
    public class ProgramaDecisao
    {
        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== PROGRAMA DE DECISÃO: TERMINA COM 'b'? ===");
            Console.WriteLine();
            Console.WriteLine("Este programa decide se uma cadeia sobre Σ={a,b} termina com 'b'.");
            Console.WriteLine();

            while (true)
            {
                Console.Write("Digite uma cadeia sobre Σ={a,b} (ou 'sair' para voltar): ");
                string entrada = Console.ReadLine() ?? "";

                if (entrada.ToLower() == "sair")
                {
                    break;
                }

                if (string.IsNullOrEmpty(entrada))
                {
                    Console.WriteLine("Cadeia vazia não termina com 'b'.");
                    Console.WriteLine("Resultado: NAO");
                }
                else
                {
                    bool terminaComB = TerminaComB(entrada);
                    Console.WriteLine($"Resultado: {(terminaComB ? "SIM" : "NAO")}");
                }

                Console.WriteLine();
            }
        }

        private bool TerminaComB(string cadeia)
        {
            return cadeia.Length > 0 && cadeia[cadeia.Length - 1] == 'b';
        }
    }
}
