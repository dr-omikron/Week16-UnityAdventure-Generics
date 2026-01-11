namespace Develop._1._2.Timer
{
    public interface IProgressUpdater
    {
        void UpdateProgress(float oldValue, float newValue);
        void ResetProgress(float oldValue, float newValue);
    }
}
