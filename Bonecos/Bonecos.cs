namespace Bonecos
{
    public class Boneco
    {
        public string corpo;
        public int life;

        // Default constructor
        public Boneco()
        {
            corpo = $@"  O
/ | \
/  \";
            life = 6;
        }

        // Constructor with custom corpo
        public Boneco(string customCorpo)
        {
            corpo = customCorpo;
            life = 6;
        }

       public void PerderVida() // Forma estranha de montar a lógica de UI da string
        {
            --life;
            switch (life)
            {
                case 4:
                    corpo = corpo.Remove(corpo.Length - 1, 1);
                    corpo = corpo.Remove(corpo.Length - 2, 2);
                    break;
                case 1:
                    corpo = corpo.Remove(corpo.Length - 1, 1);
                    corpo = corpo.Remove(corpo.Length - 2, 2);
                    break;
                default:
                    corpo = corpo.Remove(corpo.Length - 2, 2);
                    break;
            }
        }

        public void FimDeJogo(bool isWon)
        {
            if (isWon==true) 
            {
                Console.WriteLine(
@$" Você venceu!!!!! Parabens!!!

░░░░█▐▄▒▒▒▌▌▒▒▌░▌▒▐▐▐▒▒▐▒▒▌▒▀▄▀▄░
░░░█▐▒▒▀▀▌░▀▀▀░░▀▀▀░░▀▀▄▌▌▐▒▒▒▌▐░
░░▐▒▒▀▀▄▐░▀▀▄▄░░░░░░░░░░░▐▒▌▒▒▐░▌
░░▐▒▌▒▒▒▌░▄▄▄▄█▄░░░░░░░▄▄▄▐▐▄▄▀░░
░░▌▐▒▒▒▐░░░░░░░░░░░░░▀█▄░░░░▌▌░░░
▄▀▒▒▌▒▒▐░░░░░░░▄░░▄░░░░░▀▀░░▌▌░░░
▄▄▀▒▐▒▒▐░░░░░░░▐▀▀▀▄▄▀░░░░░░▌▌░░░
░░░░█▌▒▒▌░░░░░▐▒▒▒▒▒▌░░░░░░▐▐▒▀▀▄
░░▄▀▒▒▒▒▐░░░░░▐▒▒▒▒▐░░░░░▄█▄▒▐▒▒▒
▄▀▒▒▒▒▒▄██▀▄▄░░▀▄▄▀░░▄▄▀█▄░█▀▒▒▒▒");

            }
            else 
            {
                Console.WriteLine(
@$" Você perdeu, tente novamente


                            ;-;  ");
            }
            Console.WriteLine("Aperte 'Q' para sair ou'R' para recomeçar");
        }

        public void ContadorVida()
        {
            Console.WriteLine($"Você ainda tem {life} tentativas");
        }
    }
}
