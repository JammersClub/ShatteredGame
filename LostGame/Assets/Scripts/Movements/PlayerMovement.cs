using UnityEngine;

namespace Movements
{
    public class PlayerMovement : Movement
    {
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            TargetPosition.y += Input.GetAxis("Vertical") * Time.deltaTime * MovementSpeed;
            TargetPosition.x += Input.GetAxis("Horizontal") * Time.deltaTime * MovementSpeed;
            var dir = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            TargetRotation = Quaternion.AngleAxis(angle, Vector3.forward);;
        }
    }
}