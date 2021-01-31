using Player;
using Puzzle;
using UnityEngine;

namespace Abilities
{
    public sealed class ShieldAbility : Ability
    {
        [Tooltip("In Seconds.")] [SerializeField] private float shieldTime=5;
        [SerializeField] private AudioClip shieldAudioClip;
        private ShieldAuthoring _player;
        private LaserReceiverData _playerLr;
        private AudioSource _playerAudio;
        private float _timer;

        private void Awake()
        {
            enabled = false;
            GetComponent<AbilityAssigner>().OnPlayerEnter += gm =>
            {
                _player = gm.GetComponent<ShieldAuthoring>();
                _playerLr = gm.GetComponent<LaserReceiverData>();
                _playerAudio = gm.GetComponent<AudioSource>();
                if(_player && _playerLr && _playerAudio) enabled = true;
            };
        }

        private void Update()
        {
            _timer -= Time.deltaTime;
            if (_timer < 0)
            {
                _timer = shieldTime * 2;
                _playerAudio.PlayOneShot(shieldAudioClip);
            }

            _playerLr.receiveLaser = _timer < shieldTime;
            _player.ShieldEnabled=!_playerLr.receiveLaser;
        }
    }
}