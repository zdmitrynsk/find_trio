using System.Collections;
using UnityEngine;

namespace Trio.Model
{
    public class TimerManager : MonoBehaviour
    {
        public delegate void ListenerUpdateTimer(int seconds);
        public ListenerUpdateTimer OnUpdateUpdateTimer = (int seconds) => {}; 

        public int CurrentTimerValue {get; set;}
        
        private Coroutine _coroutineTimer;
        
        public void StartTimer()
        {
            StopTimer();
            _coroutineTimer = StartCoroutine(StartTimerCoroutine());
        }
        
        public void StopTimer()
        {
            if (_coroutineTimer != null)
                StopCoroutine(_coroutineTimer);
            _coroutineTimer = null;
            CurrentTimerValue = 0;
        }

        public void ResumeTimer()
        {
            if (_coroutineTimer == null)
                _coroutineTimer = StartCoroutine(StartTimerCoroutine());
        }

        public void PauseTimer()
        {
            if (_coroutineTimer != null)
            {
                StopCoroutine(_coroutineTimer);
                _coroutineTimer = null;
            }
        }
        
        private IEnumerator StartTimerCoroutine()
        {
            while (true)
            {
                OnUpdateUpdateTimer(CurrentTimerValue);
                yield return new WaitForSeconds(1.0f);
                CurrentTimerValue++;
            }
        }
    }
}
