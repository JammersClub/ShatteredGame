using Movements;
using UnityEngine;

namespace Puzzle
{
    public class DoorAuthoring : Movement
    {
        [SerializeField] private Vector3 openPoint;
        [SerializeField] private Vector3 closePoint;

        private bool _isOpen;
        public bool IsOpen
        {
            get => _isOpen;
            set
            {
                _isOpen = value;
                TargetPosition = transform.TransformPoint(value ? openPoint : closePoint);
            }
        }
    }
}