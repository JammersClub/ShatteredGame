using Movements;
using UnityEngine;

// ReSharper disable Unity.InefficientPropertyAccess

// ReSharper disable ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
// ReSharper disable ConvertIfStatementToReturnStatement

namespace Sprites
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Animator))]
    public class SpriteTranslator : MonoBehaviour
    {
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        [SerializeField] private Movement targetMovement;
        private Animator _animator;
        private Transform _cameraTransform;
        private float _lastAngle;

        private void Awake()
        {
            // ReSharper disable once PossibleNullReferenceException
            _cameraTransform = Camera.main.transform;
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            transform.rotation = Quaternion.LookRotation(_cameraTransform.forward, Vector3.up);
            var movement = targetMovement.transform.InverseTransformDirection(_cameraTransform.forward);
            _animator.SetFloat(Vertical, -movement.x);
            _animator.SetFloat(Horizontal, movement.z);
        }
    }
}