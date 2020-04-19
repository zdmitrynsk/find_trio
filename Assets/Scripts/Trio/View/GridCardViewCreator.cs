using Trio.Model.GridPairs;
using UnityEngine;
using Zenject;

namespace Trio.View
{
    public class GridCardViewCreator : MonoBehaviour
    {
        
        [SerializeField] private GameObject prefabCard = null;
        
        [Inject] private CardIconsManager _cardIconsManager = null;
        
        public CardView[,] Create(CardData[,] cardsDataGrid, GameObject parent, CardView.ListenerTapView OnTapCardView)
        {
            Vector2Int sizeGrid = GetSizeGrid(cardsDataGrid);
            var gridViewsCard = new CardView[sizeGrid.x, sizeGrid.y];
            
            foreach (var cardData in cardsDataGrid)
            {
                var cardObj = CreateGameObjCard(cardData, parent);
                var cardView = InitCardView(cardObj, cardData, OnTapCardView);
                gridViewsCard[cardData.X, cardData.Y] = cardView;
            }

            return gridViewsCard;
        }
        
        public static Vector2Int GetSizeGrid(CardData[,] cardsDataGrid)
        {
            var width = cardsDataGrid.GetLength(0);
            var height = cardsDataGrid.GetLength(1);
            return new Vector2Int(width, height);
        }

        private GameObject CreateGameObjCard(CardData cardData, GameObject parent)
        {
            var cardObj = Instantiate(
                prefabCard
                , new Vector3(cardData.X + 0.5f, cardData.Y + 0.5f, 2f)
                , Quaternion.identity);
            cardObj.transform.SetParent(parent.transform);
            return cardObj;
        }

        private CardView InitCardView(GameObject cardGameObj, CardData cardData, CardView.ListenerTapView OnTapCardView)
        {
            var cardView = cardGameObj.GetComponent<CardView>();
            var spritesCard = _cardIconsManager.GetSpritesIconCard();
            cardView.CardData = cardData;
            cardView.OnTapView = OnTapCardView;
            cardView.SpriteCardIcon = spritesCard[cardData.TypeCard];
            return cardView;
        }
    }
}
