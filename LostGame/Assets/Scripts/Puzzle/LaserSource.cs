using System;
using UnityEngine;

// ReSharper disable Unity.InefficientPropertyAccess

namespace Puzzle
{
    [RequireComponent(typeof(LineRenderer))]
    public class LaserSource : MonoBehaviour
    {
        [SerializeField] private float maxLaserLen = 500;
        [SerializeField] private int maxObjectsToDetect = 10;
        private LineRenderer _lineRenderer;
        private RaycastHit[] _raycastHits;
        public event Action<Collider> OnCollision; 

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _raycastHits = new RaycastHit[maxObjectsToDetect];
        }

        private void Update()
        {
            _lineRenderer.SetPosition(0, transform.position);
            var ray = new Ray(transform.position, transform.up);
            var point=transform.TransformPoint(new Vector3(0, maxLaserLen));
            if (Physics.RaycastNonAlloc(ray, _raycastHits, maxLaserLen) > 0)
                foreach (var hit in _raycastHits)
                {
                    if (hit.collider.CompareTag("ByPassLaser")) continue;
                    point = hit.point;
                    OnCollision?.Invoke(hit.collider);
                    break;
                }
            _lineRenderer.SetPosition(1, point);
        }
    }
}