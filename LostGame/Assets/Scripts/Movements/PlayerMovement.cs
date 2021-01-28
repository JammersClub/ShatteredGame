using UnityEngine;

namespace Movements
{
    public class PlayerMovement : Movement
    {
        // Update is called once per frame
        private void FixedUpdate()
        {
            TargetPosition.y += Input.GetAxis("Vertical") * Time.deltaTime * MovementSpeed;
            TargetPosition.x += Input.GetAxis("Horizontal") * Time.deltaTime * MovementSpeed;
        }
    }
}