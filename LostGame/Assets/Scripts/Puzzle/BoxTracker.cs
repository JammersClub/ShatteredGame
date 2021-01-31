using System;
using UnityEngine;

namespace Puzzle
{
    public class BoxTracker : MonoBehaviour,ICorrectPosition
    {
        [SerializeField] private float radiusToDetectBox = 1f;
        [SerializeField] private DoorAuthoring targetDoor;
        [SerializeField] private BoxAuthoring[] boxes;
        [SerializeField] private Vector3 offset;

        private bool _hasMeshRenderer;
        private MeshRenderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<MeshRenderer>();
            _hasMeshRenderer = _renderer;
        }

        public Vector3 Center => _hasMeshRenderer ? _renderer.bounds.center : transform.position;
        private void Update()
        {
            //box is in place
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var box in boxes)
                if(Vector3.Distance(box.Center, Center) < radiusToDetectBox)
                {
                    targetDoor.IsOpen = true;
                    return;
                }

            targetDoor.IsOpen = false;
        }
        
    }
}