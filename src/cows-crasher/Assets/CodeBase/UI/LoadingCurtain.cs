using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public class LoadingCurtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _curtain;
        [SerializeField] private Image _curtainImage;
        [SerializeField] private float _fadingTimeInSeconds;

        private Coroutine _fading;
        
        public void Show(Action onDone = null)
        {
            if (IsFadingNow()) 
                StopFading();

            _fading = StartCoroutine(Fading(1, onDone));
        }

        public void Hide(Action onDone = null)
        {
            if (IsFadingNow())
                StopFading();
            
            _fading = StartCoroutine(Fading(0, onDone));
        }

        private bool IsFadingNow() => 
            _fading != null;

        private void StopFading()
        {
            StopCoroutine(_fading);
            _fading = null;
        }

        private IEnumerator Fading(float target, Action onDone = null)
        {
            var current = _curtain.alpha;
            _curtainImage.enabled = true;
            var t = 0f;
            
            while (t < _fadingTimeInSeconds)
            {
                var progress = t / _fadingTimeInSeconds;
                _curtain.alpha = Mathf.Lerp(current, target, progress);
                t += Time.deltaTime;
                yield return null;
            }

            _curtain.alpha = target;
            _curtainImage.enabled = _curtain.alpha >= 1;
            onDone?.Invoke();
        }
    }
}