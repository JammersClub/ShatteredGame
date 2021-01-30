using UnityEngine;

namespace Puzzle
{
    [RequireComponent(typeof(MeshRenderer))]
    public class ViewDistanceData:MonoBehaviour
    {
        private MeshRenderer _meshRenderer;

        public bool Show
        {
            get => _meshRenderer.enabled;
            set => _meshRenderer.enabled = value;
        }

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }
    }
}