using System;

namespace Toolkit
{
    public class ReconhecedorNaoTerminante
    {
        private readonly char[] alfabeto = { 'a', 'b' };
        private int limitePassos = 100;

        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== RECONHECEDOR QUE PODE NÃO TERMINAR ===");
            Console.WriteLine();
            Console.WriteLine("DESCRIÇÃO DA LINGUAGEM:");
            Console.WriteLine("L = { w | w contém a substring 'aba' }");
            Console.WriteLine();
            Console.WriteLine("OBSERVAÇÃO:");
            Console.WriteLine("Este reconhecedor simula um comportamento que pode não terminar");
            Console.WriteLine("para cadeias que NÃO pertencem à linguagem.");
            Console.WriteLine("Um limite de passos configurável previne loops infinitos.");
            Console.WriteLine();

            Console.Write("Configurar limite de passos (padrão 100): ");
            string limiteInput = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(limiteInput) && int.TryParse(limiteInput, out int novoLimite) && novoLimite > 0)
            {
                limitePassos = novoLimite;
            }

            Console.WriteLine();
            Console.Write("Digite a cadeia: ");
            string cadeia = Console.ReadLine() ?? "";

            if (!VerificarAlfabeto(cadeia))
            {
                Console.WriteLine("ERRO: cadeia contém símbolos fora do alfabeto Σ={a,b}");
            }
            else
            {
                ReconhecerComLimite(cadeia);
            }

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal...");
            Console.ReadKey();
        }

        private void ReconhecerComLimite(string cadeia)
        {
            Console.WriteLine();
            Console.WriteLine($"Iniciando reconhecimento (limite: {limitePassos} passos)...");
            Console.WriteLine();

            // Primeiro tenta reconhecer diretamente
            bool contem = cadeia.Contains("aba");

            if (contem)
            {
                Console.WriteLine("Substring 'aba' encontrada!");
                Console.WriteLine("ACEITA");
                return;
            }

            // Simula tentativas de busca que podem não terminar
            Console.WriteLine("Simulando busca exaustiva por possíveis transformações...");
            int passos = 0;

            // Simula um processo que tenta verificar todas as possibilidades
            for (int i = 0; i < cadeia.Length && passos < limitePassos; i++)
            {
                for (int j = i; j < cadeia.Length && passos < limitePassos; j++)
                {
                    passos++;

                    if (passos % 10 == 0)
                    {
                        Console.WriteLine($"Passo {passos}: verificando subcadeias...");
                    }

                    // Simula verificação
                    string subcadeia = cadeia.Substring(i, j - i + 1);
                    if (subcadeia.Contains("aba"))
                    {
                        Console.WriteLine($"Encontrado em passo {passos}!");
                        Console.WriteLine("ACEITA");
                        return;
                    }
                }
            }

            // Se atingiu o limite
            if (passos >= limitePassos)
            {
                Console.WriteLine();
                Console.WriteLine($"⚠ EXECUÇÃO INTERROMPIDA: atingiu o limite de {limitePassos} passos");
                Console.WriteLine("O reconhecedor pode não ter terminado naturalmente.");
                Console.WriteLine("Não é possível determinar se a cadeia pertence à linguagem.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"Execução concluída em {passos} passos.");
                Console.WriteLine("REJEITA");
            }
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
