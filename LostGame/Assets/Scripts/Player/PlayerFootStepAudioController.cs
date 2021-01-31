using Movements;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(AudioSource))]
    public class PlayerFootStepAudioController:MonoBehaviour
    {
        private AudioSource _audioSource;
        [SerializeField] private Movement playerMovement;
        [SerializeField] private PlayerPlatform platform;
        [SerializeField] private AudioClip waterFootStepClip;
        private AudioClip _footStepClip;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _footStepClip = _audioSource.clip;
        }

        private void Update()
        {
            if(playerMovement.Velocity!=Vector3.zero && !_audioSource.isPlaying)
            {
                if (waterFootStepClip && !platform.CurrentOrLastPlatform)
                    _audioSource.clip = waterFootStepClip;
                else _audioSource.clip = _footStepClip;
                _audioSource.Play();
            }
            else if(playerMovement.Velocity==Vector3.zero && _audioSource.isPlaying)
                _audioSource.Stop();
        }
    }
}