using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Develop._1._2.Timer
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _resetButton;
        [SerializeField] private Button _pauseButton;

        [SerializeField] private TMP_Text _timerText;

        private Timer _timer;

        public void Initialize(Timer timer)
        {
            _timer = timer;

            _timer.CurrentTime.Changed += OnTimerTicked;
            _timer.TimeLimit.Changed += OnTimerReset;

            _startButton.onClick.AddListener(OnStartButtonClicked);
            _resetButton.onClick.AddListener(OnResetButtonClicked);
            _pauseButton.onClick.AddListener(OnPauseButtonClicked);
        }

        private void OnStartButtonClicked() => _timer.StartProcess();

        private void OnResetButtonClicked() => _timer.ResetTime();

        private void OnPauseButtonClicked() => _timer.StopProcess();

        private void OnTimerReset(float oldValue, float newValue) => 
            _timerText.text = TimeSpan.FromSeconds(newValue).ToString(@"mm\:ss");

        private void OnTimerTicked(float oldValue, float newValue) 
            => _timerText.text = TimeSpan.FromSeconds(newValue).ToString(@"mm\:ss");

        private void OnDestroy()
        {
            _timer.CurrentTime.Changed -= OnTimerTicked;
            _timer.TimeLimit.Changed -= OnTimerReset;

            _startButton.onClick.RemoveListener(OnStartButtonClicked);
            _resetButton.onClick.RemoveListener(OnResetButtonClicked);
            _pauseButton.onClick.RemoveListener(OnPauseButtonClicked);
        }

    }
}
