using TMPro;
using UnityEngine;

namespace UI
{
    public class UiDisplay : MonoBehaviour
    {
        private TextMeshProUGUI textMeshPro;
        
        private int currentValue;

        private void Start()
        {
            textMeshPro = GetComponent<TextMeshProUGUI>();
            currentValue = 0;
            Display();
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