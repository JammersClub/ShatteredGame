using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class Menu : MonoBehaviour
    {
        private void Awake()
        {
            Application.targetFrameRate = 30;
        }

        public void RestartGame()
        {
            SceneManager.LoadScene("MainGame");
        }
    }
}