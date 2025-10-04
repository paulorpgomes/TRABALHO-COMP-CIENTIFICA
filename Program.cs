using System;
using System.Text.Json;

namespace Toolkit
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            menuPrincipal.Executar();
        }
    }

    public class MenuPrincipal
    {
        public void Executar()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== TOOLKIT - COMPUTAÇÃO CIENTÍFICA ===");
                Console.WriteLine();
                Console.WriteLine("AV1 - Fundamentos Práticos:");
                Console.WriteLine("1. Verificador de alfabeto Σ={a,b}");
                Console.WriteLine("2. Classificador T/I/N por JSON");
                Console.WriteLine("3. Programa de decisão: termina com 'b'?");
                Console.WriteLine("4. Avaliador proposicional básico");
                Console.WriteLine("5. Reconhecedor L_par_a e a b*");
                Console.WriteLine();
                Console.WriteLine("0. Sair");
                Console.WriteLine();
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine() ?? "";

                switch (opcao)
                {
                    case "1":
                        new VerificadorAlfabeto().Executar();
                        break;
                    case "2":
                        new ClassificadorTIN().Executar();
                        break;
                    case "3":
                        new ProgramaDecisao().Executar();
                        break;
                    case "4":
                        new AvaliadorProposicional().Executar();
                        break;
                    case "5":
                        new ReconhecedorLinguagens().Executar();
                        break;
                    case "0":
                        Console.WriteLine("Encerrando programa...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida! Pressione qualquer tecla para continuar.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
