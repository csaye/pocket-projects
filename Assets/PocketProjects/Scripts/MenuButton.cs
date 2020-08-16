using UnityEngine;
using UnityEngine.SceneManagement;

namespace PocketProjects
{
    public class MenuButton : MonoBehaviour
    {
        public void SwitchScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
