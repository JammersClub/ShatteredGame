using System;
using UnityEngine;

// ReSharper disable Unity.InefficientPropertyAccess

namespace Movements
{
    public abstract class Movement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 1;
        [SerializeField] private float rotationSpeed = 1;
        [SerializeField] private float orbitOnCenter;
        [SerializeField] private Vector3 orbitOn;
        [NonSerialized] public Vector3 TargetPosition;
        [NonSerialized] public Quaternion TargetRotation;

        public Vector3 MovementDirection => TargetPosition - transform.position;
        public float DistanceToTarget => Vector3.Distance(TargetPosition, transform.position);
        protected float MovementSpeed => movementSpeed;
        protected float RotationSpeed => rotationSpeed;

        protected virtual void Awake()
        {
            TargetPosition = transform.position;
            TargetRotation = transform.rotation;
            if (orbitOnCenter != 0)
                OrbitParentMovement.Create(transform, orbitOn, orbitOnCenter);
        }

        protected virtual void FixedUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, TargetPosition, Time.deltaTime * movementSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, TargetRotation, Time.deltaTime * rotationSpeed);
        }

        [RequireComponent(typeof(Rigidbody))]
        public abstract class Physical : Movement
        {
            [Tooltip("By Pass Y Axis")] [SerializeField]
            private bool bypassGravityAxis = true;

            private Rigidbody _rigidbody;

            public Rigidbody Rigidbody => _rigidbody;

            protected override void Awake()
            {
                base.Awake();
                _rigidbody = GetComponent<Rigidbody>();
            }

            protected override void FixedUpdate()
            {
                var position = Vector3.Lerp(_rigidbody.position, TargetPosition, Time.deltaTime * RotationSpeed);
                if (bypassGravityAxis) position.y = _rigidbody.position.y;
                _rigidbody.MovePosition(position);
                _rigidbody.MoveRotation(Quaternion.Lerp(transform.rotation, TargetRotation,
                    Time.deltaTime * RotationSpeed));
            }
        }
    }
}