using System;
using Trio.Model.GridPairs;
using Trio.View;
using Trio.View.Ui;
using Trio.View.Ui.Screens;
using UnityEngine;
using Zenject;

namespace Trio.Model
{
    public class GameManager : MonoBehaviour
    {
        [Inject] private TimerManager _timerManager = null;
        [Inject] private GridViewManager _gridViewManager = null;
        [Inject] private GameConfig _gameConfig = null;
        [Inject] private CardIconsManager _cardIconsManager = null;
        [Inject] private UiManager _uiManager = null;

        public void StartGame()
        {
            MoveCameraToCenterGrid();
            InitGrid();
            _timerManager.StartTimer();
        }

        private void MoveCameraToCenterGrid()
        {
            Camera.main.transform.position = new Vector3(
                _gameConfig.widthGrid / 2f
                , _gameConfig.heightGrid / 2f
                , 0);
            Camera.main.orthographicSize = Math.Max(_gameConfig.widthGrid, _gameConfig.heightGrid);
        }

        private void InitGrid()
        {
            Vector2Int sizeGrid = new Vector2Int(_gameConfig.widthGrid, _gameConfig.heightGrid);
            var grid = GridCardsDataCreator.Create(
                sizeGrid
                , _cardIconsManager.GetSpritesIconCard().Count
                , _gameConfig.countCardsPerType);
            _gridViewManager.ShowGrid(grid, _gameConfig.countCardsPerType);
            _gridViewManager.OnFinishGrid = OnFinishGrid;
        }

        private void OnFinishGrid()
        {
            _gridViewManager.DestroyGridCardsViews();
            _timerManager.StopTimer();
            _uiManager.OpenScreen(UiScreenName.FINISH_SCREEN);
        }

        public void PauseGame()
        {
            _timerManager.PauseTimer();
        }
        
        public void ResumeGame()
        {
            _timerManager.ResumeTimer();
        }
    }
}
