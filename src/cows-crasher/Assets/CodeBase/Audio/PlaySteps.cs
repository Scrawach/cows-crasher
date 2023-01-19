using JetBrains.Annotations;
using UnityEngine;

namespace CodeBase.Audio
{
    public class PlaySteps : MonoBehaviour
    {
        [SerializeField] private AudioPlayer _stepPlayer;

        [UsedImplicitly]
        public void Play()
        {
            var player = Instantiate(_stepPlayer, transform.position, Quaternion.identity);
            player.Play();
        }
    }
}