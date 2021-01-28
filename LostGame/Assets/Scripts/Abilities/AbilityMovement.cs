using Movements;
using UnityEngine;

namespace Abilities
{
    public class AbilityMovement : Movement.Physical
    {
        [SerializeField] private Vector2 offset;
        private Movement _target;

        public Movement Target
        {
            set
            {
                _target = value;
                TargetIsNull = _target == null;
            }
        }

        public bool TargetIsNull { get; private set; } = true;

        private void Update()
        {
            if (TargetIsNull) return;
            TargetPosition = _target.transform.TransformPoint(offset);
            TargetRotation = _target.TargetRotation;
        }
    }
}