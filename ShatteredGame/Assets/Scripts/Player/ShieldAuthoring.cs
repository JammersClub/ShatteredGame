using Puzzle;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(LaserReceiverData))]
    public class ShieldAuthoring : MonoBehaviour
    {
        [SerializeField] private GameObject shieldObject;
        [SerializeField] private AudioSource shieldAudio;

        private bool _shieldEnabled = true;

        public bool ShieldEnabled
        {
            get => _shieldEnabled;
            set
            {
                if (_shieldEnabled != value)
                {
                    shieldObject.SetActive(value);
                    if (value)
                        shieldAudio.Play();
                }

                _shieldEnabled = value;
            }
        }

        private void Awake()
        {
            ShieldEnabled = false;
        }
    }
}