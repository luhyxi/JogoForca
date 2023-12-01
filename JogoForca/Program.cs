using Bonecos;
using Palavras;
using System;

namespace JogoForca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JogarJogo();
        }
        public static void JogarJogo() 
        { 
            bool gameRunning = true;    // Usos universais
            bool isWon = false ;

            Console.WriteLine("Bem-vinde ao jogo da forca, aperte qualquer tecla para jogar.");
            Console.ReadKey();
            Console.Clear();

            Boneco boneco = new Boneco();    // Cria as funções do boneco 
            Palavra palavra = new Palavra(); // Cria as funções da palavra

            do
            {
                if (boneco.life <= 0)
                {
                    gameRunning = false;
                    break;
                }
                if (palavra.PalavraEscondida == palavra.PalavraResposta)
                {
                    gameRunning = false;
                    isWon = true; 
                    break;
                }

                Console.Clear();
                Console.WriteLine(boneco.corpo);
                Console.WriteLine($"Dica: {palavra.PalavraDica}");
                Console.WriteLine($"Palavra: {palavra.PalavraEscondida}");
                Console.WriteLine($"");
                boneco.ContadorVida();

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                char userInput = char.ToLower(keyInfo.KeyChar);

                if (!palavra.UpdateHiddenWord(userInput))
                {
                    Console.Clear();
                    boneco.PerderVida();
                    Console.WriteLine("A palavra não possui essa letra.");
                }

            } while (gameRunning);

            Console.Clear();
            boneco.FimDeJogo(isWon);

            InputFim();
            Console.Clear();
        }


        public static void InputFim()
        {
            char userInputEnd;

            do
            {
                ConsoleKeyInfo keyInfoEnd = Console.ReadKey(true);
                userInputEnd = char.ToLower(keyInfoEnd.KeyChar);
                if (userInputEnd == 'r')
                {
                    Console.Clear() ;
                    JogarJogo();
                }
            } while (userInputEnd != 'q');
            Console.Clear();
            Environment.Exit(0);
        }
    }
}
