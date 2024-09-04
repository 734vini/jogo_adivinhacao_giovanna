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
            new string[] { "É UM PREDADOR MARINHO.", "TEM BARBATANAS.", "TEM DENTES AFIADOS.", "PODE DETECTAR SANGUE NA ÁGUA." },
            // Dicas para Girafa
            new string[] { "É A MAIS ALTO DOS MAMÍFEROS TERRESTRES.", "TEM MANCHAS NO CORPO.", "SE ALIMENTA PRINCIPALMENTE DE FOLHAS DE ÁRVORES.", "POSSUI UM PESCOÇO LONGO." },
            // Dicas para Canguru
            new string[] { "É UM ANIMAL QUE PULA.", "TEM UMA CAUDA LONGA.", "É NATIVO DA AUSTRÁLIA.", "CARREGA SEUS FILHOTES NA POUCH (BOLSA)." },
            // Dicas para Lobo Guará
            new string[] { "TEM PELAGEM LARANJA.", "TEM LONGAS PERNAS.", "É ENCONTRADO NO BRASIL.", "É UM ANIMAL SOLITÁRIO E NOTURNO." },
            // Dicas para Tatu-Bola
            new string[] { "PODE ENROLAR-SE EM UMA BOLA.", "TEM UMA CARAPAÇA DURA.", "É UM ANIMAL PEQUENO E REDONDO.", "ALIMENTA-SE PRINCIPALMENTE DE INSETOS." }
        };

        int i = 0; // Contador para o laço while (linhas)
        int j = 0; // Contador para o laço while (colunas)
        int animaisAcertados = 0; // Contador de animais acertados ao longo do jogo
        int pontuacao = 1000; // Pontuação do jogador, começando com 1000
        int deducaoDePontos = 33; // Dedução de pontos por dica ou erro

        Console.WriteLine("Seja bem-vindo ao Jogo de Adivinhação de Animais!");
        Console.WriteLine("\nINSTRUÇÕES: Você poderá adivinhar até 5 animais diferentes, caso não perca seus 1000 pontos inicias.");
        Console.WriteLine("Você tem direito de pedir até 3 dicas por animal, porém isso descontará da sua pontuação.");
        Console.Write("\nPreparado para inciar? Pressione qualquer tecla...");
        Console.ReadKey();

        // Laço para percorrer todos os animais
        while (i < animais.Length)
        {

            j = 0; // Atribui o valor de j como zero para o começo dos próximos loops

            Console.Clear();
            Console.WriteLine($"{i + 1}ª Rodada: Adivinhe o animal!");
            Console.WriteLine($"\n{dicas[i][j]}");
            Console.WriteLine($"\nPontuação atual: {pontuacao}");
            j++; // Passa para a próxima dica após exibir a dica padrão


            // Laço para fornecer dicas e verificar a adivinhação
            while (pontuacao >= 0)
            {
                Console.WriteLine($"Dicas restantes: {4 - j}");
                if (j != 4) { // Verifica se há dicas disponíveis e muda a mensagem de acordo.
                    Console.Write("\nDigite seu palpite ou '1' para receber uma dica: ");
                }
                else {
                    Console.Write("\nDigite seu palpite: ");
                }
                string palpite = Console.ReadLine().ToLower();

                // Fornece a dica e reduz a pontuação
                if ((palpite == "1" || palpite == "'1'") && j != 4)
                {
                    Console.WriteLine($"\n{dicas[i][j]}");
                    pontuacao -= deducaoDePontos;
                    if (pontuacao > 0) { // Evita que mostre uma pontuação negativa antes de encerrar o jogo
                        Console.WriteLine($"\nPontuação atual: {pontuacao}");
                    }
                    j++;
                }
                else {
                    if (palpite.Equals(animais[i], StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"\nCORRETO! Você ainda tem {pontuacao} pontos.");
                        Console.Write("\nPressione qualquer tecla para a próxima rodada...");
                        Console.ReadKey();
                        animaisAcertados++;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nINCORRETO!");
                        pontuacao -= deducaoDePontos;
                        if (pontuacao > 0) { // Evita que mostre uma pontuação negativa antes de encerrar o jogo
                            Console.WriteLine($"\nPontuação atual: {pontuacao}");
                        }
                    }
                }
            }

            // Verifica se o jogador zerou sua pontuação
            if (pontuacao <= 0)
            {
                Console.WriteLine($"\nPontuação zerada! O animal era {animais[i]}.");
                Console.WriteLine($"Você terminou o jogo acertando {animaisAcertados}/5 animais.");
                Console.Write("\nPressione qualquer tecla para encerrar o jogo...");
                Console.ReadKey();
                Environment.Exit(0);
            }

            i++; // Passa para o próximo animal
        }

        Console.WriteLine($"Parabéns! Você acertou todos os animais e finalizou o jogo com {pontuacao}/1000 pontos!");
    }
}