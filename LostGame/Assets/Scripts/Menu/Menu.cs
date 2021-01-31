using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class Menu:MonoBehaviour
    {
        public void RestartGame()
        {
            SceneManager.LoadScene($"MainGame");
        }
    }
}