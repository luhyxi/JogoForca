using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Palavras
{
    public class Palavra
    {
        private string palavraResposta;
        private string palavraDica;
        private string palavraEscondida;

        public Palavra()
        {
            SetRandomWord(); // Inicializador que traz todas as funções
        }
        public string PalavraDica { get => palavraDica; }
        public string PalavraEscondida { get => palavraEscondida; }
        public string PalavraResposta { get => palavraResposta; }

        private void SetRandomWord()
        {
            KeyValuePair<string, string> randomWord = GetRandomWord();
            palavraDica = randomWord.Key;
            palavraResposta = randomWord.Value;
            palavraEscondida = HideWord(palavraResposta);
        }
        public bool UpdateHiddenWord(char input)
        {
            bool updateSuccessful = false;
            char[] hiddenWordArray = PalavraEscondida.ToCharArray();
            char lowerInput = char.ToLower(input);

            for (int i = 0; i < PalavraEscondida.Length; i++)
            {
                if (char.ToLower(PalavraResposta[i]) == lowerInput)
                {
                    hiddenWordArray[i] = PalavraResposta[i];
                    updateSuccessful = true;
                }
            }

            if (!updateSuccessful)
            {
                Console.Clear();
                Console.WriteLine("Letra não encontrada na palavra.");
            }

            palavraEscondida = new string(hiddenWordArray);
            return updateSuccessful;
        }


        // --- Dicas de Palavras ---
        public static string ehTecnologia = "Esta palavra está relacionada a tecnologia";
        public static string ehCasa = "Esta palavra nomeia um objeto normalmente encontrado em casas";
        public static string ehMusica = "Esta palavra está relacionada a música";
        public static string ehAnimal = "Esta palavra nomeia um animal";
        // --- Dicas de Palavras ---

        private static Dictionary<string, List<string>> possibleWords = new Dictionary<string, List<string>>()
        {
            {ehTecnologia, new List<string> { "Computador", "Software", "Hardware", "Processador", "Algoritmo" } }, // Relacionadas a tecnologia
            {ehCasa, new List<string> { "Cadeira", "Espelho", "Armario", "Tapete", "Mesa", "Sofa" } },                // Relacionadas a casa
            {ehMusica, new List<string> { "Harmonia", "Artista", "Sintonia", "Acorde" } },                            // Relacionada a música
            {ehAnimal, new List<string> { "Cachorro", "Baleia", "Humano" } }                                        // Todas as palavras nomeiam animais
        };

        public static Dictionary<string, List<string>> PossibleWords { get => possibleWords; set => possibleWords = value; }

        public static KeyValuePair<string, string> GetRandomWord()
        {
            Random rand = new Random();
            int randomIndex = rand.Next(0, PossibleWords.Count);

            string randomHint = PossibleWords.Keys.ElementAt(randomIndex);      // Dica aleatoria

            List<string> wordsForHint = PossibleWords[randomHint];              // Palavras da dica
            string randomWord = wordsForHint[rand.Next(0, wordsForHint.Count)]; // Escolhida a palavra 

            return new KeyValuePair<string, string>(randomHint, randomWord);
        }
    
        public static string HideWord(string input) // Esconde todas as letras da palavra
        {
            return Regex.Replace(input, @"[^ ]", "_");
        }

        public static string ShowLetter(string hiddenWord, string nonHiddenWord, char input)
        {
            char[] hiddenWordArray = hiddenWord.ToCharArray();
            char lowerInput = char.ToLower(input);

            for (int i = 0; i < hiddenWord.Length; i++)
            {
                if (char.ToLower(nonHiddenWord[i]) == lowerInput)
                {
                    hiddenWordArray[i] = nonHiddenWord[i];
                }
                else return "0";
            }

            return new string(hiddenWordArray);
        }
    }
}
