using UnityEngine;

namespace Puzzle
{
    public class LaserReceiverData:MonoBehaviour
    {
        [SerializeField] public bool receiveLaser;
        [SerializeField] private AudioSource getCollisionAudio;
        private bool _hasAudio;

        protected virtual void Awake()
        {
            _hasAudio = getCollisionAudio;
        }

        public virtual void OnCollisionWithLaser(LaserSource laserSource)
        {
            if(_hasAudio) getCollisionAudio.Play();
        }
    }
}