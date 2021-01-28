using UnityEngine;

// ReSharper disable Unity.InefficientPropertyAccess

namespace Movements
{
    public abstract class Movement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 1;
        [SerializeField] private float rotationSpeed = 1;
        protected Vector2 TargetPosition;
        protected Quaternion TargetRotation;

        protected float MovementSpeed => movementSpeed;

        protected float RotationSpeed => rotationSpeed;

        private void FixedUpdate()
        {
            transform.position = Vector2.Lerp(transform.position, TargetPosition, Time.deltaTime * movementSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, TargetRotation, Time.deltaTime * rotationSpeed);
        }
    }

    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class PhysicalMovement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 1;
        [SerializeField] private float rotationSpeed = 1;
        private Rigidbody2D _rigidbody2D;
        protected Vector2 TargetPosition;
        protected Quaternion TargetRotation;

        protected float MovementSpeed => movementSpeed;

        protected float RotationSpeed => rotationSpeed;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rigidbody2D.MovePosition(Vector2.Lerp(_rigidbody2D.position, TargetPosition,
                Time.deltaTime * movementSpeed));
            _rigidbody2D.MoveRotation(Quaternion.Lerp(transform.rotation, TargetRotation,
                Time.deltaTime * rotationSpeed));
        }
    }
}