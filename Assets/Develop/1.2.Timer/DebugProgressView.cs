using System;
using UnityEngine;

namespace Develop._1._2.Timer
{
    public class DebugProgressView : IProgressUpdater
    {
        public void UpdateProgress(float oldValue, float newValue)
        {
            string currentTime = TimeSpan.FromSeconds(newValue).ToString(@"mm\:ss");
            Debug.Log($"Current Time - {currentTime}");
        }

        public void ResetProgress(float oldValue, float newValue)
        {
            Debug.Log($"Timer has been reset. Current Time - {newValue}");
        }
    }
}
