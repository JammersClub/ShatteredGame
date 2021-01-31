using System.Linq;
using UnityEngine;

namespace Puzzle
{
    [RequireComponent(typeof(BoxCollider))]
    public class BoxTracker : MonoBehaviour
    {
        [SerializeField] private DoorAuthoring targetDoor;
        [SerializeField] private BoxAuthoring[] boxes;
        private void OnTriggerEnter(Collider other)
        {
            if(boxes.Any(box => other.gameObject == box.gameObject)) targetDoor.IsOpen = true;
        }
        private void OnTriggerExit(Collider other)
        {
            if(boxes.Any(box => other.gameObject == box.gameObject)) targetDoor.IsOpen = false;
        }
    }
}