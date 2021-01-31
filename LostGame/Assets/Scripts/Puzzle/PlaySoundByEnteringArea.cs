using Movements;
using Player;
using UnityEngine;

namespace Puzzle
{
    [RequireComponent(typeof(AudioSource))]
    public class PlaySoundByEnteringArea:MonoBehaviour
    {
        private Movement _player;
        private AudioSource _source;
        [SerializeField] private float distanceToGm=5f;

        private void Awake()
        {
            _player = FindObjectOfType<PlayerMovement>();
            _source = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (Vector3.Distance(transform.position, _player.TargetPosition) > distanceToGm) return;
                _source.Play();
                enabled = false;
        }
    }
}