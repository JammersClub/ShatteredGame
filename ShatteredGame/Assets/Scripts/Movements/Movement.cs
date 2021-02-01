using System;
using UnityEngine;

// ReSharper disable Unity.InefficientPropertyAccess

namespace Movements
{
    public abstract class Movement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 1;
        [SerializeField] private float rotationSpeed = 1;
        [NonSerialized] public Vector3 TargetPosition;
        [NonSerialized] public Quaternion TargetRotation;

        public float DistanceToTarget => Vector3.Distance(TargetPosition, transform.position);
        protected float MovementSpeed => movementSpeed;
        protected float RotationSpeed => rotationSpeed;
        public virtual Vector3 Velocity => TargetPosition - transform.position;

        protected virtual void Awake()
        {
            TargetPosition = transform.position;
            TargetRotation = transform.rotation;
        }

        protected virtual void FixedUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, TargetPosition, Time.deltaTime * movementSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, TargetRotation, Time.deltaTime * rotationSpeed);
        }

        public void ForceMove(Vector3 position, Quaternion rotation)
        {
            TargetPosition = position;
            TargetRotation = rotation;
            ForceMove();
        }

        public void ForceMove()
        {
            transform.position = TargetPosition;
            transform.rotation = TargetRotation;
        }

        [RequireComponent(typeof(Rigidbody))]
        public abstract class Physical : Movement
        {
            [Tooltip("By Pass Y Axis")] [SerializeField]
            private bool bypassGravityAxis = true;

            public Rigidbody Rigidbody { get; private set; }

            public override Vector3 Velocity => Rigidbody.velocity;

            protected override void Awake()
            {
                base.Awake();
                Rigidbody = GetComponent<Rigidbody>();
            }

            protected override void FixedUpdate()
            {
                var position = Vector3.Lerp(Rigidbody.position, TargetPosition, Time.deltaTime * RotationSpeed);
                if (bypassGravityAxis) position.y = Rigidbody.position.y;
                Rigidbody.MovePosition(position);
                Rigidbody.MoveRotation(Quaternion.Lerp(transform.rotation, TargetRotation,
                    Time.deltaTime * RotationSpeed));
            }
        }
    }
}