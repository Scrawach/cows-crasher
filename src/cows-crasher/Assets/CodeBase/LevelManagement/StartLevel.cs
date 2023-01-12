using CodeBase.CameraLogic;
using CodeBase.Player;
using CodeBase.Ufo;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.LevelManagement
{
    public class StartLevel : MonoBehaviour
    {
        [SerializeField] private PlayerInput _input;
        [SerializeField] private CameraFollow _cameraFollow;
        [SerializeField] private UfoMovementCutscene _cutscene;
        [SerializeField] private Storyteller _storyteller;

        private void Awake()
        {
            _input.IsBlocked = true;
            _cameraFollow.enabled = false;
        }

        private void Start() =>
            _cutscene.Play(StartStory);

        private void StartStory()
        {
            if (_storyteller != null)
                _storyteller.Show(EnableMovement);
            else
                EnableMovement();
        }

        private void EnableMovement()
        {
            _input.IsBlocked = false;
            _cameraFollow.enabled = true;
            _cameraFollow.Follow(_input.transform);
        }
    }
}