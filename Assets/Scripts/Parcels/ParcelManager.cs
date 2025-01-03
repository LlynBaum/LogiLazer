using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Parcels
{
    public class ParcelManager : DeathTask
    {
        public static ParcelManager Instance;
        
        public GameObject parcelPrefab;
        public GameObject specialParcelPrefab;
        
        public Transform target;
        
        public float rateMin;
        public float rateMax;

        public float maxOffSetX;
        public float maxOffSetY;
        
        protected override IEnumerator StartDeathTask()
        {
            CancelInvoke();
            onFinished.Invoke();
            yield return null;
        }
        
        private void Start()
        {
            if (Instance is not null)
            {
                Destroy(this);
                return;
            }
            Instance = this;
            transform.LookAt(target);

            var rate = Random.Range(rateMin, rateMax);
            InvokeRepeating(nameof(LaunchParcel), 3, rate);
        }

        private void OnDestroy()
        {
            CancelInvoke();
            Instance = null;
        }

        private void LaunchParcel()
        {
            var prefab = Random.value > 0.9 ? specialParcelPrefab : parcelPrefab;
            
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
