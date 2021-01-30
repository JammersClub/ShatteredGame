using UnityEngine;

namespace Puzzle
{
    public class LaserReceiverData:MonoBehaviour
    {
        [SerializeField] public bool receiveLaser;

        public virtual void OnCollisionWithLaser(LaserSource laserSource)
        {
            
        }
    }
}