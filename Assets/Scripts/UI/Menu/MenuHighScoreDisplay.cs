using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu
{
    public class MenuHighScoreDisplay : MonoBehaviour
    {
        private void Start()
        {
            var textMeshPro = GetComponent<Text>();
            textMeshPro.text = StateManager.PreviousScore.ToString();
        }
    }
}
