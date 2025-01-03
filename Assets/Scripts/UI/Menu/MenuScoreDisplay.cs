using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu
{
    public class MenuScoreDisplay : MonoBehaviour
    {
        private void Start()
        {
            var textMeshPro = GetComponent<Text>();
            textMeshPro.text = StateManager.HighScore.ToString();
        }
    }
}