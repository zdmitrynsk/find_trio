using Trio.Model;
using Trio.Model.GridPairs;
using Trio.View;
using Trio.View.Ui;
using UnityEngine;
using Zenject;

namespace Trio
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private UiManager uiManager = null;
        [SerializeField] private GameManager gameManager = null;
        [SerializeField] private TimerManager timerManager = null;
        [SerializeField] private CardIconsManager cardIconsManager = null;
        [SerializeField] private GridViewManager gridViewManager = null;
        [SerializeField] private GridCardViewCreator gridCardViewCreator = null;
        
        public override void InstallBindings()
        {
            Container.BindInstance(uiManager).AsSingle();
            Container.BindInstance(gameManager).AsSingle();
            Container.BindInstance(timerManager).AsSingle();
            Container.BindInstance(cardIconsManager).AsSingle();
            Container.BindInstance(gridViewManager).AsSingle();
            Container.BindInstance(gridCardViewCreator).AsSingle();
        }
    }
}
