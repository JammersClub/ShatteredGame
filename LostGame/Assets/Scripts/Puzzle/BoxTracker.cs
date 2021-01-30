using UnityEngine;

namespace Puzzle
{
    public class BoxTracker : MonoBehaviour
    {
        [SerializeField] private float radiusToDetectBox = 1f;
        [SerializeField] private DoorAuthoring targetDoor;
        [SerializeField] private BoxAuthoring box;
        private bool _scanForTarget = true;

        private void Start()
        {
            targetDoor.IsOpen = false;
        }

        private void Update()
        {
            if (!_scanForTarget) return;
            // ReSharper disable once InvertIf
            if (Vector3.Distance(box.transform.position, transform.position) < radiusToDetectBox)
            {
                _scanForTarget = false;
                //box is in place
                enabled = false;
                targetDoor.IsOpen = true;
            }
        }
        
    }
}