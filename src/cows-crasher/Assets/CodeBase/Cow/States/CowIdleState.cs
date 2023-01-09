using CodeBase.Cow.States.Abstract;
using CodeBase.Cow.Transitions;
using UnityEngine;

namespace CodeBase.Cow.States
{
    public class CowIdleState : State
    {
        [SerializeField] private float _pauseInSeconds = 2f;
        [field: SerializeField] public override Transition[] Transitions { get; protected set; }

        private float _elapsedPause;
        
        public bool PauseElapsed { get; private set; }

        public override void Enter() =>
            PauseElapsed = false;

        public override void Exit() =>
            PauseElapsed = true;

        private void Update()
        {
            if (PauseElapsed)
                return;
            
            _elapsedPause += Time.deltaTime;

            if (_elapsedPause >= _pauseInSeconds)
            {
                _elapsedPause = 0;
                PauseElapsed = true;
            }
        }
    }
}