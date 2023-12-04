namespace Domain
{
    public class Card
    {
        private string input;
        private List<int> targetNumbers;
        private List<int> playerNumbers;

        public int Numero { get; }

        public Card(string input)
        {
            this.input = input;

            this.Numero = Int32.Parse(new string(this.input.Skip(5).Take(3).ToArray()));
            var allNumbers = this.input.Split(':')[1];
            this.targetNumbers = allNumbers.Split('|')[0].Trim().Split(null).Where(v => !string.IsNullOrEmpty(v)).Select(number => Int32.Parse(number)).ToList();
            this.playerNumbers = allNumbers.Split('|')[1].Trim().Split(null).Where(v => !string.IsNullOrEmpty(v)).Select(number => Int32.Parse(number)).ToList();
        }

        public int Score
        {
            get
            {
                var goodNumbers = playerNumbers.Where(pn => targetNumbers.Contains(pn)).Count();
                if (goodNumbers == 0)
                {
                    return 0;
                }
                return (int)Math.Pow((double)2, goodNumbers - 1);
            }
        }

        public List<int> NextCardsWon(int maxNumero)
        {
            var goodNumbers = playerNumbers.Where(pn => targetNumbers.Contains(pn)).Count();
            var nextCards = new List<int>();
            for (int i = 1; i <= goodNumbers; i++)
            {
                if (i + Numero < maxNumero)
                {
                    nextCards.Add(i + Numero);
                } else
                {
                    nextCards.Add(maxNumero);
                }
            }

            return nextCards;
        }
    }
}