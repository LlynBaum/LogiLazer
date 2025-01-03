using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu
{
    public class MenuScoreDisplay : MonoBehaviour
    {
        private void Start()
        {
            var text = GetComponent<Text>();
            text.text = StateManager.PreviousScore?.ToString() ?? "-";
        }
    }
}