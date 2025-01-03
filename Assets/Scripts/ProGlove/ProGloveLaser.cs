using System.Collections;
using UnityEngine;

namespace ProGlove
{
    public class ProGloveLaser : MonoBehaviour
    {
        public LineRenderer lineRenderer;
        public Camera mainCamera;
        
        public float startWidth;
        public float endWidth;
        public Color laserColor;

        private Coroutine laserCoroutine;

        private void Start()
        {
            lineRenderer.startWidth = startWidth;
            lineRenderer.endWidth = endWidth;
            lineRenderer.material = new Material(Shader.Find("Unlit/Color")) { color = laserColor };
            lineRenderer.startColor = laserColor;
            lineRenderer.endColor = laserColor;
            lineRenderer.enabled = false;
        }

        public void OnShoot()
        {
            if (laserCoroutine != null)
            {
                StopCoroutine(laserCoroutine);
            }

            laserCoroutine = StartCoroutine(ShowLaser());
        }

        private IEnumerator ShowLaser()
        {
            lineRenderer.enabled = true;
            
            var elapsedTime = 0f;

            while (elapsedTime < 0.2f)
            {
                var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                var isHit = Physics.Raycast(ray, out var hit);
            
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, isHit ? hit.point : ray.origin + ray.direction);
                
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            lineRenderer.enabled = false;
        }
    }
}
