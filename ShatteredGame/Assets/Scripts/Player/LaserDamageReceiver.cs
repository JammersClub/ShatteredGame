using Movements;
using Puzzle;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Movement))]
    [RequireComponent(typeof(PlayerPlatform))]
    public class LaserDamageReceiver : LaserReceiverData
    {
        [SerializeField] private AudioSource takeDamageAudio;
        private Movement _movement;
        private PlayerPlatform _platform;

        protected override void Awake()
        {
            base.Awake();
            _platform = GetComponent<PlayerPlatform>();
            _movement = GetComponent<Movement>();
        }

        public override void OnCollisionWithLaser(LaserSource laserSource)
        {
            base.OnCollisionWithLaser(laserSource);
            if (_platform.CurrentOrLastPlatform)
            {
                _movement.ForceMove(_platform.CurrentOrLastPlatform.RespawnPoint.position, _movement.TargetRotation);
                _platform.CurrentOrLastPlatform.RePlacePlatform();
                if (takeDamageAudio) takeDamageAudio.Play();
            }
            else
            {
                _movement.ForceMove(default, _movement.TargetRotation);
            }
        }
    }
}