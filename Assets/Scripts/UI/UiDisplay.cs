using TMPro;
using UnityEngine;

namespace UI
{
    public class UiDisplay : MonoBehaviour
    {
        private TextMeshProUGUI textMeshPro;
        
        private int currentValue;

        private void Awake()
        {
            textMeshPro = GetComponent<TextMeshProUGUI>();
        }

        public void OnChange(int newValue)
        {
            currentValue = newValue;
            Display();
        }

        private void Display()
        {
            textMeshPro.text = currentValue.ToString();
        }
    }
}