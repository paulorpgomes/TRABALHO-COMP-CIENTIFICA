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
                Console.WriteLine("AV2 - Decidibilidade, Reconhecimento e Modelos:");
                Console.WriteLine("6. Classificador Problema × Instância por JSON");
                Console.WriteLine("7. Decisores decidíveis: L_fim_b e L_mult3_b");
                Console.WriteLine("8. Reconhecedor que pode não terminar");
                Console.WriteLine("9. Detector ingênuo de loop + reflexão");
                Console.WriteLine("10. Simulador de AFD de casos fixos");
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
                    case "6":
                        new ClassificadorProblemaInstancia().Executar();
                        break;
                    case "7":
                        new DecisoresDecidiveis().Executar();
                        break;
                    case "8":
                        new ReconhecedorNaoTerminante().Executar();
                        break;
                    case "9":
                        new DetectorLoop().Executar();
                        break;
                    case "10":
                        new SimuladorAFD().Executar();
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
