using System;
using System.Linq;
using UnityEngine;
// ReSharper disable Unity.PreferNonAllocApi

// ReSharper disable Unity.InefficientPropertyAccess

namespace Puzzle
{
    [RequireComponent(typeof(LineRenderer))]
    public class LaserSource : MonoBehaviour
    {
        [SerializeField] private float maxLaserLen = 500;
        private LineRenderer _lineRenderer;
        public event Action<Collider> OnCollision; 

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _lineRenderer.positionCount = 2;
        }

        private void Update()
        {
            _lineRenderer.SetPosition(0, transform.position);
            var ray = new Ray(transform.position, transform.forward);
            var point=transform.TransformPoint(new Vector3(0, 0,maxLaserLen));
            var raycastHits = Physics.RaycastAll(ray, maxLaserLen).ToList();
            raycastHits.Sort((a, b) => a.distance.CompareTo(b.distance));
            if (raycastHits.Count > 0)
                foreach (var hit in raycastHits)
                {
                    LaserReceiverData receiver = null;
                    if (hit.collider && (receiver = hit.collider.GetComponent<LaserReceiverData>()) &&
                        !receiver.receiveLaser) continue;
                    point = hit.point;
                    OnCollision?.Invoke(hit.collider);
                    if (receiver) receiver.OnCollisionWithLaser(this);
                    break;
                }

            _lineRenderer.SetPosition(1, point);
        }
    }
}