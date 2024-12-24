using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreDisplay : MonoBehaviour
    {
        public TextMeshProUGUI textMeshPro;
        
        private int currentScore;

        private void Start()
        {
            currentScore = 0;
            DisplayScore();
        }

        public void OnScoreChange(int newScore)
        {
            currentScore = newScore;
            DisplayScore();
        }

        private void DisplayScore()
        {
            textMeshPro.text = $"Score: {currentScore}";
        }
    }
}
