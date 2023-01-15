using System;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.LevelManagement
{
    public class FinishGameCutscene : Cutscene
    {
        [SerializeField] private GameObject _alien;
        [SerializeField] private GameObject _cow;
        [SerializeField] private Storyteller _defenceStory;
        [SerializeField] private Storyteller _cowStory;
        [SerializeField] private AudioSource _mooSfx;
        [SerializeField] private AudioSource _transformationSfx;
        [SerializeField] private UfoMovementCutscene _movementCutscene;
        [SerializeField] private ParticleSystem _vfx;

        private Action _onEnded;
        
        public override void Play(Action onEnded = null)
        {
            _onEnded = onEnded;
            _defenceStory.Show(OnDoneDefenceStory);
        }

        private void OnDoneDefenceStory()
        {
            _vfx.Play();
            _transformationSfx.Play();
            _mooSfx.Play();
            _alien.SetActive(false);
            _cow.SetActive(true);
            _cowStory.Show(onEnded: MoveToSpace);
        }

        private void MoveToSpace()
        {
            _onEnded?.Invoke();
            _movementCutscene.Play();
        }
    }
}