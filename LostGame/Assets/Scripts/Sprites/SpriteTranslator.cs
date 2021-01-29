using System;
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
        private const int Offset=62;
        [SerializeField] private Movement targetMovement;
        [SerializeField] private float spriteLerpSpeed=1f;
        private SpriteRenderer _spriteRenderer;
        private float _lastAngle;
        private Transform _cameraTransform;
        private Animator _animator;
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");

        private void Awake()
        {
            // ReSharper disable once PossibleNullReferenceException
            _cameraTransform = Camera.main.transform;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            var position = targetMovement.transform.position;
            transform.position = position;
            transform.rotation=Quaternion.LookRotation(_cameraTransform.forward,-Vector3.forward);
            var movement = targetMovement.transform.InverseTransformDirection(-_cameraTransform.forward);
            _animator.SetFloat(Vertical,movement.y);
            _animator.SetFloat(Horizontal,movement.x);
        }
    }
}