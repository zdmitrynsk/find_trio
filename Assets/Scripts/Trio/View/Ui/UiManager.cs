using System.Collections.Generic;
using Trio.View.Ui.Screens;
using UnityEngine;

namespace Trio.View.Ui{
    
    public class UiManager : MonoBehaviour
    {
        [SerializeField] private List<UiScreen> _screens = null;
        
        private UiScreen _activeScreen;


        void Start()
        {
            OpenScreen(UiScreenName.START_SCREEN);
        }

        public void OpenScreen(UiScreen screen)
        {
            var screenName = screen.uiScreenName;
            OpenScreen(screenName);
        }
        
        public void OpenScreen(UiScreenName screenName)
        {
            CloseAllScreens();
            var screen = GetUiScreen(screenName);
            screen.UpdateScreenStatus(true);
            _activeScreen = screen;
        }
        
        public UiScreen GetUiScreen(UiScreenName screenInfo)
        {
            return _screens.Find(el => el.uiScreenName == screenInfo);
        }
        
        public void CloseAllScreens()
        {
            foreach (var screen in _screens)
                CloseScreen(screen);
        }
        
        public void CloseScreen(UiScreen screen)
        {
            if (_activeScreen == screen)
                _activeScreen = null;
            
            screen.UpdateScreenStatus(false);
        }
    }
}