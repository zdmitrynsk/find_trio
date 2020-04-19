using System;
using TMPro;
using Trio.Model;
using UnityEngine;
using Zenject;

namespace Trio.View.Ui
{
    public class TimerText : MonoBehaviour
    {
        [Inject] private TimerManager _timerManager = null;

        [SerializeField] private TextMeshProUGUI textTimer = null; 

        void Start ()
        {
            _timerManager.OnUpdateUpdateTimer += OnUpdateUpdateTimer;
            SetTimerText(_timerManager.CurrentTimerValue);
        }
    
        private void OnUpdateUpdateTimer(int seconds)
        {
            SetTimerText(seconds);
        }

        private void SetTimerText(int seconds)
        {
            textTimer.text = TimeSpan.FromSeconds(seconds).ToString(@"hh\:mm\:ss");
        }
    }
}
