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

        private Vector2 _touchBeginPosition;

        private void Update()
        {
            Vector3 inputs = default;
            if (Input.touchCount == 1)
            {
                var touch1 = Input.GetTouch(0);
                // ReSharper disable once SwitchStatementMissingSomeEnumCasesNoDefault
                switch (touch1.phase)
                {
                    case TouchPhase.Began:
                        _touchBeginPosition = touch1.position;
                        break;
                    case TouchPhase.Moved:
                    case TouchPhase.Stationary:
                        inputs = Vector3.ClampMagnitude(touch1.position - _touchBeginPosition, 1);;
                        break;
                }
            }
            else inputs = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            var movement = _camera.TransformDirection(inputs);
            movement.y = 0;
            var velocity = movement.normalized * MovementSpeed;
            velocity.y = Rigidbody.velocity.y;
            Rigidbody.velocity = velocity;
            TargetPosition = transform.TransformPoint(velocity);
            var angle = Mathf.Atan2(-velocity.x, velocity.z) * Mathf.Rad2Deg;
            TargetRotation = Quaternion.AngleAxis(angle, Vector3.up);
        }

        protected override void FixedUpdate()
        {
            Rigidbody.MoveRotation(Quaternion.Lerp(transform.rotation, TargetRotation, Time.deltaTime * RotationSpeed));
        }
    }
}