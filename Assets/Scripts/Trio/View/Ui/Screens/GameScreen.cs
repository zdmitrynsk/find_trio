using Trio.Model;
using Zenject;

namespace Trio.View.Ui.Screens
{
    public class GameScreen : UiScreen
    {
        [Inject] private UiManager _uiManager = null;
        [Inject] private GameManager _gameManager = null;
    }
}
