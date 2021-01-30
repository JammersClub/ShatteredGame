using Movements;
using UnityEngine;

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
            var velocity = Rigidbody.velocity;
            velocity += movement.normalized * (Time.deltaTime * MovementSpeed);
            Rigidbody.velocity = Vector3.ClampMagnitude(velocity,MovementSpeed);
            TargetPosition = transform.TransformPoint(velocity);
            var dir = velocity;
            var angle = Mathf.Atan2(-dir.x, dir.y) * Mathf.Rad2Deg;
            TargetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        protected override void FixedUpdate()
        {
            Rigidbody.MoveRotation(Quaternion.Lerp(transform.rotation, TargetRotation, Time.deltaTime * RotationSpeed));
        }
    }
}