using UnityEngine;

namespace Parcels
{
    public class ParcelManager : MonoBehaviour
    {
        public static ParcelManager Instance;
        
        public GameObject prefab;
        public Transform target;
        public int rate;

        public float maxOffSetX;
        public float maxOffSetY;
        
        private void Start()
        {
            Instance = this;
            transform.LookAt(target);
            InvokeRepeating(nameof(LaunchParcel), 3, rate);
        }

        private void LaunchParcel()
        {
            var xOffSet = Random.Range(-maxOffSetX, maxOffSetX);
            var yOffSet = Random.Range(-maxOffSetY, maxOffSetY);
            var position = new Vector3(xOffSet, yOffSet) + transform.position;
            Instantiate(prefab, position, transform.rotation);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawCube(transform.position, new Vector3(maxOffSetX, maxOffSetY) * 2);
        }
    }
}
