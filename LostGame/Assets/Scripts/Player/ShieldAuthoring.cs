using Puzzle;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(LaserReceiverData))]
    public class ShieldAuthoring:MonoBehaviour
    {
        [SerializeField] private GameObject shieldObject;

        private bool _shieldEnabled;
        public bool ShieldEnabled
        {
            get => _shieldEnabled;
            set
            {
                _shieldEnabled = value;
                shieldObject.SetActive(value);
            }
        }

        private void Awake()
        {
            ShieldEnabled = false;
        }
    }
}