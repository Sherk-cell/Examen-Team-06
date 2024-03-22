using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class Buttonscript : MonoBehaviour
    {

        [Header("is Paused Settings: ")] 
        [SerializeField] private GameObject pauseMenu;
        private bool _isPaused;

        private void Awake()
        {
            if (pauseMenu != null)
                pauseMenu.SetActive(false);
        }
        
        public void Paused()
        {
            if (pauseMenu != null && !_isPaused)
            {
                _isPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else if (pauseMenu != null && _isPaused)
            {
                _isPaused = false;
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }

        public void GoToScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
            Time.timeScale = 1;
        }
        public void ExitApplication() => Application.Quit();
    }
}
