using Movements;
using UnityEngine;

namespace Puzzle
{
    public class DoorAuthoring : Movement
    {
        [SerializeField] private Vector3 openPoint;
        [SerializeField] private Vector3 closePoint;
        private bool removeParent = false;

        protected override void Awake()
        {
            base.Awake();
            if(removeParent) transform.parent = null;
            openPoint = transform.TransformPoint(openPoint);
            closePoint = transform.TransformPoint(closePoint);
            _isOpen = false;
        }

        private bool _isOpen;
        public bool IsOpen
        {
            get => _isOpen;
            set
            {
                _isOpen = value;
                TargetPosition = value ? openPoint : closePoint;
            }
        }
    }
}