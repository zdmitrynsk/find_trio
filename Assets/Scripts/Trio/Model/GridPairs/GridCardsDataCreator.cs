using System.Collections.Generic;
using Trio.Utils;
using UnityEngine;

namespace Trio.Model.GridPairs
{
    public static class GridCardsDataCreator
    {
        public static CardData[,] Create(Vector2Int sizeGrid, int countTypeCards, int countEqualCardsPerType)
        {
            List<CardData> cards = CreateCards(sizeGrid.x, sizeGrid.y);
            ListUtils.Shuffle(cards);
            SetTypes(cards, countTypeCards, countEqualCardsPerType);
            var grid = new CardData[sizeGrid.x, sizeGrid.y];
            FillGrid(grid, cards);
            return grid;
        }

        private static List<CardData> CreateCards(int width, int height)
        {
            var cards = new List<CardData>();
            for (var x = 0; x < width; x++)
                for (var y = 0; y < height; y++)
                    cards.Add(new CardData(x, y));
            return cards;
        }

        private static void SetTypes(List<CardData> cards, int countTypeCards, int countEqualCardsPerType)
        {
            short i = 0;
            foreach (var item in cards)
            {
                var type = (i / countEqualCardsPerType) % countTypeCards;
                item.TypeCard = (short)type;
                i++;
            }   
        }
        
        private static void FillGrid(CardData[,] grid, List<CardData> cards)
        {
            foreach (var card in cards)
                grid[card.X, card.Y] = card;
        }
    }
}
