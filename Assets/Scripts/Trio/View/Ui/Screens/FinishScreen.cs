using Trio.Model;
using Zenject;

namespace Trio.View.Ui.Screens
{
    public class FinishScreen : UiScreen
    {
        [Inject] private UiManager _uiManager = null;
        [Inject] private GameManager _gameManager = null;
        
        public void OnTapRetry()
        {
            _uiManager.OpenScreen(UiScreenName.GAME_SCREEN);
            _gameManager.StartGame();
        }
    }
}
