namespace JogoForca
{
    public class Boneco
    {
        public string corpo = $@"  O
/ | \
/  \";
        private static int life = 6;

        public void PerderVida()
        {
            --life;
            corpo = corpo.Remove(corpo.Length - 2, 2);
        }
    }
}
