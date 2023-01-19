using CodeBase.CameraLogic;
using CodeBase.Player;
using CodeBase.Ufo;
using CodeBase.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.LevelManagement
{
    public class FinishLevel : MonoBehaviour
    {
        [SerializeField] private UfoCollector _collector;
        [SerializeField] private LevelData _level;
        [SerializeField] private PlayerInput _input;
        [SerializeField] private CameraFollow _cameraFollow;
        [SerializeField] private Cutscene _cutscene;
        [SerializeField] private LoadingCurtain _loadingCurtain;
        
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
            
            _cutscene.Play(() =>
            {
                _loadingCurtain.Show(LoadNextLevel);
            });
        }

        private void LoadNextLevel()
        {
            var current = SceneManager.GetActiveScene();
            var nextSceneIndex = current.buildIndex + 1;
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
                SceneManager.LoadScene(nextSceneIndex);
        }
    }
}