using UnityEngine;

namespace CodeBase.Audio
{
    public class AudioGameTheme : MonoBehaviour
    {
        private void Awake() => 
            DontDestroyOnLoad(gameObject);
    }
}