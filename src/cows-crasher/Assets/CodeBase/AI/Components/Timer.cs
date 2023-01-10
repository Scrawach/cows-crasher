using UnityEngine;

namespace CodeBase.AI.Components
{
    public class Timer : MonoBehaviour
    {
        public float Target;
        
        public float Elapsed { get; private set; }
        
        public bool IsPlaying { get; private set; }
        
        public bool IsDone { get; private set; }

        private void Update()
        {
            if (IsPlaying)
                UpdateTimer();
        }

        private void UpdateTimer()
        {
            Elapsed += Time.deltaTime;

            if (Elapsed >= Target)
            {
                IsPlaying = false;
                IsDone = true;
            }
        }

        public void Play()
        {
            Elapsed = 0;
            IsPlaying = true;
            IsDone = false;
        }

        public void Erase()
        {
            Elapsed = 0;
            IsPlaying = false;
            IsDone = false;
        }
    }
}