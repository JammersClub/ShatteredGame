using UnityEngine;

// ReSharper disable Unity.InefficientPropertyAccess

// ReSharper disable ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
// ReSharper disable ConvertIfStatementToReturnStatement

namespace Movements
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteTranslator : MonoBehaviour
    {
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        [SerializeField] private Movement targetMovement;
        private Animator _animator;
        private Transform _cameraTransform;
        private bool _hasAnimator;
        private float _lastAngle;

        private void Awake()
        {
            // ReSharper disable once PossibleNullReferenceException
            _cameraTransform = Camera.main.transform;
            _animator = GetComponent<Animator>();
            _hasAnimator = _animator;
        }

        private void Update()
        {
            transform.rotation = Quaternion.LookRotation(_cameraTransform.forward, Vector3.up);
            if (!_hasAnimator) return;
            var targetMovementVelocity = _cameraTransform.TransformDirection(targetMovement.Velocity);
            _animator.SetFloat(Vertical, -targetMovementVelocity.x);
            _animator.SetFloat(Horizontal, targetMovementVelocity.z);
        }
    }
}