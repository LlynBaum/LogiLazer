using TMPro;
using UnityEngine;

namespace UI
{
    public class HealthDisplay : MonoBehaviour
    {
        public TextMeshProUGUI textMeshPro;
        
        private int currentHealth;

        private void Start()
        {
            currentHealth = 0;
            DisplayHealth();
        }

        public void OnHealthChange(int newHealth)
        {
            currentHealth = newHealth;
            DisplayHealth();
        }

        private void DisplayHealth()
        {
            textMeshPro.text = $"Health: {currentHealth}";
        }
    }
}
