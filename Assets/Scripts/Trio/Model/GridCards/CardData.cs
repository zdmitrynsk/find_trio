namespace Trio.Model.GridCards
{
    public class CardData
    {
        public int X { get; }
        public int Y { get; }
        public int TypeCard { get; set; }

        public CardData(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
