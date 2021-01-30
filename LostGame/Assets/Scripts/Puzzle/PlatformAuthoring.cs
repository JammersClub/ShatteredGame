using UnityEngine;
// ReSharper disable Unity.InefficientPropertyAccess

namespace Puzzle
{
    public class PlatformAuthoring:MonoBehaviour
    {
        [SerializeField] private PlatformManagerAuthoring managerAuthoring;

        private void Awake()
        {
            if (!managerAuthoring) managerAuthoring = transform.parent.GetComponent<PlatformManagerAuthoring>();
        }

        public Transform RespawnPoint => managerAuthoring.respawnPoint;
        public void RePlacePlatform()
        {
            var gm=Instantiate(managerAuthoring.platformPrefab,transform.parent);
            gm.transform.position = transform.position;
            gm.transform.rotation = transform.rotation;
            Destroy(gameObject);
        }
    }
}