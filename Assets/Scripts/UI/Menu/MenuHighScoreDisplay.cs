using TMPro;
using UnityEngine;

namespace UI.Menu
{
    public class MenuHighScoreDisplay : MonoBehaviour
    {
        private void Start()
        {
            var textMeshPro = GetComponent<TextMeshProUGUI>();
            textMeshPro.text = StateManager.PreviousScore.ToString();
        }
    }
}
