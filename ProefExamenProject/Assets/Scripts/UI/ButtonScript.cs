using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class ButtonScript : MonoBehaviour
    {
        public void StartGame(string sceneName) => SceneManager.LoadScene(sceneName);
    }
}
