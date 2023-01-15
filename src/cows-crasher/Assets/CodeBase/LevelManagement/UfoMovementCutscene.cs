using System;
using System.Collections;
using UnityEngine;

namespace CodeBase.LevelManagement
{
    public class UfoMovementCutscene : Cutscene
    {
        [SerializeField] private Vector3 _movement;
        [SerializeField] private float _duration;
        [SerializeField] private Transform _ufo;
        [SerializeField] private float _waitBeforeStart;
        [SerializeField] private bool _skip;
        
        public override void Play(Action onEnded = null)
        {
            if (_skip)
            {
                _ufo.position += _movement;
                onEnded?.Invoke();
            }
            else
            {
                StartCoroutine(Disappearance(_ufo, _movement, _duration, onEnded));
            }
        }

        private IEnumerator Disappearance(Transform ufo, Vector3 target, float duration, Action onEnded = null)
        {
            yield return new WaitForSeconds(_waitBeforeStart);

            var deltaTimeWait = new WaitForEndOfFrame();
            var start = ufo.position;
            var end = start + target;
            var timeStep = Time.deltaTime / duration;
            var progress = 0f;

            while (progress < 1f)
            {
                progress += timeStep;
                ufo.position = Vector3.Lerp(start, end, progress);
                yield return deltaTimeWait;
            }
            
            onEnded?.Invoke();
        }
    }
}