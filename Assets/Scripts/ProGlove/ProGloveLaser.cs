using UnityEngine;

namespace ProGlove
{
    public class ProGloveLaser : MonoBehaviour
    {
        public LineRenderer lineRenderer;
        public Transform target;
        
        public float startWidth;
        public float endWidth;
        public Color laserColor;

        private void Start()
        {
            lineRenderer.startWidth = startWidth;
            lineRenderer.endWidth = endWidth;
            lineRenderer.material = new Material(Shader.Find("Unlit/Color")) { color = laserColor };
            lineRenderer.startColor = laserColor;
            lineRenderer.endColor = laserColor;
        }
        
        private void Update()
        {
            var ray = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(ray, out var hit))
            {
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, hit.point);
            }
            else
            {
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, target.position);
            }
        }
    }
}
