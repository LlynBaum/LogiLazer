using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Menu
{
    public class MenuButtons : MonoBehaviour
    {
        public void OnStartClick()
        {
            SceneManager.LoadScene("Main");
        }

        public void OnQuitClick()
        {
            Debug.Log("Quiting Application!");
            Application.Quit();
        }
    }
}
