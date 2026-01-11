using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Develop._1._2.Timer
{
    public class ImagesProgressView : MonoBehaviour, IProgressUpdater
    {
        private const float StepThreshold = 0.99f;
        
        [SerializeField] private List<Image> _images;

        private int _maxSize;
        private int _iterator;
        private float _lastProgress;
        private float _step;

        public void Initialize(float timeLimit)
        {
            _maxSize = _images.Count;
            _step = timeLimit / _maxSize;
            ResetView(timeLimit);
        }

        public void UpdateProgress(float oldValue, float newValue)
        {
            float currentProgress = _lastProgress - newValue;

            if(currentProgress / _step >= StepThreshold)
            {
                NextStep();
                _lastProgress = newValue;
            }
        }

        public void ResetProgress(float oldValue, float newValue) => ResetView(newValue);

        private void NextStep()
        {
            if (_iterator < 0)
                return;

            _images[_iterator].gameObject.SetActive(false);
            _iterator--;
        }

        private void ResetView(float timeLimit)
        {
            _iterator = _maxSize - 1;
            _lastProgress = timeLimit;

            foreach (Image image in _images)
                image.gameObject.SetActive(true);
        }
    }
}
