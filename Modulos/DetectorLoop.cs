using System;
using System.Collections.Generic;

namespace Toolkit
{
    public class DetectorLoop
    {
        private int limitePassos = 50;

        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== DETECTOR INGÊNUO DE LOOP ===");
            Console.WriteLine();
            Console.WriteLine("Este módulo simula um detector simples de loops infinitos");
            Console.WriteLine("através da detecção de estados repetidos em um processo discreto.");
            Console.WriteLine();

            Console.Write("Configurar limite de passos (padrão 50): ");
            string limiteInput = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(limiteInput) && int.TryParse(limiteInput, out int novoLimite) && novoLimite > 0)
            {
                limitePassos = novoLimite;
            }

            Console.WriteLine();
            Console.WriteLine("Escolha um processo para testar:");
            Console.WriteLine("1. Processo convergente (terminará)");
            Console.WriteLine("2. Processo cíclico (pode entrar em loop)");
            Console.WriteLine("3. Processo divergente (não termina, sem repetição)");
            Console.WriteLine();
            Console.Write("Opção: ");

            string opcao = Console.ReadLine() ?? "";

            switch (opcao)
            {
                case "1":
                    ExecutarProcessoConvergente();
                    break;
                case "2":
                    ExecutarProcessoCiclico();
                    break;
                case "3":
                    ExecutarProcessoDivergente();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

            ImprimirReflexao();

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal...");
            Console.ReadKey();
        }

        private void ExecutarProcessoConvergente()
        {
            Console.WriteLine();
            Console.WriteLine("=== PROCESSO CONVERGENTE ===");
            Console.WriteLine("Reduz um número pela metade até chegar a 1");
            Console.WriteLine();

            Console.Write("Digite um número inicial: ");
            if (!int.TryParse(Console.ReadLine(), out int valor) || valor <= 0)
            {
                Console.WriteLine("Valor inválido!");
                return;
            }

            HashSet<int> estadosVisitados = new HashSet<int>();
            int passos = 0;

            Console.WriteLine($"\nPasso 0: Estado = {valor}");

            while (valor != 1 && passos < limitePassos)
            {
                if (estadosVisitados.Contains(valor))
                {
                    Console.WriteLine($"\n⚠ LOOP DETECTADO no passo {passos}!");
                    Console.WriteLine($"Estado {valor} já foi visitado anteriormente.");
                    return;
                }

                estadosVisitados.Add(valor);
                valor = valor / 2;
                if (valor < 1) valor = 1;
                passos++;

                Console.WriteLine($"Passo {passos}: Estado = {valor}");
            }

            if (valor == 1)
            {
                Console.WriteLine($"\n✓ Processo TERMINOU com sucesso em {passos} passos.");
            }
            else
            {
                Console.WriteLine($"\n⚠ Limite de {limitePassos} passos atingido sem detectar loop.");
            }
        }

        private void ExecutarProcessoCiclico()
        {
            Console.WriteLine();
            Console.WriteLine("=== PROCESSO CÍCLICO ===");
            Console.WriteLine("Aplica regra: se par divide por 2, se ímpar multiplica por 3 e soma 1");
            Console.WriteLine();

            Console.Write("Digite um número inicial: ");
            if (!int.TryParse(Console.ReadLine(), out int valor) || valor <= 0)
            {
                Console.WriteLine("Valor inválido!");
                return;
            }

            HashSet<int> estadosVisitados = new HashSet<int>();
            int passos = 0;

            Console.WriteLine($"\nPasso 0: Estado = {valor}");

            while (passos < limitePassos)
            {
                if (estadosVisitados.Contains(valor))
                {
                    Console.WriteLine($"\n⚠ LOOP DETECTADO no passo {passos}!");
                    Console.WriteLine($"Estado {valor} já foi visitado anteriormente.");
                    return;
                }

                estadosVisitados.Add(valor);

                if (valor == 1)
                {
                    Console.WriteLine($"\n✓ Processo TERMINOU em {passos} passos.");
                    return;
                }

                if (valor % 2 == 0)
                {
                    valor = valor / 2;
                }
                else
                {
                    valor = valor * 3 + 1;
                }

                passos++;
                Console.WriteLine($"Passo {passos}: Estado = {valor}");
            }

            Console.WriteLine($"\n⚠ Limite de {limitePassos} passos atingido sem detectar loop.");
        }

        private void ExecutarProcessoDivergente()
        {
            Console.WriteLine();
            Console.WriteLine("=== PROCESSO DIVERGENTE ===");
            Console.WriteLine("Incrementa continuamente (nunca repete estado)");
            Console.WriteLine();

            Console.Write("Digite um número inicial: ");
            if (!int.TryParse(Console.ReadLine(), out int valor) || valor < 0)
            {
                Console.WriteLine("Valor inválido!");
                return;
            }

            HashSet<int> estadosVisitados = new HashSet<int>();
            int passos = 0;

            Console.WriteLine($"\nPasso 0: Estado = {valor}");

            while (passos < limitePassos)
            {
                if (estadosVisitados.Contains(valor))
                {
                    Console.WriteLine($"\n⚠ LOOP DETECTADO no passo {passos}!");
                    Console.WriteLine($"Estado {valor} já foi visitado anteriormente.");
                    return;
                }

                estadosVisitados.Add(valor);
                valor = valor + 1;
                passos++;

                if (passos % 10 == 0 || passos == limitePassos)
                {
                    Console.WriteLine($"Passo {passos}: Estado = {valor}");
                }
            }

            Console.WriteLine($"\n⚠ Limite de {limitePassos} passos atingido sem detectar loop.");
            Console.WriteLine("Este processo diverge sem repetir estados.");
        }

        private void ImprimirReflexao()
        {
            Console.WriteLine();
            Console.WriteLine("=== REFLEXÃO SOBRE O DETECTOR ===");
            Console.WriteLine();
            Console.WriteLine("LIMITAÇÕES DO DETECTOR INGÊNUO:");
            Console.WriteLine();
            Console.WriteLine("1. FALSOS POSITIVOS:");
            Console.WriteLine("   - Estados podem se repetir naturalmente sem indicar loop infinito");
            Console.WriteLine("   - Exemplo: algoritmos de busca podem revisitar estados válidos");
            Console.WriteLine();
            Console.WriteLine("2. FALSOS NEGATIVOS:");
            Console.WriteLine("   - Processos que não terminam mas nunca repetem estados");
            Console.WriteLine("   - Exemplo: contador que incrementa infinitamente");
            Console.WriteLine("   - O detector não consegue identificar estes casos");
            Console.WriteLine();
            Console.WriteLine("3. PROBLEMA DA PARADA:");
            Console.WriteLine("   - Não existe algoritmo geral que determine se um programa");
            Console.WriteLine("     arbitrário terminará ou entrará em loop infinito");
            Console.WriteLine("   - Este detector é apenas uma heurística limitada");
            Console.WriteLine();
            Console.WriteLine("4. DEPENDÊNCIA DO LIMITE:");
            Console.WriteLine("   - O limite de passos é arbitrário");
            Console.WriteLine("   - Processos legítimos podem precisar de mais passos");
        }
    }
}
