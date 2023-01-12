using System;
using CodeBase.CameraLogic;
using CodeBase.Player;
using CodeBase.Ufo;
using UnityEngine;

namespace CodeBase.LevelManagement
{
    public class FinishLevel : MonoBehaviour
    {
        [SerializeField] private UfoCollector _collector;
        [SerializeField] private LevelData _level;
        [SerializeField] private PlayerInput _input;
        [SerializeField] private CameraFollow _cameraFollow;
        [SerializeField] private UfoMovementCutscene _cutscene;
        
        private void OnEnable() =>
            _collector.Changed += OnScoreChanged;

        private void OnDisable() =>
            _collector.Changed -= OnScoreChanged;

        private void OnScoreChanged()
        {
            if (_collector.Count >= _level.GoalScore) 
                Finish();
        }

        private void Finish()
        {
            _input.IsBlocked = true;
            _cameraFollow.enabled = false;
            _cutscene.Play(LoadNextLevel);
        }

        private void LoadNextLevel()
        {
            Debug.Log($"Go to next level!");
        }
    }
}