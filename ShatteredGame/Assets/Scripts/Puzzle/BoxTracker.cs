using System.Linq;
using UnityEngine;

namespace Puzzle
{
    [RequireComponent(typeof(BoxCollider))]
    public class BoxTracker : MonoBehaviour
    {
        [SerializeField] private DoorAuthoring targetDoor;
        [SerializeField] private BoxAuthoring[] boxes;
        [SerializeField] private AudioSource openCloseAudio;
        private void OnTriggerEnter(Collider other)
        {
            if(targetDoor.IsOpen) return;
            if (boxes.All(box => other.gameObject != box.gameObject)) return;
            targetDoor.IsOpen = true;
            openCloseAudio.Stop();
            openCloseAudio.Play();
        }
        private void OnTriggerExit(Collider other)
        {
            if(!targetDoor.IsOpen) return;
            if (boxes.All(box => other.gameObject != box.gameObject)) return;
            targetDoor.IsOpen = false;
            openCloseAudio.Stop();
            openCloseAudio.Play();
        }
    }
}