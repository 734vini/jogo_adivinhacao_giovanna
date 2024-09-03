using System;

class Program
{
    static void Main()
    {
        // Definindo os animais e suas dicas
        string[] animais = { "Tubarão", "Girafa", "Canguru", "Lobo Guará", "Tatu-Bola" };
        string[][] dicas = new string[][]
        {
            // Dicas para Tubarão
            new string[] { "É um predador marinho.", "Tem barbatanas.", "Tem dentes afiados." },
            // Dicas para Girafa
            new string[] { "É a mais alta dos mamíferos terrestres.", "Tem manchas no corpo.", "Possui um pescoço longo." },
            // Dicas para Canguru
            new string[] { "É um animal que pula.", "Tem uma cauda longa.", "É nativo da Austrália." },
            // Dicas para Lobo Guará
            new string[] { "Tem pelagem laranja.", "Tem longas pernas.", "É encontrado no Brasil." },
            // Dicas para Tatu-Bola
            new string[] { "Pode enrolar-se em uma bola.", "Tem uma carapaça dura.", "É um animal pequeno e redondo." }
        };

        int pontuacao = 1000; // Pontuação do jogador, começando com 1000
        int deducaoPorDica = 66; // Dedução de pontos por dica
        int lives = 3; // Número de vidas

        // Laço para percorrer todos os animais
        for (int i = 0; i < animais.Length; i++)
        {

            Console.Clear();
            Console.WriteLine($"Fase {i + 1}: Adivinhe o animal! Pontuação atual: {pontuacao}");

            bool acertou = false;
            int j = 0; // Índice para rastrear as dicas usadas de cada animal

            // Laço para fornecer dicas e verificar a adivinhação
            while (lives > 0 && j < 3)
            {
                Console.WriteLine($"Dicas restantes: {3 - j}");
                Console.Write("Digite seu palpite ou '1' para receber uma dica: ");
                string input = Console.ReadLine().ToLower();

                if (input == "1")
                {
                    // Fornece a dica e reduz a pontuação
                    Console.WriteLine(dicas[i][j]);
                    j++;
                    pontuacao -= deducaoPorDica; // Reduzir pontos por dica usada
                    Console.WriteLine($"Pontuação atual: {pontuacao}");
                }
                else {
                if (input.Equals(animais[i], StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Correto! Você ainda tem {pontuacao} pontos.");
                    acertou = true;
                    break;
                }
                else
                {
                    Console.WriteLine($"Incorreto! Peça uma dica ou tente novamente!");
                }
                }
            }

            // Verifica se o jogador não acertou a resposta
            if (!acertou)
            {
                Console.WriteLine($"Você esgotou todas as dicas. O animal era {animais[i]}.");
                Console.WriteLine("Pressiona qualquer tecla para próxima rodada...");
                Console.ReadKey();
            }
        }

        Console.WriteLine($"Parabéns! Você acertou todos os animais e finalizou o jogo com {pontuacao} pontos!");
    }
}