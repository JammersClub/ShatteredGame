using System;
using UnityEngine;

// ReSharper disable Unity.InefficientPropertyAccess

namespace Puzzle
{
    [RequireComponent(typeof(LineRenderer))]
    public class LaserSource : MonoBehaviour
    {
        [SerializeField] private float maxLaserLen = 500;
        private const int MAXObjectsToDetect = 20;
        private LineRenderer _lineRenderer;
        private RaycastHit[] _raycastHits;
        public event Action<Collider> OnCollision; 

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _raycastHits = new RaycastHit[MAXObjectsToDetect];
            _lineRenderer.positionCount = 2;
        }

        private void Update()
        {
            _lineRenderer.SetPosition(0, transform.position);
            var ray = new Ray(transform.position, transform.forward);
            var point=transform.TransformPoint(new Vector3(0, 0,maxLaserLen));
            var hitsSize = Physics.RaycastNonAlloc(ray, _raycastHits, maxLaserLen);
            if (hitsSize > 0)
                for (var index = 0; index < hitsSize; index++)
                {
                    LaserReceiverData receiver = null;
                    if (_raycastHits[index].collider && (receiver = _raycastHits[index].collider.GetComponent<LaserReceiverData>()) &&
                        !receiver.receiveLaser) continue;
                    point = _raycastHits[index].point;
                    OnCollision?.Invoke(_raycastHits[index].collider);
                    if (receiver) receiver.OnCollisionWithLaser(this);
                    break;
                }

            _lineRenderer.SetPosition(1, point);
        }
    }
}