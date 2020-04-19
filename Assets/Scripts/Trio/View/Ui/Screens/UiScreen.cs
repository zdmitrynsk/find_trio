using UnityEngine;

namespace Trio.View.Ui.Screens
{
    public class UiScreen : MonoBehaviour
    {
        [SerializeField] internal UiScreenName uiScreenName = UiScreenName.NONE;
        [SerializeField] protected CanvasGroup canvasGroup = null;

        public bool IsOpen { get; set; }

        public void UpdateScreenStatus(bool open)
        {
            canvasGroup.alpha = open ? 1 : 0;
            canvasGroup.interactable = open;
            canvasGroup.blocksRaycasts = open;
            IsOpen = open;
        }

        private void Reset()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
    }
}
