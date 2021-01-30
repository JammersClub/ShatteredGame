using System;
using Movements;
using UnityEngine;

namespace Puzzle
{
    public class LaserMovement : Movement
    {
        [SerializeField] private Point[] points=new Point[1];
        [Tooltip("In seconds.")]
        [SerializeField] private float timeToPassEachPoint = 3f;
        [SerializeField] private bool rotateOnWay;
        private int _targetPoint;
        private int _lastTargetPoint;
        /// <summary>
        /// from zero to one
        /// </summary>
        private float _passedTime;
        private bool _increase = true;

        private void Start()
        {
            _passedTime = timeToPassEachPoint;
            //convert points from local to global
            foreach (var p in points)
            {
                p.point = transform.TransformPoint(p.point);
                p.direction = transform.TransformDirection(p.direction);
            }
        }

        private void Update()
        {
            _passedTime += Time.deltaTime;
            TargetPosition = Vector3.Lerp(points[_lastTargetPoint].point, points[_targetPoint].point, _passedTime/timeToPassEachPoint);
            if (rotateOnWay)
                TargetRotation = Quaternion.Lerp(Quaternion.LookRotation(points[_lastTargetPoint].direction),
                    Quaternion.LookRotation(points[_targetPoint].direction), _passedTime / timeToPassEachPoint);
            else TargetRotation = Quaternion.LookRotation(points[_targetPoint].direction);
            if (_passedTime < timeToPassEachPoint) return;
            _lastTargetPoint = _targetPoint;
            if (_increase) _targetPoint++;
            else _targetPoint--;
            if (_targetPoint == 0) _increase = true;
            else if (_targetPoint == points.Length - 1 ) _increase = false;
            _passedTime = 0;

        }
        [Serializable]
        private class Point
        {
            [Tooltip("Position In Local Vector.")]
            [SerializeField] public Vector3 point;
            [Tooltip("Direction In Local Vector.")]
            [SerializeField] public Vector3 direction = Vector3.forward;
        }
    }
}