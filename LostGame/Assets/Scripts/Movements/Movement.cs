using UnityEngine;

// ReSharper disable Unity.InefficientPropertyAccess

namespace Movements
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 1;
        [SerializeField] private float rotationSpeed = 1;
        protected Vector2 TargetPosition;
        protected Quaternion TargetRotation;

        protected float MovementSpeed => movementSpeed;

        protected float RotationSpeed => rotationSpeed;

        private void Update()
        {
            transform.position = Vector2.Lerp(transform.position, TargetPosition, Time.deltaTime * movementSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, TargetRotation, Time.deltaTime * rotationSpeed);
        }
    }
}