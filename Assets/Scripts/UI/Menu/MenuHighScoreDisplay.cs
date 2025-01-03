using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu
{
    public class MenuHighScoreDisplay : MonoBehaviour
    {
        private void Start()
        {
            var text = GetComponent<Text>();
            text.text = StateManager.HighScore?.ToString() ?? "-";
        }
    }
}
