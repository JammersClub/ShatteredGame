using Player;
using Puzzle;
using UnityEngine;

namespace Abilities
{
    public sealed class ShieldAbility : Ability
    {
        [Tooltip("In Seconds.")] [SerializeField]
        private float shieldTime = 5;

        private ShieldAuthoring _player;
        private LaserReceiverData _playerLr;
        private float _timer;

        protected override void Awake()
        {
            base.Awake();
            enabled = false;
            GetComponent<AbilityAssigner>().OnPlayerEnter += gm =>
            {
                _player = gm.GetComponent<ShieldAuthoring>();
                _playerLr = gm.GetComponent<LaserReceiverData>();
                if (!_player || !_playerLr) return;
                enabled = true;
                MarkAsOk();
            };
        }

        private void Update()
        {
            _timer -= Time.deltaTime;
            if (_timer < 0) _timer = shieldTime * 2;
            _playerLr.receiveLaser = _timer < shieldTime;
            _player.ShieldEnabled = !_playerLr.receiveLaser;
        }
    }
}