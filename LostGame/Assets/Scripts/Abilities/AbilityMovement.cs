using Movements;
using UnityEngine;

namespace Abilities
{
    [RequireComponent(typeof(AbilityAssigner))]
    public class AbilityMovement : Movement
    {
        [SerializeField] private Vector3 offset;
        private Movement _player;

        protected override void Awake()
        {
            enabled = false;
            GetComponent<AbilityAssigner>().OnPlayerEnter += gm =>
            {
                _player = gm.GetComponent<Movement>();
                if (_player) enabled = true;
            };
        }

        private void Update()
        {
            TargetPosition = _player.transform.TransformPoint(offset);
            TargetRotation = _player.TargetRotation;
        }
    }
}