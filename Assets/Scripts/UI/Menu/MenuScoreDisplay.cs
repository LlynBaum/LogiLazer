using TMPro;
using UnityEngine;

namespace UI.Menu
{
    public class MenuScoreDisplay : MonoBehaviour
    {
        private void Start()
        {
            var textMeshPro = GetComponent<TextMeshProUGUI>();
            textMeshPro.text = StateManager.HighScore.ToString();
        }
    }
}