using Movements;
using UnityEngine;
// ReSharper disable Unity.InefficientPropertyAccess

namespace Player
{
    public class PlayerMovement : Movement.Physical
    {
        private Transform _camera;
        

        // Update is called once per frame
        protected override void Awake()
        {
            base.Awake();
            // ReSharper disable once PossibleNullReferenceException
            _camera = Camera.main.transform;
        }
        private void Update()
        {
            var movement =
                _camera.TransformDirection( new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
            movement.z = 0;
            var velocity = movement.normalized * MovementSpeed;
            velocity.z = Rigidbody.velocity.z;
            Rigidbody.velocity = velocity;
            TargetPosition = transform.TransformPoint(velocity);
            var angle = Mathf.Atan2(-velocity.x, velocity.y) * Mathf.Rad2Deg;
            TargetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        protected override void FixedUpdate()
        {
            Rigidbody.MoveRotation(Quaternion.Lerp(transform.rotation, TargetRotation, Time.deltaTime * RotationSpeed));
        }
    }
}