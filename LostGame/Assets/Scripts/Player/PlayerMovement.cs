using Movements;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : PhysicalMovement
    {
        // Update is called once per frame
        private void Update()
        {
            TargetPosition.y += Input.GetAxis("Vertical") * Time.deltaTime * MovementSpeed;
            TargetPosition.x += Input.GetAxis("Horizontal") * Time.deltaTime * MovementSpeed;
            var dir = (Vector3) TargetPosition - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            TargetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}