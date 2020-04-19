using System.Collections.Generic;
using Trio.Model.GridPairs;
using UnityEngine;
using Zenject;

namespace Trio.View
{
    public class GridViewManager : MonoBehaviour
    {
        public delegate void ListenerFinishGrid();
        
        public ListenerFinishGrid OnFinishGrid = () => {};

        [Inject] private GridCardViewCreator _gridCardViewCreator = null;
         
        private CardView[,] _gridViewsCard;
        private GameObject _rootCardsView;
        private List<CardView> _selectedCardViews;
        private Vector2Int _sizeGrid;
        private int _countFindedCards;
        private int _countTotalCards;
        private int _countEqualCardsPerType;

        private float DELAY_CARD_ACTIONS = 1f;

        public void ShowGrid(CardData[,] cardsGrid, int countEqualCardsPerType)
        {
            DestroyGridCardsViews();
            _rootCardsView = new GameObject("GridCards");
            _gridViewsCard = _gridCardViewCreator.Create(cardsGrid, _rootCardsView, TapCardView);

            var sizeGrid = GridCardViewCreator.GetSizeGrid(cardsGrid);
            _countTotalCards = sizeGrid.x * sizeGrid.y; 
            _selectedCardViews = new List<CardView>();
            _countFindedCards = 0;
            _countEqualCardsPerType = countEqualCardsPerType;
        }
 
        public void DestroyGridCardsViews()
        {
            if (_gridViewsCard == null)
                return;
            
            foreach (var card in _gridViewsCard)
                if (card != null)
                    card.Destroy();
        }


        private void TapCardView(CardView tappedCardView)
        {
            if (_selectedCardViews.IndexOf(tappedCardView) != -1)
                return;
            
            if (_selectedCardViews.Count > 2)
                ShowBackSideCards(_selectedCardViews);
            
            tappedCardView.ShowIconSide();
            _selectedCardViews.Add(tappedCardView);
            
            if (_selectedCardViews.Count == _countEqualCardsPerType)
                CheckSelectedCards();
            
            if (IsEndedCards())
                OnFinishGrid();
        }

        
        private bool IsEndedCards()
        {
            return _countTotalCards - _countFindedCards < _countEqualCardsPerType;
        }

        private void CheckSelectedCards()
        {
            if (IsEqualTypeSelectedCards(_selectedCardViews))
            {
                _countFindedCards += _selectedCardViews.Count;
                DestroyCards(_selectedCardViews, DELAY_CARD_ACTIONS);
            }
            else
            {
                ShowBackSideCards(_selectedCardViews, DELAY_CARD_ACTIONS);
            }
        }
        
        private bool IsEqualTypeSelectedCards(List<CardView> selectedCardViews)
        {
            bool result = true;
            var firstType = selectedCardViews[0].CardData.TypeCard;
            for (int i = 1; i < selectedCardViews.Count; i++)
            {
                var iTypeCardView = selectedCardViews[i].CardData.TypeCard;
                if (firstType != iTypeCardView)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        #region CardActionHelpers
        private void DestroyCards(List<CardView> cardViews, float delay)
        {
            for (int i = cardViews.Count - 1; i >= 0; i--)
            {
                var card = cardViews[i];
                cardViews.RemoveAt(i);
                card.Destroy(delay);
            }
        }
        private void ShowBackSideCards(List<CardView> cardViews)
        {
            foreach (var cardView in cardViews)
                cardView.ShowBackSide();
        }
        
        private void ShowBackSideCards(List<CardView> cardViews, float delay)
        {
            foreach (var cardView in cardViews)
                cardView.ShowBackSide(delay, OnShowedBackSideView);
        }
        #endregion
        
        private void OnShowedBackSideView(CardView cardView)
        {
            _selectedCardViews.Remove(cardView);
        }
    }
}
