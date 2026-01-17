using System;
using System.Collections;
using Develop._1._2.Timer.Develop.Example2;
using UnityEngine;

namespace Develop._1._2.Timer
{
    public class Timer
    {
        private readonly ReactiveVariable<float> _timeLimit;
        private readonly ReactiveVariable<float> _currentTime;

        private readonly MonoBehaviour _coroutineRunner;
        private Coroutine _process;

        public Timer(MonoBehaviour coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;

            _timeLimit = new ReactiveVariable<float>();
            _currentTime = new ReactiveVariable<float>();
        }

        public IReadOnlyVariable<float> TimeLimit => _timeLimit;
        public IReadOnlyVariable<float> CurrentTime => _currentTime;

        public void SetTime(float time)
        {
            if (time <= 0)
                throw new ArgumentOutOfRangeException(nameof(time), "Time must be greater than zero");

            _timeLimit.Value = time;
            _currentTime.Value = _timeLimit.Value;
        }

        public void StartProcess()
        {
            StopProcess();
            _process = _coroutineRunner.StartCoroutine(Process());
        }

        public void StopProcess()
        {
            if(_process != null)
            {
                _coroutineRunner.StopCoroutine(_process);
                _process =  null;
            }
        }

        public void ResetTime()
        {
            if(InProcess() == false)
                _currentTime.Value = _timeLimit.Value;
        }

        public bool InProcess() => _process != null;

        private IEnumerator Process()
        {
            while (_currentTime.Value > 0)
            {
                _currentTime.Value -= Time.deltaTime;

                if(_currentTime.Value > _timeLimit.Value)
                    _currentTime.Value = _timeLimit.Value;

                yield return null;
            }

            _process =  null;
        }
    }
}
