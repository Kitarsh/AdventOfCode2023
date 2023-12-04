namespace Domain
{
    public class CardGame
    {
        private string[] lines;
        private List<Card> cards;

        public CardGame(string[] lines)
        {
            this.lines = lines;
            this.cards = lines.Select(l => new Card(l)).ToList();
        }

        public int ProcessCards()
        {
            var cardNumbers = this.cards.Select(c => c.Numero).ToList();
            var maxCardNumero = this.cards.Last().Numero;
            foreach (var card in this.cards)
            {
                var cardNumber = cardNumbers.Where(cn => cn == card.Numero).Count();
                for (var i = 0; i < cardNumber; i++)
                {
                    cardNumbers.AddRange(card.NextCardsWon(maxCardNumero));
                }
            }
            return cardNumbers.Count();
        }

        public int Score
        {
            get
            {
                return this.cards.Sum(c => c.Score);
            }
        }
    }
}