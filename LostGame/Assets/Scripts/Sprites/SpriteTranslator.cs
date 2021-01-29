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
    public class SpriteTranslator : MonoBehaviour
    {
        private const int Offset=62;
        [SerializeField] private Movement targetMovement;
        [SerializeField] private CharacterDirectionalSprites spritesList;
        [SerializeField] private float spriteLerpSpeed=1f;
        private SpriteRenderer _spriteRenderer;
        private float _lastAngle;
        private Transform _cameraTransform;

        private void Awake()
        {
            // ReSharper disable once PossibleNullReferenceException
            _cameraTransform = Camera.main.transform;
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            var position = targetMovement.transform.position;
            transform.position = position;
            transform.rotation=Quaternion.LookRotation(-_cameraTransform.forward,Vector3.forward);
            _lastAngle = Mathf.Lerp(_lastAngle, targetMovement.transform.eulerAngles.z, Time.deltaTime*spriteLerpSpeed);
            _spriteRenderer.sprite = spritesList[_lastAngle + Offset];
        }
    }
    [Serializable]
    public struct CharacterDirectionalSprites
    {
        [SerializeField] private Sprite @default;
        [SerializeField] private Sprite topLeft;
        [SerializeField] private Sprite topMiddle;
        [SerializeField] private Sprite topRight;
        [SerializeField] private Sprite middleLeft;
        [SerializeField] private Sprite middleRight;
        [SerializeField] private Sprite downLeft;
        [SerializeField] private Sprite downMiddle;
        [SerializeField] private Sprite downRight;
        private const int Tolerance=10;
        public Sprite this[float angleToUp]
        {
            get
            {
                if (Math.Abs(angleToUp-135f)<Tolerance) return topLeft;
                if (Math.Abs(angleToUp-90f)<Tolerance) return topMiddle;
                if (Math.Abs(angleToUp-45f)<Tolerance) return topRight;
                if (Math.Abs(angleToUp-180f)<Tolerance) return middleLeft;
                if (Math.Abs(angleToUp-0f)<Tolerance) return middleRight;
                if (Math.Abs(angleToUp-225f)<Tolerance) return downLeft;
                if (Math.Abs(angleToUp-270f)<Tolerance) return downMiddle;
                if (Math.Abs(angleToUp-315f)<Tolerance) return downRight;
                if (Math.Abs(angleToUp-360f)<Tolerance) return middleRight;
                return @default;
            }
        }
    }
}