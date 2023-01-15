using UnityEngine;

namespace CodeBase.UI
{
    public class FadingControl : MonoBehaviour
    {
        [SerializeField] private LoadingCurtain _loadingCurtain;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
                _loadingCurtain.Show();
            else if (Input.GetKeyDown(KeyCode.X))
                _loadingCurtain.Hide();
        }
    }
}