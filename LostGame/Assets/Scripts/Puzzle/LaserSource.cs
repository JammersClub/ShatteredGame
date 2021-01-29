using System;
using UnityEngine;
// ReSharper disable Unity.InefficientPropertyAccess

namespace Puzzle
{
    [RequireComponent(typeof(LineRenderer))]
    public class LaserSource : MonoBehaviour
    {
        [SerializeField] private float maxLaserLen = 500;
        private LineRenderer _lineRenderer;

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
        }

        private void Update()
        {
            _lineRenderer.SetPosition(0, transform.position);
            var ray = new Ray(transform.position, transform.up);
            _lineRenderer.SetPosition(1,
                Physics.Raycast(ray, out var hit, maxLaserLen)
                    ? hit.point
                    : transform.TransformPoint(new Vector3(0, maxLaserLen)));
        }
    }
}