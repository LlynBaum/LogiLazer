using Unity.Mathematics.Geometry;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Parcels
{
    public class Parcel : MonoBehaviour
    {
        public ParcelType parcelType;
        
        public float minSpeed;
        public float maxSpeed;

        public float minHeight;
        public float maxHeight;

        public float initialSpinSpeed;
        
        private Vector3 spawnPosition;
        private Transform target;
        
        private Vector3 spinAxis;
        
        private float height;
        private float speed;
        private float time;

        private void Start()
        {
            spawnPosition = transform.position;
            target = ParcelManager.Instance.target;
            
            speed = Random.Range(minSpeed, maxSpeed);
            height = Random.Range(minHeight, maxHeight);
            time = 0f;
            
            spinAxis = Random.onUnitSphere;
        }

        private void Update()
        {
            if (time < 1f)
            {
                time += Time.deltaTime * speed;
                
                var newPosition = CalculateParabolicPoint(time, spawnPosition, target.position, height);
                transform.position = newPosition;
                
                ApplySpin();
            }
            else
            {
                GameManager.Instance.PlayerHit();
                Destroy(gameObject);
            }
        }

        private void ApplySpin()
        {
            var rotationSpeed = Mathf.Clamp01(1f - time + 0.3f) * initialSpinSpeed;
            transform.Rotate(spinAxis, rotationSpeed * Time.deltaTime, Space.World);
        }

        private static Vector3 CalculateParabolicPoint(float t, Vector3 start, Vector3 end, float h)
        {
            var horizontal = Vector3.Lerp(start, end, t);
            var vertical = h * (1 - Mathf.Pow(2 * t - 1, 2));
            return new Vector3(horizontal.x, horizontal.y + vertical, horizontal.z);
        }
    }
}
