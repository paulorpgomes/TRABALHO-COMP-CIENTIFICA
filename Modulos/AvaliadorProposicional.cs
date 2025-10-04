using System;

namespace Toolkit
{
    public class AvaliadorProposicional
    {
        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== AVALIADOR PROPOSICIONAL BÁSICO ===");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Conjunção (P ∧ Q)");
                Console.WriteLine("2. Disjunção (P ∨ Q)");
                Console.WriteLine("3. Implicação (P → Q)");
                Console.WriteLine("4. Bicondicional (P ↔ Q)");
                Console.WriteLine("5. Fórmula complexa: (P ∧ Q) → R");
                Console.WriteLine("6. Gerar tabela-verdade");
                Console.WriteLine("0. Voltar ao menu principal");
                Console.WriteLine();
                Console.Write("Opção: ");

                string opcao = Console.ReadLine() ?? "";

                switch (opcao)
                {
                    case "1":
                        AvaliarConjuncao();
                        break;
                    case "2":
                        AvaliarDisjuncao();
                        break;
                    case "3":
                        AvaliarImplicacao();
                        break;
                    case "4":
                        AvaliarBicondicional();
                        break;
                    case "5":
                        AvaliarFormulaComplexa();
                        break;
                    case "6":
                        GerarTabelaVerdade();
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

        private void AvaliarConjuncao()
        {
            Console.WriteLine("=== CONJUNÇÃO (P ∧ Q) ===");
            (bool P, bool Q, bool R) valores = ObterValoresPQR();
            
            bool resultado = valores.P && valores.Q;
            Console.WriteLine($"P = {valores.P}, Q = {valores.Q}");
            Console.WriteLine($"P ∧ Q = {resultado}");
        }

        private void AvaliarDisjuncao()
        {
            Console.WriteLine("=== DISJUNÇÃO (P ∨ Q) ===");
            (bool P, bool Q, bool R) valores = ObterValoresPQR();
            
            bool resultado = valores.P || valores.Q;
            Console.WriteLine($"P = {valores.P}, Q = {valores.Q}");
            Console.WriteLine($"P ∨ Q = {resultado}");
        }

        private void AvaliarImplicacao()
        {
            Console.WriteLine("=== IMPLICAÇÃO (P → Q) ===");
            (bool P, bool Q, bool R) valores = ObterValoresPQR();
            
            bool resultado = !valores.P || valores.Q;
            Console.WriteLine($"P = {valores.P}, Q = {valores.Q}");
            Console.WriteLine($"P → Q = {resultado}");
        }

        private void AvaliarBicondicional()
        {
            Console.WriteLine("=== BICONDICIONAL (P ↔ Q) ===");
            (bool P, bool Q, bool R) valores = ObterValoresPQR();
            
            bool resultado = valores.P == valores.Q;
            Console.WriteLine($"P = {valores.P}, Q = {valores.Q}");
            Console.WriteLine($"P ↔ Q = {resultado}");
        }

        private void AvaliarFormulaComplexa()
        {
            Console.WriteLine("=== FÓRMULA COMPLEXA: (P ∧ Q) → R ===");
            (bool P, bool Q, bool R) valores = ObterValoresPQR();
            
            bool antecedente = valores.P && valores.Q;
            bool resultado = !antecedente || valores.R;
            
            Console.WriteLine($"P = {valores.P}, Q = {valores.Q}, R = {valores.R}");
            Console.WriteLine($"(P ∧ Q) = {antecedente}");
            Console.WriteLine($"(P ∧ Q) → R = {resultado}");
        }

        private void GerarTabelaVerdade()
        {
            Console.WriteLine("=== TABELA-VERDADE ===");
            Console.WriteLine("Escolha a fórmula:");
            Console.WriteLine("1. P ∧ Q");
            Console.WriteLine("2. P ∨ Q");
            Console.WriteLine("3. P → Q");
            Console.WriteLine("4. P ↔ Q");
            Console.WriteLine("5. (P ∧ Q) → R");
            Console.Write("Opção: ");

            string opcao = Console.ReadLine() ?? "";

            switch (opcao)
            {
                case "1":
                    ImprimirTabelaConjuncao();
                    break;
                case "2":
                    ImprimirTabelaDisjuncao();
                    break;
                case "3":
                    ImprimirTabelaImplicacao();
                    break;
                case "4":
                    ImprimirTabelaBicondicional();
                    break;
                case "5":
                    ImprimirTabelaFormulaComplexa();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }

        private void ImprimirTabelaConjuncao()
        {
            Console.WriteLine("\nTabela-verdade para P ∧ Q:");
            Console.WriteLine("P\tQ\tP ∧ Q");
            Console.WriteLine("-------------------");
            
            for (int p = 0; p < 2; p++)
            {
                for (int q = 0; q < 2; q++)
                {
                    bool valorP = p == 1;
                    bool valorQ = q == 1;
                    bool resultado = valorP && valorQ;
                    Console.WriteLine($"{valorP}\t{valorQ}\t{resultado}");
                }
            }
        }

        private void ImprimirTabelaDisjuncao()
        {
            Console.WriteLine("\nTabela-verdade para P ∨ Q:");
            Console.WriteLine("P\tQ\tP ∨ Q");
            Console.WriteLine("-------------------");
            
            for (int p = 0; p < 2; p++)
            {
                for (int q = 0; q < 2; q++)
                {
                    bool valorP = p == 1;
                    bool valorQ = q == 1;
                    bool resultado = valorP || valorQ;
                    Console.WriteLine($"{valorP}\t{valorQ}\t{resultado}");
                }
            }
        }

        private void ImprimirTabelaImplicacao()
        {
            Console.WriteLine("\nTabela-verdade para P → Q:");
            Console.WriteLine("P\tQ\tP → Q");
            Console.WriteLine("-------------------");
            
            for (int p = 0; p < 2; p++)
            {
                for (int q = 0; q < 2; q++)
                {
                    bool valorP = p == 1;
                    bool valorQ = q == 1;
                    bool resultado = !valorP || valorQ;
                    Console.WriteLine($"{valorP}\t{valorQ}\t{resultado}");
                }
            }
        }

        private void ImprimirTabelaBicondicional()
        {
            Console.WriteLine("\nTabela-verdade para P ↔ Q:");
            Console.WriteLine("P\tQ\tP ↔ Q");
            Console.WriteLine("-------------------");
            
            for (int p = 0; p < 2; p++)
            {
                for (int q = 0; q < 2; q++)
                {
                    bool valorP = p == 1;
                    bool valorQ = q == 1;
                    bool resultado = valorP == valorQ;
                    Console.WriteLine($"{valorP}\t{valorQ}\t{resultado}");
                }
            }
        }

        private void ImprimirTabelaFormulaComplexa()
        {
            Console.WriteLine("\nTabela-verdade para (P ∧ Q) → R:");
            Console.WriteLine("P\tQ\tR\tP ∧ Q\t(P ∧ Q) → R");
            Console.WriteLine("----------------------------------------");
            
            for (int p = 0; p < 2; p++)
            {
                for (int q = 0; q < 2; q++)
                {
                    for (int r = 0; r < 2; r++)
                    {
                        bool valorP = p == 1;
                        bool valorQ = q == 1;
                        bool valorR = r == 1;
                        bool antecedente = valorP && valorQ;
                        bool resultado = !antecedente || valorR;
                        Console.WriteLine($"{valorP}\t{valorQ}\t{valorR}\t{antecedente}\t{resultado}");
                    }
                }
            }
        }

        private (bool P, bool Q, bool R) ObterValoresPQR()
        {
            Console.Write("Digite o valor de P (V/F): ");
            string entradaP = Console.ReadLine()?.ToUpper() ?? "";
            bool valorP = entradaP == "V" || entradaP == "TRUE" || entradaP == "1";

            Console.Write("Digite o valor de Q (V/F): ");
            string entradaQ = Console.ReadLine()?.ToUpper() ?? "";
            bool valorQ = entradaQ == "V" || entradaQ == "TRUE" || entradaQ == "1";

            Console.Write("Digite o valor de R (V/F): ");
            string entradaR = Console.ReadLine()?.ToUpper() ?? "";
            bool valorR = entradaR == "V" || entradaR == "TRUE" || entradaR == "1";

            return (valorP, valorQ, valorR);
        }
    }
}
