using UnityEngine;

namespace Puzzle
{
    public class BoxTracker : MonoBehaviour
    {
        [SerializeField] private float radiusToDetectBox = 1f;
        [SerializeField] private DoorAuthoring targetDoor;
        [SerializeField] private BoxAuthoring[] boxes;
        [SerializeField] private Vector3 offset;

        private void Update()
        {
            //box is in place
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var box in boxes)
                if(Vector3.Distance(box.transform.position, transform.position+offset) < radiusToDetectBox)
                {
                    targetDoor.IsOpen = true;
                    return;
                }

            targetDoor.IsOpen = false;
        }
        
    }
}