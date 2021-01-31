using UnityEngine;

namespace Puzzle
{
    public class PlatformManagerAuthoring : MonoBehaviour
    {
        [SerializeField] public Transform respawnPoint;
        [SerializeField] public PlatformAuthoring platformPrefab;
    }
}