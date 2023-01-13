using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Logic
{
    public class RandomTextureOnAwake : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _mesh;
        [SerializeField] private Texture[] _textures;
        
        private static readonly int Texture = Shader.PropertyToID("_MainTex");

        private void Awake()
        {
            var randomIndex = Random.Range(0, _textures.Length);
            _mesh.material.SetTexture(Texture, _textures[randomIndex]);
        }
    }
}