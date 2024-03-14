using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class Buttonscript : MonoBehaviour
    {
        public void GoToScene(string sceneName) => SceneManager.LoadScene(sceneName);
        public void ExitApplication() => Application.Quit();
    }
}
