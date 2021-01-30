using Puzzle;
using UnityEngine;

namespace Abilities
{
    public sealed class ShieldAbility : Ability
    {
        [Tooltip("In Seconds.")] [SerializeField] private float shieldTime=5;
        [SerializeField] private GameObject shieldGraphicalObject;
        private LaserReceiverData _player;
        private float _timer;

        private void Awake()
        {
            enabled = false;
            shieldGraphicalObject.SetActive(false);
            GetComponent<AbilityAssigner>().OnPlayerEnter += gm =>
            {
                _player = gm.GetComponent<LaserReceiverData>();
                if(_player) enabled = true;
            };
        }

        private void Update()
        {
            _timer -= Time.deltaTime;
            if (_timer < 0) _timer = shieldTime * 2;
            _player.receiveLaser=_timer > shieldTime;
            shieldGraphicalObject.SetActive(!_player.receiveLaser);
        }
    }
}