using UnityEngine;

// ReSharper disable Unity.InefficientPropertyAccess

namespace Movements
{
    public class OrbitParentMovement : Movement
    {
        private float _rotationAngle;
        private float _speedAndDirection;

        private void Update()
        {
            _rotationAngle += Time.deltaTime * _speedAndDirection;
            TargetRotation = Quaternion.AngleAxis(_rotationAngle, Vector3.forward);
        }

        public static void Create(Transform child, Vector2 center, float movementSpeed)
        {
            var gm = new GameObject($"{child.name} Orbit Parent.").AddComponent<OrbitParentMovement>();
            gm.transform.position = center;
            gm._speedAndDirection = movementSpeed;
            child.parent = gm.transform;
        }
    }
}