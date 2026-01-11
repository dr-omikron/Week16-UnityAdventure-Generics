using UnityEngine;
using UnityEngine.UI;

namespace Develop._1._2.Timer
{
    public class SliderProgressView : MonoBehaviour, IProgressUpdater
    {
        [SerializeField] private Image _slider;

        private float _timeLimit;

        private void Awake()
        {
            ResetView();
        }

        public void Initialize(float timeLimit) => _timeLimit = timeLimit;

        public void UpdateProgress(float oldValue, float newValue)
        {
            SetPercent(newValue / _timeLimit);
        }

        public void ResetProgress(float oldValue, float newValue) => ResetView();

        private void SetPercent(float percent)
        {
            if(percent < 0)
            {
                Debug.Log("Percent is less than 0");
                return;
            }

            _slider.fillAmount = percent;
        }

        private void ResetView() => _slider.fillAmount = 1;
    }
}
