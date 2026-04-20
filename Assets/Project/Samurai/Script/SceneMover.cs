using UnityEngine;
using UnityEngine.SceneManagement;

namespace Polygon.Samurai
{
    public class SceneMover : MonoBehaviour
    {
        public void ChangeScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}