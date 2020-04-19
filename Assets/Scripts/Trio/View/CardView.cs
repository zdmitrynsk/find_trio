using System.Collections;
using Trio.Model.GridPairs;
using UnityEngine;

namespace Trio.View
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer = null;
        
        public delegate void ListenerTapView(CardView cardData);
        public delegate void ListenerShowBackSide(CardView cardView);
        
        public ListenerTapView OnTapView { get; set; } = (cardView) => { };
        public Sprite SpriteCardIcon { get; set; }
        public CardData CardData { get; set; }

        private Sprite _spriteBackSide;
        private Coroutine _coroutineShowBackSide;


        void Awake()
        {
            _spriteBackSide = _spriteRenderer.sprite;
        }
        
        public void ShowIconSide()
        {
            TryStopCoroutine(ref _coroutineShowBackSide);
            _spriteRenderer.sprite = SpriteCardIcon;
        }

        
        public void ShowBackSide(float delay, ListenerShowBackSide listener)
        {
            TryStopCoroutine(ref _coroutineShowBackSide);
            _coroutineShowBackSide = StartCoroutine(ShowBackSideWithDelay(delay, listener));
        }
        
        private IEnumerator ShowBackSideWithDelay(float delay, ListenerShowBackSide listener)
        {
            yield return new WaitForSeconds(delay);
            ShowBackSide();
            listener(this);
        }
        
        public void ShowBackSide()
        {
            _spriteRenderer.sprite = _spriteBackSide;
        }

        public void Destroy(float delay)
        {
            TryStopCoroutine(ref _coroutineShowBackSide);
            Destroy(gameObject, delay);
        }

        public void Destroy()
        {
            TryStopCoroutine(ref _coroutineShowBackSide);
            Destroy(gameObject);
        }

        private void OnMouseUpAsButton()
        {
            OnTapView(this);
        }

        private void TryStopCoroutine(ref Coroutine coroutine)
        {
            if (coroutine != null)
                StopCoroutine(coroutine);
            coroutine = null;
        }
    }
}
