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

        protected float MovementSpeed => movementSpeed;

        protected float RotationSpeed => rotationSpeed;

        private void Awake()
        {
            TargetPosition = transform.position;
            TargetRotation = transform.rotation;
            if(orbitOnCenter!=0)
                OrbitParentMovement.Create(transform, orbitOn, orbitOnCenter);
        }

        private void FixedUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, TargetPosition, Time.deltaTime * movementSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, TargetRotation, Time.deltaTime * rotationSpeed);
        }
        
        [RequireComponent(typeof(Rigidbody))]
        public abstract class Physical : Movement
        {
            [Tooltip("By Pass Z Axis")] [SerializeField] private bool bypassGravityAxis = true;
            private Rigidbody _rigidbody;

            private new void Awake()
            {
                Physics.gravity=Vector3.forward;
                TargetPosition = transform.position;
                TargetRotation = transform.rotation;
                _rigidbody = GetComponent<Rigidbody>();
                if(orbitOnCenter!=0)
                    OrbitParentMovement.Create(transform, orbitOn, orbitOnCenter);
            }

            private new void FixedUpdate()
            {
                var position = Vector3.Lerp(_rigidbody.position, TargetPosition, Time.deltaTime * RotationSpeed);
                if(bypassGravityAxis) position.z = _rigidbody.position.z;
                _rigidbody.MovePosition(position);
                _rigidbody.MoveRotation(Quaternion.Lerp(transform.rotation, TargetRotation,
                    Time.deltaTime * RotationSpeed));
            }
        }
    }
}